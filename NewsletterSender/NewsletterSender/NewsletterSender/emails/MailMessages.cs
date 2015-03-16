using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Collections;

namespace NewsletterSender
{
    /**
     * Emaily k odeslání.
     */
    class MailMessages : MailMessage
    {
        /**
         * Přidá seznam emailů k odeslání
         */
        public void Adds(List <MailAddress> mailAddresses)
        {
            foreach(MailAddress address in mailAddresses) {
                this.To.Add(address);
            }
        }
    }
}
