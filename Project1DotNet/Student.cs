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

        public Student(int id, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName.ToUpper();
            this.Birthday = birthday;
        }
        // Méthodes "GET"
        public List<Grade> GetGrades()
        {
            List<Grade> studentGrades = new List<Grade>();
            List<Grade> grades = ListsManagement.GetGrades();

            foreach (Grade grade in grades)
            {
                if (grade.StudentId == Id)
                {
                    studentGrades.Add(grade);
                }
            }

            return studentGrades;
        }

        public double GetAverage()
        {
            return GetGrades().Average(grade => grade.Score);
        }
    }
}
