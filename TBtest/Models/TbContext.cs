using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBtest.Models
{
    public class TbContext : DbContext
    {
       
        public DbSet<User> Users { get; set; }
        public DbSet<UserClass> userClasses { get; set; }
        public DbSet<UserSkill> userSkills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<LikedPrj> LikedPrjs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<PrjClass> prjClasses { get; set; }
        public DbSet<PrjSkill> prjSkills { get; set; }
        public DbSet<InProject> inProjects { get; set; }

        public TbContext(DbContextOptions<TbContext> options) : base(options)
        {

        }
    }
}
