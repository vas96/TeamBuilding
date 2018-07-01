using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PictureParh { get; set; }
        public DateTime Registrated { get; set; }
        public int ContactId { get; set; }
        public int Request { get; set; }
        public string Bio { get; set; }
       
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<LikedPrj> LikedPrjs { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<UserClass> UserClasses { get; set; }
        public virtual ICollection<InProject> InProjects { get; set; }

        public User()
        {
            Projects = new List<Project>();
            LikedPrjs = new List<LikedPrj>();
            UserSkills = new List<UserSkill>();
            UserClasses = new List<UserClass>();
            InProjects = new List<InProject>();
        }
    }
}
