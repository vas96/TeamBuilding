using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class PrjSkill
    {
        public int id { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
