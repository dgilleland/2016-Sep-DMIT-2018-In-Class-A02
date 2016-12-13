using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentGradebook.Entities;

namespace StudentGradebook.BLL
{
    public class DummyController
    {
        public IEnumerable<Student> ListFakeStudents()
        {
            yield return new Student() { LastName = "Toll", FirstName = "Sofia" };
            yield return new Student() { LastName = "Arrigo", FirstName = "Alexis" };
            yield return new Student() { LastName = "Jackson", FirstName = "Cal" };
            yield return new Student() { LastName = "Mcardle", FirstName = "Laurence" };
            yield return new Student() { LastName = "Taylor", FirstName = "Lahoma" };
            yield return new Student() { LastName = "Graziano", FirstName = "Jonathan" };
            yield return new Student() { LastName = "Oleary", FirstName = "Nan" };
            yield return new Student() { LastName = "Goodridge", FirstName = "Jude" };
            //yield return new Student() { LastName = "Gross", FirstName = "Janine" };
            //yield return new Student() { LastName = "Bush", FirstName = "Helvetius" };
            //yield return new Student() { LastName = "Coronilla", FirstName = "Marco" };
            //yield return new Student() { LastName = "Bosher", FirstName = "Taylor" };
            //yield return new Student() { LastName = "Gonzalez", FirstName = "Cody" };
            //yield return new Student() { LastName = "Irving", FirstName = "Marshall" };
            //yield return new Student() { LastName = "Zocchi", FirstName = "Tomas" };
            //yield return new Student() { LastName = "Kelmis", FirstName = "Courtney" };
            //yield return new Student() { LastName = "Mcguffin", FirstName = "Isabelle" };
            //yield return new Student() { LastName = "Bevins", FirstName = "India" };
            //yield return new Student() { LastName = "Custis", FirstName = "Judge" };
            //yield return new Student() { LastName = "Zibaila", FirstName = "Alan-Michael" };
            //yield return new Student() { LastName = "Rowings", FirstName = "Janene" };
            //yield return new Student() { LastName = "Hook", FirstName = "Livia" };
            //yield return new Student() { LastName = "Checkley", FirstName = "Tad" };
            //yield return new Student() { LastName = "Katterman", FirstName = "Madison" };
            //yield return new Student() { LastName = "Lamson", FirstName = "Margaret" };
            //yield return new Student() { LastName = "Jobe", FirstName = "Sylvie" };
            //yield return new Student() { LastName = "Cucullu", FirstName = "Laura" };
            //yield return new Student() { LastName = "Renaud", FirstName = "Xavier" };
            //yield return new Student() { LastName = "Stillwell", FirstName = "Cass" };
            //yield return new Student() { LastName = "Hanson", FirstName = "Leanna" };
        }
    }
}
