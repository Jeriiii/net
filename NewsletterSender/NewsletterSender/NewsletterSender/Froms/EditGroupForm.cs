using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsletterSender.Dao;
using NewsletterSender.win;
using NewsletterSender.BUS;

namespace NewsletterSender
{
	public partial class EditGroupWin : Form
	{
		/// <summary>
		/// Hlavní formulář.
		/// </summary>
		HomeWin homeWin;

		/// <summary>
		/// BUS pro skupiny.
		/// </summary>
		GroupsBUS groupsBUS;

		public EditGroupWin(HomeWin homeWin, string groupName)
		{
			this.groupsBUS = new GroupsBUS(groupName);
			this.homeWin = homeWin;
			this.Invalidated += InvalidateEventHandler;

			InitializeComponent();
		}

		/// <summary>
		/// Zavolá se po invalidaci formuláře.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void InvalidateEventHandler(object sender, InvalidateEventArgs e)
		{
			InitGroupName();
			InitEmails();
		}

		/// <summary>
		/// Nastaví jméno skupiny.
		/// </summary>
		private void InitGroupName()
		{
			this.groupNameBox.Text = this.groupsBUS.groupName;
		}

		/// <summary>
		/// Inicializuje emaily ve skupině.
		/// </summary>
		private void InitEmails()
		{
			this.contactsBox.DataSource = this.groupsBUS.GetContacts();
		}

		/// <summary>
		/// Smaže vybrané kontakty.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			if (contactsBox.SelectedItems.Count == 0) {
				WarningMessage.NotContactSelected();
			} else {
				List<string> contactNames = new List<string>();
				foreach (var contact in contactsBox.SelectedItems)
				{
					contactNames.Add(contact.ToString());
				}

				DialogResult dialogResult = WarningMessage.DeleteContact(contactNames);
				if (dialogResult == DialogResult.Yes)
				{
					groupsBUS.DeleteContacts(contactNames);
					InitEmails();
				}				
			}
		}

		/// <summary>
		/// Import kontaktů z mysql databáze.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importContactsDBBtn_Click(object sender, EventArgs e)
		{
			ImportContactsMySQLWin impWin = new ImportContactsMySQLWin(this, this.groupsBUS.groupName);
			impWin.Show();
		}

		/// <summary>
		/// Import kontaktů.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importContactBtn_Click(object sender, EventArgs e)
		{
			ImportContactsWin impWin = new ImportContactsWin(this, this.groupsBUS.groupName);
			impWin.Show();
		}

		/// <summary>
		/// Uloží název skupiny.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string newGroupName = this.groupNameBox.Text;

			groupsBUS.SaveGroupName(newGroupName);

			homeWin.Invalidate();
		}
	}
}
