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
	public partial class HomeWin : Form
	{
		public HomeWin()
		{
			InitializeComponent();

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

		protected static void OnRefresh(System.ComponentModel.RefreshEventArgs e)
		{
			Console.WriteLine(e.ComponentChanged.ToString());
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
		private void InitGroups() {
			GroupDao groupDao = new GroupDao(new DB());

			Dictionary<int, string> groups = groupDao.GetAll();
			groupsList.DataSource = (List<string>) groups.Select(group => group.Value).ToList();
			
			groupDao.Close();
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

		private void button1_Click(object sender, EventArgs e)
		{
			List<string> selectedItems = groupsList.SelectedItems.Cast<string>().ToList(); //vybrané položky
			ContactDao contactDao = new ContactDao(new DB());
			Dictionary<int, string> contacts = contactDao.GetByGroupNames(selectedItems);


		}
	}
}
