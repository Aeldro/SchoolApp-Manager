using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public List<Grade> Grades { get; }
        public double Average { get => Grades.Average(Grade => Grade.Score); }

        public Student (int id, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = new DateTime(2000,10,10);
            
        }

        public bool AddGrade(Subject subject, double score, string appreciation)
        {
            try
            {
            Grades.Add(new Grade(subject, score, appreciation));
            return true;
            }
            catch { return false; }
        }
    }
}
