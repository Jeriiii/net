using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.Dao
{
	class GroupDao : AbstractDao
	{
		public const string tableName = "groups";

		public GroupDao(DB database) : base(database) { }

		/// <summary>
		/// Vytvoří novou skupinu.
		/// </summary>
		/// <param name="name">Název skupiny.</param>
		/// <returns>Id nově vytvořené skupiny.</returns>
		public int NewGroup(string name)
		{
			/* vložení nového záznamu */
			string sql = "INSERT INTO " + tableName + " (name) VALUES ('" + name + "')";
			database.execute(sql);

			/* napojení na skupinu emailů */
			sql = "SELECT last_insert_rowid() AS id FROM " + tableName;
			int groupId = Convert.ToInt32((Int64)database.executeScalar(sql));

			return groupId;
		}

		/// <summary>
		/// Vrátí všechny skupiny.
		/// </summary>
		/// <returns>Všechy skupiny.</returns>
		public Dictionary<int, string> GetAll()
		{
			/* vložení nového záznamu */
			string sql = "SELECT id, name FROM " + tableName;
			SQLiteDataReader readerGroups = database.executeReader(sql);

			Dictionary<int, string> groups = new Dictionary<int, string>();
			while (readerGroups.Read())
			{
				groups.Add(readerGroups.GetInt32(0), readerGroups.GetString(1));
			}

			return groups;
		}

		/// <summary>
		/// Zjistí, zda skupina tohoto jména již neexistuje.
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		/// <returns>TRUE = skupina tohoto jména již existuje, jinak FALSE.</returns>
		public bool GroupNameExist(string groupName)
		{
			string sql = "SELECT COUNT(id) FROM " + tableName + " WHERE name = '" + groupName + "'";
			int count = Convert.ToInt32((Int64)database.executeScalar(sql));

			return count == 1;
		}
	}
}
