using NewsletterSender.Dao;
using NewsletterSender.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.BUS
{
	/// <summary>
	/// Stará se o instalaci programu.
	/// </summary>
	class SettingBUS
	{
		/// <summary>
		/// Vrátí nastavení programu.
		/// </summary>
		/// <returns>Nastavení programu.</returns>
		public SettingModel GetSetting() 
		{
			SettingDao settingDao = new SettingDao(new DB());
			SettingModel model = settingDao.GetAll().First();
			settingDao.Close();

			return model;
		}

		/// <summary>
		/// Uloží nastavení.
		/// </summary>
		/// <param name="model"></param>
		public void SaveSettingModel(string host, int port, string fromName, string fromAddress) {
			SettingModel model = new SettingModel();
			model.host = host;
			model.port = port;

			model.fromName = fromName;
			model.fromAddress = fromAddress;

			SettingDao settingDao = new SettingDao(new DB());
			settingDao.Save(model);
			settingDao.Close();
		}
	}
}
