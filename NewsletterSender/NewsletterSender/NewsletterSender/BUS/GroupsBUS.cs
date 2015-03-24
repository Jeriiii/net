using NewsletterSender.Dao;
using NewsletterSender.emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.BUS
{
	/// <summary>
	/// Stará se o skupinu.
	/// </summary>
	class GroupsBUS
	{
		/// <summary>
		/// Název editované skupiny.
		/// </summary>
		public string groupName {get; set;}

		public GroupsBUS(string groupName)
		{
			this.groupName = groupName;
		}

		public GroupsBUS()	{}

		/// <summary>
		/// Načte a vrátí kontakty této skupiny z databáze.
		/// </summary>
		/// <returns></returns>
		public List<string> GetContacts()
		{
			DB database = new DB();
			ContactDao contactDao = new ContactDao(new DB());
			Dictionary<int, string> contacts = contactDao.GetByGroupName(groupName);

			return (List<string>)contacts.Select(group => group.Value).ToList();
		}

		/// <summary>
		/// Smaže vybrané kontakty.
		/// </summary>
		public void DeleteContacts(List<string> contactNames)
		{
			ContactDao contactDao = new ContactDao(new DB());
			contactDao.DeleteContacts(contactNames, this.groupName);
			contactDao.Close();
		}

		/// <summary>
		/// Uloží nový název do skupiny, pokud už skupina s tímto názvem neexistuje.
		/// </summary>
		/// <param name="newGroupName">Nový název skupiny.</param>
		public void SaveGroupName(string newGroupName)
		{
			if (GroupNameNotExist(newGroupName))
			{
				GroupDao groupDao = new GroupDao(new DB());
				groupDao.UpdateName(groupName, newGroupName);
				groupDao.Close();
			}
		}

		/// <summary>
		/// Vytvoří skupinu.
		/// </summary>
		/// <param name="emailsTextArea">Řetězec s emaily skupiny.</param>
		/// <param name="groupName">Název skupiny.</param>
		/// <returns>TRUE = skupina byla vytvořena, jinak FALSE.</returns>
		public bool CreateGroup(string emailsTextArea, string groupName)
		{
			bool groupCreated = false;
			List<string> emails = EmailUtils.ConvertToList(emailsTextArea);

			ImportContacts import = new ImportContacts();
			if (import.AreEmailsValid(emails) && GroupNameNotExist(groupName))
			{
				int groupId = NewGroup(groupName);
				import.Import(emails, groupId);
				groupCreated = true;
			}

			return groupCreated;
		}

		/// <summary>
		/// Vytvoří novou skupinu pouze s názevem - jde o pomocnou metodu
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		private int NewGroup(string groupName)
		{
			GroupDao groupDao = new GroupDao(new DB());
			int groupId = groupDao.NewGroup(groupName);
			groupDao.Close();

			return groupId;
		}

		/// <summary>
		/// Zkontroluje, zda existuje skupina s tímto názvem. Pokud ano, vypíše varovnou hlášku.
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		/// <returns>TRUE = skupina s tímto názvem neexistuje, jinak FALSE.</returns>
		private bool GroupNameNotExist(string groupName)
		{
			GroupDao groupDao = new GroupDao(new DB());
			bool nameExist = groupDao.GroupNameExist(groupName);
			if (nameExist)
			{
				WarningMessage.WrongGroupName(groupName);
			}

			return !nameExist;
		}

	}
}
