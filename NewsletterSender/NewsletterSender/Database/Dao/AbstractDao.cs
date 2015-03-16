using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.Dao
{
    /// <summary>
    /// Abstraktní Dao od kterého dědí všechna ostatní Dao.
    /// </summary>
    abstract class AbstractDao
    {
        protected DB database;

        public AbstractDao(DB database)
        {
            this.database = database;
        }

        /// <summary>
        /// Ukončí připojení k databázi/
        /// </summary>
        public void Close()
        {
            database.Close();
        }
    }
}
