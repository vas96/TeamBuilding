using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class UserSkill
    {
        public int id { get; set; }

        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
