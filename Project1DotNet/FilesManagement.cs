using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class FilesManagement
    {
        public const string StudentsPath = @"./../../../students.json";
        public const string SubjectsPath = @"./../../../subjects.json";
        public const string GradesPath = @"./../../../grades.json";

        // Méthodes "WRITEFILE"
        public static void WriteFile(List<Student> Students)
        {
            string json = JsonConvert.SerializeObject(Students, Formatting.Indented);
            File.WriteAllText(StudentsPath, json);

        }
        public static void WriteFile(List<Subject> Subjects)
        {
            string json = JsonConvert.SerializeObject(Subjects, Formatting.Indented);
            File.WriteAllText(SubjectsPath, json);

        }
        public static void WriteFile(List<Grade> Grades)
        {
            string json = JsonConvert.SerializeObject(Grades, Formatting.Indented);
            File.WriteAllText(GradesPath, json);

        }

        // Méthodes "READFILE"
        public static List<Student> ReadFile(List<Student> Students)
        {
            try
            {
                string jsonContent = File.ReadAllText(StudentsPath);
                Students = JsonConvert.DeserializeObject<List<Student>>(jsonContent);
                return Students;
            }
            catch (Exception ex)
            {
                return new List<Student>();
            }
        }

        public static List<Subject> ReadFile(List<Subject> Subjects)
        {
            try
            {
                string jsonContent = File.ReadAllText(SubjectsPath);
                Subjects = JsonConvert.DeserializeObject<List<Subject>>(jsonContent);
                return Subjects;
            }
            catch (Exception ex)
            {
                return new List<Subject>();
            }
        }

        public static List<Grade> ReadFile(List<Grade> Grades)
        {
            try
            {
                string jsonContent = File.ReadAllText(GradesPath);
                Grades = JsonConvert.DeserializeObject<List<Grade>>(jsonContent);
                return Grades;
            }
            catch (Exception ex)
            {
                return new List<Grade>();
            }
        }
    }
}
