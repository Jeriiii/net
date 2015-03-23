using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsletterSender.Dao;
using System.IO;
using NewsletterSender.win;

namespace NewsletterSender
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//CheckData();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HomeWin());
		}

		/// <summary>
		/// Zkontroluje, zda existuje databáze. Pokud ne, vytvoří ji a doptá se na zbylé informace.
		/// </summary>
		private static void CheckData()
		{
			if (! File.Exists(DB.dbFileName))
			{
				CreateDBFile();
				SettingWin settingWin = new SettingWin();
				settingWin.Show();
			}
		}

		private static void CreateDBFile()
		{
			File.Create(DB.dbFileName);
			DB db = new DB();

			string sqlCreateDB = "BEGIN TRANSACTION;" +
				"CREATE TABLE 'settings' (" +
					"`id`	INTEGER PRIMARY KEY AUTOINCREMENT," +
					"`port`	INTEGER," +
					"`host`	TEXT," +
					"`fromAddress`	TEXT," +
					"`fromName`	TEXT" +
				");" +
				"INSERT INTO `settings` VALUES ('1','25','localhost','zmen-adresu@nic.cz','zmen-jmeno');" +
				"CREATE TABLE `groups` (" +
					"`id`	INTEGER PRIMARY KEY AUTOINCREMENT," +
					"`name`	TEXT" +
				");" +
				"CREATE TABLE `contacts_groups` (" +
					"`groupId`	INTEGER," +
					"`contactId`	INTEGER," +
					"PRIMARY KEY(groupId,contactId)" +
				");" +
				"CREATE TABLE 'contacts' (" +
					"`id`	INTEGER PRIMARY KEY AUTOINCREMENT," +
					"`email`	TEXT NOT NULL" +
				");" +
				"COMMIT;";

			db.executeScalar(sqlCreateDB);
		}
	}
}
