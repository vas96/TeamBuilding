using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class UserClass
    {
        public int id { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
