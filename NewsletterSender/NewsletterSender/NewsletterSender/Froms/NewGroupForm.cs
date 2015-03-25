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
using NewsletterSender.BUS;

namespace NewsletterSender
{
	/// <summary>
	/// Vytvoří novou skupinu
	/// </summary>
	public partial class NewGroupWin : Form
	{
		HomeWin homeWin;

		/// <summary>
		/// BUS pro skupiny.
		/// </summary>
		GroupsBUS groupsBUS;

		public NewGroupWin(HomeWin homeWin)
		{
			this.groupsBUS = new GroupsBUS();
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

			bool groupCreated = this.groupsBUS.CreateGroup(emailsTextArea, groupName);

			if (groupCreated)
			{
				homeWin.Invalidate();
				this.Close();
			}
			
			
		}
	}
}
