using MySql.Data.MySqlClient;
using NewsletterSender.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.emails
{
	/// <summary>
	/// Vkládá kontakty do databáze.
	/// </summary>
	class ImportContacts
	{
		/// <summary>
		/// Připojení do MySQL databáze
		/// </summary>
		MySql.Data.MySqlClient.MySqlConnection conn;

		/// <summary>
		/// Vrátí emaily z daného sloupce.
		/// </summary>
		/// <param name="tableName">Název tabulky.</param>
		/// <param name="columnName">Název sloupce.</param>
		/// <returns></returns>
		public List<string> GetEmails(string tableName, string columnName)
		{
			string stm = "SELECT " + columnName + " FROM " + tableName;
			MySqlCommand cmd = new MySqlCommand(stm, conn);
			MySqlDataReader reader = cmd.ExecuteReader();

			List<string> emails = new List<string>();
			while (reader.Read())
			{
				emails.Add(reader.GetString(0));
			}

			return emails;
		}

		/// <summary>
		/// Vloží kontakty do DB.
		/// </summary>
		/// <param name="emails">Emaily, co se mají vložit.</param>
		/// <param name="groupId">Id skupiny, ke které se mají emaily připojit.</param>
		public void Import(List<string> emails, int groupId)
		{
			/* uloží emaily */
			ContactDao contactDao = new ContactDao(new DB());
			contactDao.NewContacts(emails, groupId);
			contactDao.Close();
		}

		/// <summary>
		/// Připojí se do MySQL databáze.
		/// </summary>
		/// <param name="host">Hostitel</param>
		/// <param name="user">Uživatel</param>
		/// <param name="pass">Heslo</param>
		/// <param name="dbName">Název databáze</param>
		public void MysqlConn(string host, string user, string pass, string dbName)
		{
			string myConnectionString;

			myConnectionString = "server=" + host + ";uid=" + user + ";" +
				"pwd=" + pass + ";database=" + dbName + ";";

			try
			{
				conn = new MySql.Data.MySqlClient.MySqlConnection();
				conn.ConnectionString = myConnectionString;
				conn.Open();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Odpojí se od MySQL databáze.
		/// </summary>
		public void Close()
		{
			conn.Close();
		}


	}
}
