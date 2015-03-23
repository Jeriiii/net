using NewsletterSender.Dao;
using NewsletterSender.Database.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterSender.win
{
	public partial class InstallWin : Form
	{
		public InstallWin()
		{
			InitializeComponent();

			SettingDao settingDao = new SettingDao(new DB());
			SettingModel model = settingDao.GetAll().First();
			settingDao.Close();

			host.Text = model.host;
			port.Text = model.port.ToString();

			fromName.Text = model.fromName;
			fromAdderss.Text = model.fromAddress;
		}

		/// <summary>
		/// Uloží nastavení a zavře okno.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			SettingModel model = new SettingModel();
			model.host = host.Text;
			model.port = int.Parse(port.Text);

			model.fromName = fromName.Text;
			model.fromAddress = fromAdderss.Text;

			SettingDao settingDao = new SettingDao(new DB());
			settingDao.Save(model);
			settingDao.Close();

			this.Close();
		}
	}
}
