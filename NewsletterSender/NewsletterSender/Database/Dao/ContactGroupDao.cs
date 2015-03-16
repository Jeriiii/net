using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsletterSender.Dao
{
    /**
     * Dao pro tabulku contacts_groups
     */
    class ContactGroupDao : AbstractDao
    {
        public const string tableName = "contacts_groups";

        public ContactGroupDao(DB database) : base(database) { }

    }
}
