﻿using System;
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

namespace NewsletterSender
{
	public partial class EditGroupWin : Form
	{
		HomeWin homeWin;
		/// <summary>
		/// Název editované skupiny.
		/// </summary>
		string groupName;

		public EditGroupWin(HomeWin homeWin, string groupName)
		{
			this.homeWin = homeWin;
			this.groupName = groupName;

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

		private void InitGroupName()
		{
			this.groupNameBox.Text = this.groupName;
		}

		/// <summary>
		/// Inicializuje emaily ve skupině.
		/// </summary>
		private void InitEmails()
		{
			DB database = new DB();
			ContactDao contactDao = new ContactDao(new DB());
			Dictionary<int, string> contacts = contactDao.GetByGroupName(groupName);

			this.contactsBox.DataSource = (List<string>)contacts.Select(group => group.Value).ToList();
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
					deleteContacts(contactNames);
					InitEmails();
				}				
			}
		}

		/// <summary>
		/// Smaže vybrané kontakty.
		/// </summary>
		private void deleteContacts(List<string> contactNames)
		{
			ContactDao contactDao = new ContactDao(new DB());
			contactDao.DeleteContacts(contactNames, this.groupName);
			contactDao.Close();
		}

		/// <summary>
		/// Import kontaktů z mysql databáze.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importContactsDBBtn_Click(object sender, EventArgs e)
		{
			ImportContactsMySQLWin impWin = new ImportContactsMySQLWin(this, groupName);
			impWin.Show();
		}

		/// <summary>
		/// Import kontaktů.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void importContactBtn_Click(object sender, EventArgs e)
		{
			ImportContactsWin impWin = new ImportContactsWin(this, groupName);
			impWin.Show();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string newGroupName = this.groupNameBox.Text;

			if (GroupNameNotExist(newGroupName))
			{
				GroupDao groupDao = new GroupDao(new DB());
				groupDao.UpdateName(groupName, newGroupName);
				groupDao.Close();

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
