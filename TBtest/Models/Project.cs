using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string PrjName { get; set; }
        public string PrjDesc { get; set; }
        public string PrjImg { get; set; }
        public DateTime PrjCreatedDate { get; set; }
        public int PrjLikeCounter { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<LikedPrj> LikedPrjs { get; set; }
        public virtual ICollection<PrjSkill> PrjSkills { get; set; }
        public virtual ICollection<PrjClass> PrjClasses { get; set; }
        public virtual ICollection<InProject> InProjects { get; set; }

        public Project()
        {
            LikedPrjs = new List<LikedPrj>();
            PrjSkills = new List<PrjSkill>();
            PrjClasses = new List<PrjClass>();
            InProjects = new List<InProject>();
        }
    }
 
}
