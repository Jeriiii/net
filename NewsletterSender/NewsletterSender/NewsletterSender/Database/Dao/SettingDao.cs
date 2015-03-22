using NewsletterSender.Database.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.Dao
{
	/// <summary>
	/// Dao zpřístupní nastavení systému
	/// </summary>
	class SettingDao : AbstractDao
	{
		private string tableName = "settings";

		public SettingDao(DB database) : base(database) { }

		/// <summary>
		/// Vrátí všechny dostupná nastavení.
		/// </summary>
		/// <returns></returns>
		public List<SettingModel> GetAll()
		{
			string sql = "SELECT port, host, fromAddress, fromName FROM " + tableName;
			SQLiteDataReader reader = database.executeReader(sql);

			List<SettingModel> settings = new List<SettingModel>();
			while (reader.Read())
			{
				SettingModel model = new SettingModel();
				model.port = reader.GetInt32(0);
				model.host = reader.GetString(1);
				model.fromAddress = reader.GetString(2);
				model.fromName = reader.GetString(3);

				settings.Add(model);
			}

			return settings;
		}

		/// <summary>
		/// Uloží nastavení
		/// </summary>
		/// <param name="settingModel">Nastavení, které se má uložit.</param>
		public void Save(SettingModel settingModel)
		{
			string sql = "UPDATE " + tableName + " SET "
			+ " port = '" + settingModel.port + "', "
			+ " host = '" + settingModel.host + "', "
			+" fromName = '" + settingModel.fromName + "', "
			+" fromAddress = '" + settingModel.fromAddress + "'";

			database.execute(sql);
		}
	}
}
