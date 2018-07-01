using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class PrjClass
    {
        public int id { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
        public string ClPeopleNeeded { get; set; }
    }
}
