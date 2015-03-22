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
	public partial class SettingWin : Form
	{
		public SettingWin()
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

		private void SettingWin_Load(object sender, EventArgs e)
		{
			
		}

		/// <summary>
		/// Uloží nastavení a zavře okno.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void save_Click(object sender, EventArgs e)
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

		private void cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
