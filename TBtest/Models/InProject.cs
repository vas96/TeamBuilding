using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class InProject
    {
        public int id { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
