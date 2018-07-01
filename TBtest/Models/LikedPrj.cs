using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class LikedPrj
    {
        public int id { get; set; }

        public int? UserId  { get; set; }
        public virtual User User { get; set; }
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
