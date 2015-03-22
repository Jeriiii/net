using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsletterSender
{
	class WarningMessage
	{
		/// <summary>
		/// Upozornění, které se vypíše při vložení emailů ve špatném tvaru.
		/// </summary>
		/// <param name="wrongEmailAddresses">Seznam emailů ve špatném tvaru.</param>
		public static void WrongEmailsFormat(List<string> wrongEmailAddresses)
		{
			string wrongEmails = string.Join(", ", wrongEmailAddresses);
			string message = "Emailové adresy " + wrongEmails + " jsou ve špatném formátu.";
			const string caption = "Emaily ve špatném formátu";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Question);
		}

		/// <summary>
		/// Upozornění, které se vypíše při vložení názvu skupiny, který již existuje.
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		public static void WrongGroupName(string groupName)
		{
			string message = "Skupina s názvem " + groupName + " již existuje.";
			const string caption = "Název skupiny";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Question);
		}

		/// <summary>
		/// Upozornění, že emaily nebyly odeslány.
		/// </summary>
		/// <param name="errorMsg">Chybová hláška, proč nebyly emaily odeslány.</param>
		public static void EmailsNotSended(string errorMsg)
		{
			string message = "Při odesílání emailů nastala tato chyba: " + errorMsg;
			const string caption = "Chyba při odeslání emailů";
			var result = MessageBox.Show(message, caption,
										 MessageBoxButtons.OK,
										 MessageBoxIcon.Question);
		}
	}
}
