using NewsletterSender.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.BUS
{
	/// <summary>
	/// Stará se o operace nad Home formulářem.
	/// </summary>
	class HomeBUS
	{

		/// <summary>
		/// Vrátí seznam všech skupin.
		/// </summary>
		/// <returns>Seznam všech skupin</returns>
		public List<string> GetGroups()
		{
			GroupDao groupDao = new GroupDao(new DB());

			Dictionary<int, string> groups = groupDao.GetAll();
			groupDao.Close();

			return (List<string>) groups.Select(group => group.Value).ToList();
		}

		/// <summary>
		/// Načte vybrané kontakty z databáze.
		/// </summary>
		/// <param name="selectedItems">Vybrané kontakty.</param>
		/// <returns>Vybrané kontakty načtené z databáze.</returns>
		public Dictionary<int, string> GetSelectedContacts(List<string> selectedItems)
		{
			ContactDao contactDao = new ContactDao(new DB());
			Dictionary<int, string> contacts = contactDao.GetByGroupNames(selectedItems);
			contactDao.Close();

			return contacts;
		}

		/// <summary>
		/// Smaže vybrané skupiny.
		/// </summary>
		public void DeleteGroups(List<string> groupNames)
		{
			GroupDao groupDao = new GroupDao(new DB());
			groupDao.DeleteGroups(groupNames);
			groupDao.Close();
		}
	}
}
