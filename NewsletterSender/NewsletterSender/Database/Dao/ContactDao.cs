﻿using System;
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
		/// Vybere kontakty podle názvu skupiny.
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		/// <returns>Vybrané kontakty.</returns>
		public Dictionary<int, string> GetByGroupName(string groupName)
		{

			string sql = "SELECT id FROM " + GroupDao.tableName + " WHERE name = '" + groupName + "'";
			int groupId = Convert.ToInt32((Int64) database.executeScalar(sql));

			sql = "SELECT contactId FROM " + ContactGroupDao.tableName + " WHERE groupId = '" + groupId + "'";
			SQLiteDataReader reader = database.executeReader(sql);

			Dictionary<int, string> emails = new Dictionary<int, string>();
			if (reader.Read()) //skupina má alespoň jeden email
			{
				sql = "SELECT id, email FROM " + ContactDao.tableName + " WHERE id = '" + reader.GetInt32(0) + "'";
				reader = database.executeReader(sql);


				while (reader.Read())
				{
					emails.Add(reader.GetInt32(0), reader.GetString(1));
				}
			}

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
			/* vložení nového záznamu */
			string sql = "INSERT INTO " + tableName + " (email) VALUES ('" + email + "')";
			database.execute(sql);

			/* napojení na skupinu emailů */
			sql = "SELECT last_insert_rowid() AS id FROM " + tableName;
			int contactId = Convert.ToInt32((Int64) database.executeScalar(sql));

			this.ToGroup(contactId, groupId);

			return contactId;
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
