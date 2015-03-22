using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = System.IO.Path;
using System.Data;
using System.Data.SQLite;

namespace NewsletterSender.Dao
{
	/// <summary>
	/// Třída starající se o připojení k databázi a vykonávání dotazů nad ní.
	/// </summary>
	class DB
	{
		SQLiteConnection m_dbConnection;
		public const string dbFileName = "database.sqlite";

		public DB()
		{
			m_dbConnection = new SQLiteConnection("Data Source=" + dbFileName + ";Version=3;FailIfMissing=True");
			m_dbConnection.Open();
		}

		public void Close()
		{
			m_dbConnection.Close();
		}

		/// <summary>
		/// Vykoná příkaz a vrátí reader
		/// </summary>
		/// <param name="sql">SQL, které se má vykonat.</param>
		/// <returns>Reder s výsledky dotazu.</returns>
		public SQLiteDataReader executeReader(string sql)
		{
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			SQLiteDataReader reader = command.ExecuteReader();
			return reader;
		}

		/// <summary>
		/// Vykoná příkaz
		/// </summary>
		/// <param name="sql">SQL, které se má vykonat.</param>
		public void execute(string sql)
		{
			if (m_dbConnection.State != ConnectionState.Open)
				m_dbConnection.Open();
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			command.ExecuteNonQuery();
		}

		/// <summary>
		/// Vykoná příkaz a vrátí scalar
		/// </summary>
		/// <param name="sql"></param>
		/// <returns>Výsledná hodnota.</returns>
		public Object executeScalar(string sql)
		{
			SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
			Object val = command.ExecuteScalar();
			return val;
		}
	}
}
