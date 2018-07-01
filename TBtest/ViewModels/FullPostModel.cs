using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class FullPostModel
    {
        public User Users { get; set; }
        public Project Posts { get; set; }

        public IEnumerable<PrjClass> prjClasses { get; set; }
        public IEnumerable<PrjSkill> prjSkills { get; set; }

    }
}
