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
using System.Net.Mail;
using NewsletterSender.emails;
using NewsletterSender.win;
using NewsletterSender.BUS;

namespace NewsletterSender
{
	public partial class HomeWin : Form
	{
		/// <summary>
		/// Stará se o operace nad Home formulářem.
		/// </summary>
		private HomeBUS homeBUS;

		public HomeWin()
		{
			InitializeComponent();

			this.homeBUS = new HomeBUS();
			this.Invalidated += InvalidateEventHandler;
		}

		private void HomeWin_Invalidated(Object sender, InvalidateEventArgs e) 
		{
			InitGroups();
		}
		

		/// <summary>
		/// Vytvoření nové skupiny.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			NewGroupWin newGroupWin = new NewGroupWin(this);
			newGroupWin.Show();
		}

		/// <summary>
		/// Zavolá se po invalidaci formuláře.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void InvalidateEventHandler(object sender, InvalidateEventArgs e)
		{
			InitGroups();
		}

		/// <summary>
		/// Inicialiyuje skupiny.
		/// </summary>
		private void InitGroups() 
		{
			groupsList.DataSource = this.homeBUS.GetGroups();
		}

		/// <summary>
		/// Spoštění editace skupiny při dvojkliku
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void groupsList_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			int index = groupsList.IndexFromPoint(e.Location);
			string groupName = groupsList.Items[index].ToString();

			EditGroupWin editGroupWin = new EditGroupWin(this, groupName);
			editGroupWin.Show();
		}

		/// <summary>
		/// Tlačítko na odeslání emailů.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			List<string> selectedItems = groupsList.SelectedItems.Cast<string>().ToList(); //vybrané položky
			Dictionary<int, string> contacts = this.homeBUS.GetSelectedContacts(selectedItems);

			SendMailsWin sendMailsWin = new SendMailsWin(contacts);
			sendMailsWin.Show();
		}

		/// <summary>
		/// Nastavení programu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click(object sender, EventArgs e)
		{
			SettingWin settingWin = new SettingWin();
			settingWin.Show();
		}

		/// <summary>
		/// Tlačítko na smazání skupiny.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button3_Click_1(object sender, EventArgs e)
		{
			if (groupsList.SelectedItems.Count == 0)
			{
				WarningMessage.NotGroupSelected();
			}
			else
			{
				List<string> groupNames = new List<string>();
				foreach (var contact in groupsList.SelectedItems)
				{
					groupNames.Add(contact.ToString());
				}

				DialogResult dialogResult = WarningMessage.DeleteContact(groupNames);
				if (dialogResult == DialogResult.Yes)
				{
					this.homeBUS.DeleteGroups(groupNames);
					InitGroups();
				}
			}
		}
	}
}
