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
    /**
     * Třída starající se o připojení k databázi a vykonávání dotazů nad ní.
     */
    class DB
    {
        SQLiteConnection m_dbConnection;

        public DB()
        {
            //var dbPath = Path.Combine(Environment.CurrentDirectory, @"Data\database.sqlite");
            m_dbConnection = new SQLiteConnection("Data Source=database.sqlite;Version=3;FailIfMissing=True");
            m_dbConnection.Open();
        }

        public void Close()
        {
            m_dbConnection.Close();
        }

        /**
         * Vykoná příkaz a vrátí reader
         */
        public SQLiteDataReader executeReader(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            return reader;
        }

        /**
         * Vykoná příkaz
         */
        public void execute(string sql)
        {
            if (m_dbConnection.State != ConnectionState.Open)
                m_dbConnection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        /**
        * Vykoná příkaz a vrátí scalar
        */
        public Object executeScalar(string sql)
        {
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            Object val = command.ExecuteScalar();
            return val;
        }
    }
}
