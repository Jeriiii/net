using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsletterSender.Dao;
using System.Drawing;

namespace NewsletterSender.emails
{
    class EmailValidator
    {

        /// <summary>
        /// Validár emailů. Pokud validace neprojde, zavolá anonymní metodu.
        /// </summary>
        /// <param name="emails">Seznam emailů.</param>
        /// <param name="action">Metoda co se volá, když validace neprojde.</param>
        /// <returns>TRUE = všechny emaily jsou v dobrém formátu, jinak FALSE.</returns>
        public static bool AreEmailsValid(List<string> emails, Action<List<string>> action)
        {
            List<string> wrongEmailAddresses = new List<string>();
            foreach (string email in emails)
            {
                if (!ContactDao.IsValidEmail(email))
                {
                    wrongEmailAddresses.Add(email);
                }
            }
            bool notEmpty = wrongEmailAddresses.Any();
            if (notEmpty) //některý email je nevalidní
            {
                action(wrongEmailAddresses);

            }

            return !notEmpty;
        }
    }


}
