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
	public partial class ImportContactsMySQLWin : Form
	{
		/// <summary>
		/// Okénko pro editaci skupiny.
		/// </summary>
		EditGroupWin editGroupWin;

		/// <summary>
		/// Název editované skupiny.
		/// </summary>
		string groupName;

		public ImportContactsMySQLWin(EditGroupWin editGroupWin, string groupName)
		{
			InitializeComponent();
			this.groupName = groupName;
			this.editGroupWin = editGroupWin;
		}

		/// <summary>
		/// Importuje emaily z MySQL databáze.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void import_Click(object sender, EventArgs e)
		{
			ImportContacts import = new ImportContacts();

			/* načte emaily z tabulky */
			try { 
				import.MysqlConn(host.Text, user.Text, password.Text, dbName.Text);
				List<string> emails = import.GetEmails(tableName.Text, columName.Text);
				import.Close();

				if (import.AreEmailsValid(emails))
				{
					GroupDao groupDao = new GroupDao(new DB());
					int groupId = groupDao.NewGroup(groupName);
					groupDao.Close();

					import.Import(emails, groupId);

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
