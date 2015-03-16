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
	}
}
