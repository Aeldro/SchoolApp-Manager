using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;

namespace Project1DotNet
{
    internal static class ListsManagement
    {
        private static IDatabase database { get; } = new Database();

        // Méthodes "GET ALL"
        public static List<Student> GetStudents()
        {
            return database.Students;
        }

        public static List<Subject> GetSubjects()
        {
            return database.Subjects;
        }

        public static List<Grade> GetGrades()
        {
            return database.Grades;
        }

        public static List<Promotion> GetPromotions()
        {
            return database.Promotions;
        }

        // Méthodes "GET FROM LIST"
        public static Student GetFromList(int id, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (student.Id == id)
                {
                    return student;
                }
            }
            Console.WriteLine(@"/!\ Aucun étudiant ne correspond à cet identifiant.");
            return null;
        }

        public static Subject GetFromList(int id, List<Subject> subjects)
        {
            foreach (Subject subject in subjects)
            {
                if (subject.Id == id)
                {
                    return subject;
                }
            }
            Console.WriteLine(@"/!\ Aucun cours ne correspond à cet identifiant.");
            return null;
        }

        public static List<Grade> GetFromList(Student student, List<Grade> grades)
        {
            List<Grade> studentGrades = new List<Grade>();
            foreach (Grade grade in grades)
            {
                if (grade.StudentId == student.Id)
                {
                    studentGrades.Add(grade);
                }
            }
            return studentGrades;
        }

        public static List<Grade> GetFromList(Subject subject, List<Grade> grades)
        {
            List<Grade> subjectGrades = new List<Grade>();
            foreach (Grade grade in grades)
            {
                if (grade.SubjectId == subject.Id)
                {
                    subjectGrades.Add(grade);
                }
            }
            return subjectGrades;
        }

        // Méthodes "ADD"
        public static void AddElement(Student student, List<Student> students)
        {
            try
            {
                students.Add(student);
                FilesManagement.WriteFile(students);
                Console.WriteLine($"L'étudiant {student.Id} {student.FirstName} {student.LastName} a bien été ajouté.");
                Log.Information($"Student {student.Id} {student.FirstName} {student.LastName} added to database.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"/!\ Une erreur est survenue lors de l'ajout de l'étudiant {student.Id} {student.FirstName} {student.LastName} à la base de données.");
                Console.WriteLine(ex.ToString());
                Log.Error(ex, $"Failed to add the student {student.Id} {student.FirstName} {student.LastName} to database.");
            }
        }
        public static void AddElement(Subject subject, List<Subject> subjects)
        {
            try
            {
                subjects.Add(subject);
                FilesManagement.WriteFile(subjects);
                Console.WriteLine($"Le cours {subject.Name} a bien été ajouté.");
                Log.Information($"Subject {subject.Name} added to database.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($@"/!\ Une erreur est survenue lors de l'ajout du cours {subject.Name} à la base de données.");
                Console.WriteLine(ex.ToString());
                Log.Error(ex, $"Failed to add the subject {subject.Name} to database.");
            }
        }

        public static void AddElement(Promotion promotion, List<Promotion> promotions)
        {
            try
            {
                promotions.Add(promotion);
                database.Promotions.Add(promotion);
                Console.WriteLine($"La promotion {promotion.Name} a bien été créée.");
                Log.Information($"Promotion {promotion.Name} created.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"/!\ Une erreur est survenue lors de la création de la promotion {promotion.Name}.");
                Console.WriteLine(ex.ToString());
                Log.Error(ex, $"Failed to create the promotion {promotion.Name}.");
            }
        }

        public static void AddElement(Student student, Subject subject, double score, string appreciation, List<Grade> grades)
        {
            try
            {
                grades.Add(new Grade(student.Id, subject.Id, score, appreciation));
                FilesManagement.WriteFile(grades);
                Console.WriteLine($"Un {score}/20 en {subject.Name} a été ajoutée à {student.FirstName} {student.LastName}.");
                Log.Information($"{score}/20 added to database in {subject.Name} for the student {student.Id} {student.FirstName} {student.LastName}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"/!\ Une erreur est survenue lors de l'ajout de la note à la base de données.");
                Console.WriteLine(ex.ToString());
                Log.Error(ex, $"Failed to add the grade to database. Grade: {score}/20");

            }
        }

        // Méthodes "DELETE"
        public static void DeleteElement(Subject subject, List<Subject> subjects, List<Grade> grades)
        {
            try
            {
                grades.RemoveAll(el => el.SubjectId == subject.Id);
                FilesManagement.WriteFile(grades);
                Log.Information($"The grades associated to the subject have been removed from database. Subject : {subject.Id} {subject.Name}.");

                subjects.RemoveAll(el => el.Id == subject.Id);
                FilesManagement.WriteFile(subjects);
                Log.Information($"The subject has been removed from database. Subject: {subject.Id} {subject.Name}.");

                Console.WriteLine($"Le cours {subject.Name} et ses notes associées ont bien été supprimés.");

            }
            catch (Exception ex)
            {
                Console.WriteLine(@"/!\ Une erreur est survenue lors de la suppression du cours ou des notes associées.");
                Console.WriteLine(ex.ToString());
                Log.Error(ex, $"Failed to delete the subject from database. Subject ID: {subject.Id} {subject.Name}.");
            }
        }

    }
}
