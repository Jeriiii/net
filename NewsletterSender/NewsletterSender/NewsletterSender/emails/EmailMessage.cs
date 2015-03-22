using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.emails
{
	/// <summary>
	/// Třída uchovávající zprávu, co se má uživateli zaslat.
	/// </summary>
	class EmailMessage
	{
		public string Body {get; set; }
		public bool IsBodyHtml {get; set; }
		public string Subject {get; set; }
		public string FromAddress {get; set; }
		public string FromName { get; set; }

		/// <summary>
		/// Vrátí nový email k odeslání danému příjemci.
		/// </summary>
		/// <param name="contact">Příjemce.</param>
		/// <returns>Nový email k odeslání.</returns>
		public MailMessage CreateMailMessage(string contact)
		{
			MailMessage email = new MailMessage();
			email.To.Add(contact);
			email.From = new MailAddress(FromAddress, FromName);
			email.Subject = Subject;
			email.Body = Body;
			email.IsBodyHtml = IsBodyHtml;

			return email;
		}
	}
}
