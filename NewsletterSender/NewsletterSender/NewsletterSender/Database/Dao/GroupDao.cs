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
		/// Uloží nový název skupiny do databáze.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="newName"></param>
		public void UpdateName(string name, string newName)
		{
			string sql = "UPDATE " + tableName + " SET name = '" + newName + "' WHERE name = '" + name + "'";
			database.execute(sql);
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

			return count > 0;
		}

		/// <summary>
		/// Smaže seznam skupin.
		/// </summary>
		/// <param name="groupNames">Seznam skupin.</param>
		public void DeleteGroups(List<string> groupNames)
		{
			List<string> groupsIds = GetGroupIds(groupNames);

			string sql = "DELETE FROM " + tableName + " WHERE id IN (" + listToIN(groupsIds) + ")";
			database.execute(sql);

			sql = "DELETE FROM " + ContactGroupDao.tableName + " WHERE groupId IN (" + listToIN(groupsIds) + ")";
			database.execute(sql);
		}

		/// <summary>
		/// Získání id skupin z jejich názvů.
		/// </summary>
		/// <returns>Seznam Id skupin.</returns>
		public List<string> GetGroupIds(List<string> groupNames)
		{
			string sql = "SELECT id FROM " + tableName + " WHERE name IN (" + listToIN(groupNames) + ")";
			SQLiteDataReader reader = database.executeReader(sql);

			List<string> groupIds = new List<string>();
			while (reader.Read())
			{
				groupIds.Add("" + reader.GetInt32(0));
			}

			return groupIds;
		}

		/// <summary>
		/// Vrátí Id skupiny podle názvu.
		/// </summary>
		/// <param name="groupName"></param>
		/// <returns></returns>
		public int GetGroupByName(string groupName)
		{
			string sql = "SELECT id FROM " + tableName + " WHERE name = '" + groupName + "'";
			int groupId = Convert.ToInt32((Int64)database.executeScalar(sql));
			return groupId;
		}
	}
}
