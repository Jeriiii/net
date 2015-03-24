using NewsletterSender.BUS;
using NewsletterSender.Dao;
using NewsletterSender.Database.Model;
using NewsletterSender.emails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterSender
{
	/// <summary>
	/// Okénko v odeslání emailů.
	/// </summary>
	public partial class SendMailsWin : Form
	{
		/// <summary>
		/// Stará se o odeslání emailů.
		/// </summary>
		SendMailBUS sendMailBUS;

		/// <summary>
		/// Stará se o instalaci programu.
		/// </summary>
		SettingBUS settingBUS;

		public SendMailsWin(Dictionary<int, string> contacts)
		{
			InitializeComponent();

			sendMailBUS = new SendMailBUS(contacts);
			settingBUS = new SettingBUS();

			SettingModel model = settingBUS.GetSetting();
			fromName.Text = model.fromName;
			fromAdderss.Text = model.fromAddress;

			progressBar.Visible = false;
		}

		/// <summary>
		/// Odeslání emailů.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			EmailMessage emailMessage = new EmailMessage();

			emailMessage.Body = body.Text;
			emailMessage.Subject = subject.Text;
			emailMessage.IsBodyHtml = idBodyHTML.Checked;
			emailMessage.FromName = fromName.Text;
			emailMessage.FromAddress = fromAdderss.Text;

			sendMailBUS.sendMails(progressBar, emailMessage);
			this.Close();
		}
	}
}
