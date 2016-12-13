using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebook.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public virtual ICollection<CourseOffering> Offerings { get; set; }

        public Course()
        {
            Offerings = new HashSet<CourseOffering>();
        }
    }

    public enum TermStart { Other, Sep, Jan, May }

    public class CourseOffering
    {
        public int CourseOfferingId { get; set; }

        public int CourseId { get; set; }
        public int Year { get; set; }
        public TermStart Term { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CourseSection> Sections { get; set; }

        public CourseOffering()
        {
            Sections = new HashSet<CourseSection>();
        }
    }

    public class CourseSection
    {
        public int CourseSectionId { get; set; }
        public int CourseOfferingId { get; set; }
        public string Name { get; set; }

        public virtual CourseOffering CourseOffering { get; set; }
        public virtual ICollection<ClassMember> Students { get; set; }

        public CourseSection()
        {
            Students = new HashSet<ClassMember>();
        }
    }

    public class ClassMember
    {
        [Key,Column(Order = 1)]
        public int CourseSectionId { get; set; }
        [Key, Column(Order = 2)]
        public int StudentId { get; set; }

        public double? Mark { get; set; }

        public virtual CourseSection CourseSection { get; set; }
        public virtual Student Student { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string SchoolId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<ClassMember> Classes { get; set; }
    }

}
/*
Toll	Sofia
Arrigo	Alexis
Jackson	Cal
Mcardle	Laurence
Taylor	Lahoma
Graziano	Jonathan
Oleary	Nan
Goodridge	Jude
Gross	Janine
Bush	Helvetius
Coronilla	Marco
Bosher	Taylor
Gonzalez	Cody
Irving	Marshall
Zocchi	Tomas
Kelmis	Courtney
Mcguffin	Isabelle
Bevins	India
Custis	Judge
Zibaila	Alan-Michael
Rowings	Janene
Hook	Livia
Checkley	Tad
Katterman	Madison
Lamson	Margaret
Jobe	Sylvie
Cucullu	Laura
Renaud	Xavier
Stillwell	Cass
Hanson	Leanna

     */
