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
	/// <summary>
	/// Okénko pro import kontatků z MySQL databáze
	/// </summary>
	public partial class ImportContactsMySQLWin : Form
	{
		/// <summary>
		/// Okénko pro editaci skupiny.
		/// </summary>
		private EditGroupWin editGroupWin;

		/// <summary>
		/// Stará se o kontakty.
		/// </summary>
		private ContactsBUS contactsBUS;

		public ImportContactsMySQLWin(EditGroupWin editGroupWin, string groupName)
		{
			InitializeComponent();
			this.contactsBUS = new ContactsBUS(groupName);
			this.editGroupWin = editGroupWin;
		}

		/// <summary>
		/// Importuje emaily z MySQL databáze.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void import_Click(object sender, EventArgs e)
		{
			/* načte emaily z tabulky */
			try {
				bool areEmailsValid = this.contactsBUS.Import(
					host.Text, user.Text, password.Text, dbName.Text, tableName.Text, columName.Text
				);
				if (areEmailsValid)
				{
					this.editGroupWin.Invalidate();
					this.Close();
				}
			}
			catch (Exception ex)
			{
				WarningMessage.MysqlConnException(ex.Message);
			}
		}
	}
}
