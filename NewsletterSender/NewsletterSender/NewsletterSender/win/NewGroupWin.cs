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
using NewsletterSender.emails;

namespace NewsletterSender
{
	public partial class NewGroupWin : Form
	{
		HomeWin homeWin;

		/// <summary>
		/// Vytvoří novou skupinu
		/// </summary>
		public NewGroupWin(HomeWin homeWin)
		{
			this.homeWin = homeWin;
			InitializeComponent();
		}

		/// <summary>
		/// Obsluha tlačítka ulož
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			string groupName = this.name.Text;
			string emailsTextArea = this.emails.Text;
			List<string> emails = EmailUtils.ConvertToList(emailsTextArea);

			ImportContacts import  = new ImportContacts();
			if (import.AreEmailsValid(emails) && GroupNameNotExist(groupName))
			{

				GroupDao groupDao = new GroupDao(new DB());
				int groupId = groupDao.NewGroup(groupName);
				groupDao.Close();

				import.Import(emails, groupId);

				homeWin.Invalidate();
				this.Close();
			}
		}

		
		/// <summary>
		/// Zkontroluje, zda existuje skupina s tímto názvem. Pokud ano, vypíše varovnou hlášku.
		/// </summary>
		/// <param name="groupName">Název skupiny.</param>
		/// <returns>TRUE = skupina s tímto názvem neexistuje, jinak FALSE.</returns>
		private bool GroupNameNotExist(string groupName)
		{
			GroupDao groupDao = new GroupDao(new DB());
			bool nameExist = groupDao.GroupNameExist(groupName);
			if (nameExist)
			{
				WarningMessage.WrongGroupName(groupName);
			}

			return !nameExist;
		}
	}
}
