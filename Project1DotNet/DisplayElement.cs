using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class DisplayElement
    {
        // Méthodes "SHOW"
        public static void ShowAll(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Aucun élève n'est enregistré.");
            }
            else
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Liste des élèves :");
                foreach (Student student in students)
                {
                    Console.Write(student.Id + " ");
                    Console.Write(student.FirstName + " ");
                    Console.WriteLine(student.LastName);
                }
            }
            Log.Information("Showed all the students.");
        }

        public static void ShowAll(List<Subject> subjects)
        {
            if (subjects.Count == 0)
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Aucun cours n'est enregistré.");
            }
            else
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Liste des cours :");
                foreach (Subject el in subjects)
                {
                    Console.Write(el.Id + " ");
                    Console.WriteLine(el.Name);
                }
            }
            Log.Information("Showed all the subjects.");
        }

        public static void ShowAll(List<Promotion> promotions)
        {
            if (promotions.Count == 0)
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Aucune promotion n'est enregistrée.");
            }
            else
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Liste des promotions :");
                foreach (Promotion el in promotions)
                {
                    Console.Write(el.Id + " ");
                    Console.WriteLine(el.Name);
                }
            }
            Log.Information("Showed all the promotions.");
        }

        public static void Show(Student student)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Informations sur l'élève :");
            Console.WriteLine("");
            Console.Write("Identifiant       ");
            Console.WriteLine($": {student.Id}");
            Console.Write("Prénom            ");
            Console.WriteLine($": {student.FirstName}");
            Console.Write("Nom               ");
            Console.WriteLine($": {student.LastName}");
            Console.Write("Date de naissance ");
            Console.WriteLine($": {student.Birthday.ToString("dd/MM/yyyy")}");
            Console.Write("Promotion         ");
            Console.WriteLine($": {student.Promotion.Name}");
            Console.WriteLine("");
            Console.WriteLine("Résultats scolaires :");
            Console.WriteLine("");
            ShowGrades(student);
            ShowAverage(student);

            Console.WriteLine("--------------------");
            Log.Information($"Showed the student {student.Id} {student.FirstName} {student.LastName}.");
        }

        public static void ShowGrades(Student student)
        {
            if (student.GetGrades().Any())
            {
                foreach (Grade grade in student.GetGrades())
                {
                    Subject currentSubject = grade.GetSubject();
                    Console.Write("     Cours            ");
                    Console.WriteLine($": {currentSubject.Name}");
                    Console.Write("     Note             ");
                    Console.WriteLine($": {grade.Score}/20");
                    Console.Write("     Appréciation     ");
                    Console.WriteLine($": {grade.Appreciation}");
                    Console.WriteLine("");
                }
            }
            else Console.WriteLine("     Cet élève n'a pas encore de note.");
        }

        public static void ShowAverage(Student student)
        {
            if (student.GetGrades().Any())
            {
                Console.Write("     Moyenne          ");
                Console.WriteLine($": {Math.Round(student.GetAverage(), 1)}/20");
            }
        }
    }
}
