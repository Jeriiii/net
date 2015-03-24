using NewsletterSender.BUS;
using NewsletterSender.Dao;
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

namespace NewsletterSender.win
{
	public partial class ImportContactsWin : Form
	{

		/// <summary>
		/// Okénko pro editaci skupiny.
		/// </summary>
		EditGroupWin editGroupWin;

		/// <summary>
		/// Stará se o kontakty.
		/// </summary>
		private ContactsBUS contactsBUS;

		public ImportContactsWin(EditGroupWin editGroupWin, string groupName)
		{
			InitializeComponent();
			this.contactsBUS = new ContactsBUS(groupName);
			this.editGroupWin = editGroupWin;
		}

		/// <summary>
		/// Vloží emaily k dané skupině.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string emailsTextArea = this.emails.Text;

			List<string> emails = EmailUtils.ConvertToList(emailsTextArea);
			bool areEmailsValid = this.contactsBUS.Import(emails);

			if (areEmailsValid) {
				editGroupWin.Invalidate();
				this.Close();
			}
		}
	}
}
