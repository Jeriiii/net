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

		/// <summary>
		/// Vrátí list položek tak, aby se dali dát do dotazu WHERE ... IN (vraciTatoMetoda)
		/// </summary>
		/// <returns>Položky tak, aby se dali dát klauzule IN</returns>
		protected string listToIN(List<string> items)
		{
			return string.Join(", ", items.Select(item => item = "'" + item + "'").ToArray());
		}

		/// <summary>
		/// Vrátí list položek tak, aby se dali dát do dotazu WHERE ... IN (vraciTatoMetoda)
		/// </summary>
		/// <returns>Položky tak, aby se dali dát klauzule IN</returns>
		protected string listToIN(List<int> items)
		{
			List<string> itemsStr = items.Select(item => item.ToString()).ToList();
			return listToIN(itemsStr);
		}
	}
}
