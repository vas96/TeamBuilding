using Microsoft.Azure.KeyVault.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int PhoneNum { get; set; }
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string PublicMail { get; set; }
        public string Twitter { get; set; }
        public string Skype { get; set; }
        public string Telegram { get; set; }
        public string Viber { get; set; }

        public List<User> Users { get; set; }
        public Contact()
        {
            Users = new List<User>();
        }
    }
}
