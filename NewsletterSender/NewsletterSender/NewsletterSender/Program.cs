using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsletterSender.Dao;

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
			DB database = new DB();
			ContactDao contactDao = new ContactDao(database);

			contactDao.NewContact("abc", 1);

			database.Close();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HomeWin());
		}
	}
}
