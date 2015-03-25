using NewsletterSender.BUS;
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
		/// <summary>
		/// Stará se o instalaci programu.
		/// </summary>
		SettingBUS settingBUS;

		public SettingWin()
		{
			InitializeComponent();

			settingBUS = new SettingBUS();
			SettingModel model = settingBUS.GetSetting();

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
		private void save_Click(object sender, EventArgs e)
		{
			settingBUS.SaveSettingModel(
				host.Text, int.Parse(port.Text), fromName.Text, fromAdderss.Text
			);

			this.Close();
		}

		/// <summary>
		/// Zavře okno.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
