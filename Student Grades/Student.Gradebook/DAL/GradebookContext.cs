using StudentGradebook.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebook.DAL
{
    internal class GradebookContext : DbContext
    {
        public GradebookContext() : base("DefaultConnection") { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseOffering> CourseOfferings { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<ClassMember> ClassMembers { get; set; }
        public DbSet<Entities.Student> Students { get; set; }
    }
}
