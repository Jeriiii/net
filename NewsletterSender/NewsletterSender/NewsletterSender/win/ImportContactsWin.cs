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
		/// Název editované skupiny.
		/// </summary>
		string groupName;

		public ImportContactsWin(EditGroupWin editGroupWin, string groupName)
		{
			InitializeComponent();
			this.groupName = groupName;
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

			ImportContacts import = new ImportContacts();
			if (import.AreEmailsValid(emails))
			{

				GroupDao groupDao = new GroupDao(new DB());
				int groupId = groupDao.NewGroup(groupName);
				groupDao.Close();

				import.Import(emails, groupId);

				editGroupWin.Invalidate();
				this.Close();
			}
		}
	}
}
