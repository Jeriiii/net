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
		/// Kontakty, kam se mají emaily odeslat.
		/// </summary>
		Dictionary<int, string> contacts;

		public SendMailsWin(Dictionary<int, string> contacts)
		{
			InitializeComponent();
			this.contacts = contacts;

			SettingDao settingDao = new SettingDao(new DB());
			SettingModel model = settingDao.GetAll().First();
			settingDao.Close();

			fromName.Text = model.fromName;
			fromAdderss.Text = model.fromAddress;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		/// <summary>
		/// Připravý emaily k odeslání a odešle je.
		/// </summary>
		/// <param name="contacts">Kontakty, kterým se má email odeslat.</param>
		/// <param name="emailMessage">Zpráva co se má odeslat.</param>
		private void sendMails(Dictionary<int, string> contacts, EmailMessage emailMessage)
		{
			MailMessages mailMessages = new MailMessages();
			try
			{
				mailMessages.SendMails(contacts, emailMessage);
			}
			catch (Exception ex)
			{
				WarningMessage.EmailsNotSended(ex.Message);
			}
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
			emailMessage.FromName = "";
			emailMessage.FromAddress = "info@123.cz";

			sendMails(contacts, emailMessage);
		}
	}
}
