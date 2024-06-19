using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Database
    {
        public List<Student> Students { get; }
        public List<Subject> Subjects { get; }

        public Database()
        {
            this.Students = new List<Student>() {
                new Student(0, "Coralie", "ALINI", new DateTime(2001, 6, 19)),
                new Student(1, "Alex", "PREFI", new DateTime(1995, 1, 8)),
                new Student(2, "Sandrine", "SCRUA", new DateTime(1999, 8,25)),
            };
            this.Subjects = new List<Subject>()
            {
                new Subject(0, "Mathématiques"),
                new Subject(1, "Français"),
                new Subject(2, "Anglais")
            };
        }

        public List<Student> GetStudents()
        {
            return this.Students;
        }

        public List<Subject> GetSubjects()
        {
            return this.Subjects;
        }

        public void ShowStudents()
        {
            Console.WriteLine("____________________");
            Console.WriteLine("Liste des élèves :");
            foreach (Student student in this.Students)
            {
                Console.Write(student.Id + " ");
                Console.Write(student.FirstName + " ");
                Console.WriteLine(student.LastName);
            }
        }
        public void ShowSubjects()
        {
            Console.WriteLine("____________________");
            Console.WriteLine("Liste des cours :");
            foreach (Subject subject in this.Subjects)
            {
                Console.Write(subject.Id + " ");
                Console.WriteLine(subject.Name);
            }
        }

        public void ShowStudent(int id)
        {
            foreach (Student student in this.Students)
            {
                if (student.Id == id)
                {
                    Console.WriteLine(student.Id);
                    Console.WriteLine(student.FirstName);
                    Console.WriteLine(student.LastName);
                    Console.WriteLine(student.Birthday);
                }
            }
            Console.WriteLine("Aucun étudiant ne correspond à cet identifiant");
        }

        public int GenerateStudentId()
        {
            return Students.Last().Id + 1;
        }

        public int GenerateSubjectId()
        {
            return Subjects.Last().Id + 1;
        }
    }
}
