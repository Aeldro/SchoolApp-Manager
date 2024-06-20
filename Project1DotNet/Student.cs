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
            this.LastName = lastName;
            this.Birthday = birthday;
        }
        // Méthodes "GET"
        public List<Grade> GetGrades(int studentId, Database database)
        {
            List<Grade> studentGrades = new List<Grade>();
            foreach (Grade grade in database.Grades)
            {
                if (grade.StudentId == studentId)
                {
                    studentGrades.Add(grade);
                }
            }
            return studentGrades;
        }

        public double GetAverage(int studentId, Database database)
        {
            return GetGrades(studentId, database).Average(grade => grade.Score);
        }

        // Méthodes "SHOW"
        public void ShowGrades(int studentId, Database database)
        {
            if (database.Grades.Any(grade => grade.StudentId == studentId))
            {
                foreach (Grade grade in database.Grades)
                {
                    if (grade.StudentId == studentId)
                    {
                        Subject currentSubject = database.GetSubject(grade.SubjectId);
                        Console.Write("     Cours            ");
                        Console.WriteLine($": {currentSubject.Name}");
                        Console.Write("     Note             ");
                        Console.WriteLine($": {grade.Score}/20");
                        Console.Write("     Appréciation     ");
                        Console.WriteLine($": {grade.Appreciation}");
                        Console.WriteLine("");
                    }
                }
            }
            else Console.WriteLine("     Cet élève n'a pas encore de note.");
        }

        public void ShowAverage(int studentId, Database database)
        {
            if (database.Grades.Any(grade => grade.StudentId == studentId))
            {
                Console.Write("     Moyenne          ");
                Console.WriteLine($": {Math.Round(GetGrades(studentId, database).Average(grade => grade.Score), 1)}/20");
            }
        }
    }
}
