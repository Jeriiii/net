using NewsletterSender.emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterSender.BUS
{
	/// <summary>
	/// Stará se o odeslání emailů.
	/// </summary>
	class SendMailBUS : AbstractBUS
	{
		/// <summary>
		/// Kontakty, kam se mají emaily odeslat.
		/// </summary>
		Dictionary<int, string> contacts;

		public SendMailBUS(Dictionary<int, string> contacts)
		{
			this.contacts = contacts;
		}
		
		/// <summary>
		/// Připravý emaily k odeslání a odešle je.
		/// </summary>
		/// <param name="contacts">Kontakty, kterým se má email odeslat.</param>
		/// <param name="emailMessage">Zpráva co se má odeslat.</param>
		public void sendMails(ProgressBar progressBar, EmailMessage emailMessage)
		{
			MailMessages mailMessages = new MailMessages();
			try
			{
				mailMessages.SendMails(progressBar, contacts, emailMessage);
				WarningMessage.EmailsSended();
			}
			catch (Exception ex)
			{
				WarningMessage.EmailsNotSended(ex.Message);
			}
		}
	}
}
