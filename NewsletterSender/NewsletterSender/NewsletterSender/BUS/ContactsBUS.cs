﻿using NewsletterSender.Dao;
using NewsletterSender.emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.BUS
{
	/// <summary>
	/// Stará se o kontakty.
	/// </summary>
	class ContactsBUS
	{

		/// <summary>
		/// Název skupiny ve které jsou dané kontakty.
		/// </summary>
		public string groupName;

		public ContactsBUS(string groupName)
		{
			this.groupName = groupName;
		}

		/// <summary>
		/// Importuje kontakty z databáze.
		/// </summary>
		/// <returns>TRUE = kontakty jsou validní, jinak FALSE</returns>
		public bool Import(string host, string user, string password, string dbName, string tableName, string columName)
		{
			try {
				ImportContacts import = new ImportContacts();

				import.MysqlConn(host, user, password, dbName);
				List<string> emails = import.GetEmails(tableName, columName);
				import.Close();

				return Import(emails);
			}
			catch (Exception ex) {
				throw ex;
			}
		}

		/// <summary>
		/// Importuje kontatky.
		/// </summary>
		/// <param name="emails">Kontakty, co se mají importovat.</param>
		/// <returns>TRUE = kontakty jsou validní, jinak FALSE</returns>
		public bool Import(List<string> emails)
		{
			ImportContacts import = new ImportContacts();
			
			bool areEmailsValid = import.AreEmailsValid(emails);
			if (areEmailsValid)
			{
				GroupDao groupDao = new GroupDao(new DB());
				int groupId = groupDao.NewGroup(groupName);
				groupDao.Close();

				import.Import(emails, groupId);
			}

			return areEmailsValid;
		}

	}
}