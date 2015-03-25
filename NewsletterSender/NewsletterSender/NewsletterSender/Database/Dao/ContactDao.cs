using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace NewsletterSender.Dao
{
	/// <summary>
	/// Dao pro tabulku contacts
	/// </summary>
	class ContactDao : AbstractDao
	{
		public const string tableName = "contacts";

		public ContactDao(DB database) : base(database){}

		/// <summary>
		/// Vložení nových kontaktů
		/// </summary>
		/// <param name="emails">Seznam emailů</param>
		/// <param name="groupId">Id skupiny.</param>
		
		public void NewContacts(List<string> emails, int groupId)
		{
			foreach (string email in emails)
			{
				NewContact(email, groupId);
			}
		}

		/// <summary>
		/// Vybere kontakty podle názvů skupin.
		/// </summary>
		/// <param name="groupNames">Název skupin.</param>
		/// <returns>Vybrané kontakty.</returns>
		public Dictionary<int, string> GetByGroupNames(List<string> groupNames)
		{
			GroupDao groupDao = new GroupDao(database);
			List<string> groupIds = groupDao.GetGroupIds(groupNames);
			Dictionary<int, string> emails = GetContacts(groupIds);

			return emails;


		}

		/// <summary>
		/// Vrátí kontakty podle id skupin
		/// </summary>
		/// <param name="groupIds"></param>
		/// <returns></returns>
		private Dictionary<int, string> GetContacts(List<string> groupIds)
		{
			/* získání id kontaktů ze spojovací tabulky */
			string sql = "SELECT contactId FROM " + ContactGroupDao.tableName + " WHERE groupId IN (" + listToIN(groupIds) + ")";
			SQLiteDataReader reader = database.executeReader(sql);

			List<string> contactGroupIds = new List<string>();
			while (reader.Read())
			{
				contactGroupIds.Add(reader.GetInt32(0).ToString());
			}

			/* získání samotných kontaktů */
			sql = "SELECT id, email FROM " + ContactDao.tableName + " WHERE id IN (" + listToIN(contactGroupIds) + ")";
			reader = database.executeReader(sql);

			Dictionary<int, string> emails = new Dictionary<int, string>();
			while (reader.Read())
			{
				emails.Add(reader.GetInt32(0), reader.GetString(1));
			}

			return emails;
		}

		/// <summary>
		/// Vybere kontakty podle názvu skupiny.
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		/// <returns>Vybrané kontakty.</returns>
		public Dictionary<int, string> GetByGroupName(string groupName)
		{
			List<string>groupNames = new List<string>{groupName};

			GroupDao groupDao = new GroupDao(database);
			List<string> groupIds = groupDao.GetGroupIds(groupNames);

			Dictionary<int, string> emails = GetContacts(groupIds);

			return emails;


		}

		/// <summary>
		/// Vložení nového kontaktu
		/// </summary>
		/// <param name="email">Email</param>
		/// <param name="groupId">Id skupiny</param>
		/// <returns></returns>
		public int NewContact(string email, int groupId) 
		{
			int contactId = FindById(email);
			
			if (contactId == 0) {
				/* vložení nového záznamu */
				string sql = "INSERT INTO " + tableName + " (email) VALUES ('" + email + "')";
				database.execute(sql);

				/* napojení na skupinu emailů */
				sql = "SELECT last_insert_rowid() AS id FROM " + tableName;
				contactId = Convert.ToInt32((Int64) database.executeScalar(sql));

				this.ToGroup(contactId, groupId);
			}
			else
			{
				/* pokud je už v nějaké skupině, zkontroluje, jestli není už v této konkrétní skupině */
				if (! IsInGroup(contactId, groupId))
				{
					this.ToGroup(contactId, groupId);
				}
			}

			return contactId;
		}

		/// <summary>
		/// Zjistí, jestli tento kontakt je již v této skupině.
		/// </summary>
		/// <param name="contactId">Id kontaktu.</param>
		/// <param name="groupId">Id skupiny.</param>
		/// <returns>TRUE = kontakt je již v této skupině, jinak FALSE.</returns>
		private bool IsInGroup(int contactId, int groupId) {
			string sql = "SELECT contactId FROM " + ContactGroupDao.tableName +
				" WHERE contactId = '" + contactId + "' AND groupId = '" + groupId + "'";
			
			var contactGroupId = database.executeScalar(sql);

			if (contactGroupId != null)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Vrátí id kontaktu, pokud existuje.
		/// </summary>
		/// <param name="email">Emailová adresa.</param>
		/// <returns>Id kontaktu.</returns>
		private int FindById(string email)
		{
			string sql = "SELECT id FROM " + tableName + " WHERE email = '" + email + "'";
			var contactId = database.executeScalar(sql);
			if (contactId != null)
			{
				return Convert.ToInt32((Int64) contactId);
			}

			return 0;
		}

		/// <summary>
		/// Zařadí kontakt do skupiny
		/// </summary>
		/// <param name="contactId">Id kontaktu</param>
		/// <param name="groupId">Id skupiny</param>
		public void ToGroup(int contactId, int groupId)
		{
			string sql = "INSERT INTO " + ContactGroupDao.tableName + " (groupId, contactId) " +
			"VALUES ('" + groupId + "', '" + contactId + "')";
			database.execute(sql);
		}

		/// <summary>
		/// Odstraní kontakt ze skupiny
		/// </summary>
		/// <param name="contactId">Id kontatku</param>
		/// <param name="groupId">Id skupiny</param>
		public void RemoveGroup(int contactId, int groupId)
		{
			string sql = "DELETE FROM " + ContactGroupDao.tableName +
			"WHERE groupId = '" + groupId + "' AND contactId = '" + contactId + "'";
			database.execute(sql);
		}

		/// <summary>
		/// Smaže vazby mezi skupinou a kontakty.
		/// </summary>
		/// <param name="contactNames">Názvy kontaktů.</param>
		/// <param name="groupName">Název skupiny.</param>
		public void DeleteContacts(List<string> contactNames, string groupName)
		{
			GroupDao groupDao = new GroupDao(database);
			int groupId = groupDao.GetGroupByName(groupName);
			List<int> contactIds = GetByNames(contactNames);
			
			string sql = "DELETE FROM " + ContactGroupDao.tableName +
			" WHERE groupId = '" + groupId + "' AND contactId IN (" + listToIN(contactIds) + ")";
			database.execute(sql);
		}

		/// <summary>
		/// Vrátí id kontatků podle jejich názvů.
		/// </summary>
		/// <param name="names">Názvy kontaktů = emaily</param>
		/// <returns></returns>
		private List<int> GetByNames(List<string> names)
		{
			string sqlNames = string.Join(", ", names.Select(name => name = "'" + name + "'").ToArray());
			string sql = "SELECT id FROM " + tableName + " WHERE email IN (" + sqlNames + ")";

			SQLiteDataReader reader = database.executeReader(sql);
			List<int> contactIds = new List<int>();

			while (reader.Read())
			{
				contactIds.Add(reader.GetInt32(0));
			}

			return contactIds;
		}

		/// <summary>
		/// Validace emailové adresy
		/// </summary>
		/// <param name="email">Emailová adresa</param>
		/// <returns>TRUE = emailá adresa je validní, jinak FALSE.</returns>
		
		public static bool IsValidEmail(string email)
		{
			try
			{
				var addr = new System.Net.Mail.MailAddress(email);
				return addr.Address == email;
			}
			catch
			{
				return false;
			}
		}

	}
}
