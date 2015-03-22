using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.emails
{
	class EmailUtils
	{
		/// <summary>
		/// Převede řetězec vložený uživatelem na jednotlivé emaily
		/// </summary>
		/// <param name="emailsTextArea">Řetězec emailových adres</param>
		/// <returns>Seznam emailových adres</returns>
		public static List<string> ConvertToList(string emailsTextArea)
		{
			string[] separators = { ",", ";", "\t", " ", "\n", "\r\n" };
			string[] emails = emailsTextArea.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			return new List<string>(emails);
		}
	}
}
