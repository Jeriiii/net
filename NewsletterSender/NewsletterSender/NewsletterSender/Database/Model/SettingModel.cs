using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.Database.Model
{
	/// <summary>
	/// Přepravka pro uživatelské nastavení.
	/// </summary>
	class SettingModel
	{
		public string fromName { get; set;}
		public string fromAddress { get; set; }
		public int port { get; set; }
		public string host { get; set; }
	}
}
