using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Collections;
using System.Net;
using NewsletterSender.emails;
using NewsletterSender.Database.Model;
using NewsletterSender.Dao;
using System.Windows.Forms;

namespace NewsletterSender
{
	/// <summary>
	/// Emaily k odeslání.
	/// </summary>
	class MailMessages
	{

		/// <summary>
		/// Odešle všechny emaily. Nastaví defaultního klienta.
		/// </summary>
		/// <param name="contacts">Kontakty k odeslání.</param>
		/// <returns>Chybová hláška. NULL = odeslání proběhlo úspěšně.</returns>
		public void SendMails(ProgressBar progressBar, Dictionary<int, string> contacts, EmailMessage emailMessage)
		{
			/* načtení nastavení z DB */
			SettingDao settingDao = new SettingDao(new DB());
			SettingModel model = settingDao.GetAll().First();
			settingDao.Close();

			/* vytvoření klienta a odeslání emailů */
			SmtpClient client = new SmtpClient(model.host);
			client.Port = model.port;

			NetworkCredential info = new NetworkCredential(model.fromAddress, model.fromName);
			client.DeliveryMethod = SmtpDeliveryMethod.Network;
			client.UseDefaultCredentials = false;
			client.Credentials = info;

			SendMails(progressBar, contacts, emailMessage, client);
		}

		/// <summary>
		/// Odešle všechny emaily.
		/// </summary>
		/// <param name="contacts">Kontakty k odeslání.</param>
		/// <param name="client">Klient, který bude emaily odeslívat</param>
		/// <returns>Chybová hláška. NULL = odeslání proběhlo úspěšně.</returns>
		public void SendMails(ProgressBar progressBar, Dictionary<int, string> contacts, EmailMessage emailMessage, SmtpClient client)
		{
			try
			{
				int count = contacts.Count(); 

				progressBar.Visible = true;
				progressBar.Minimum = 1;
				progressBar.Maximum = contacts.Count();
				progressBar.Value = 1;
				progressBar.Step = 1;

				/* Postupně odešle všechny emaily. */
				foreach (var contact in contacts)
				{
					MailMessage email = emailMessage.CreateMailMessage(contact.Value);

					client.Send(email);
					progressBar.PerformStep();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
