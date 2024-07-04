using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Grade
    {
        public int StudentId { get; }
        public int SubjectId { get; }
        public double Score { get; }
        public string Appreciation { get; }

        public Grade(int studentId, int subjectId, double score, string appreciation)
        {
            this.StudentId = studentId;
            this.SubjectId = subjectId;
            this.Score = score;
            this.Appreciation = appreciation;
        }

        public Student GetStudent()
        {
            List<Student> students = ListsManagement.GetStudents();

            foreach (Student el in students)
            {
                if (el.Id == this.StudentId)
                {
                    return el;
                }
            }

            ColorSetter.ErrorColor();
            Console.WriteLine("Aucun étudiant ne correspond à cette note.");
            ColorSetter.Reset();
            Log.Error("No match found between the grade et the students list.");
            return null;
        }

        public Subject GetSubject()
        {
            List<Subject> subjects = ListsManagement.GetSubjects();

            foreach (Subject el in subjects)
            {
                if (el.Id == this.SubjectId)
                {
                    return el;
                }
            }

            ColorSetter.ErrorColor();
            Console.WriteLine("Aucun cours ne correspond à cette note.");
            ColorSetter.Reset();
            Log.Error("No match found between the grade et the subjects list.");
            return null;
        }
    }
}
