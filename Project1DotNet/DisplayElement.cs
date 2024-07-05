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
                Console.WriteLine("");
                ColorSetter.WriteLine("Aucun élève répertorié.", ColorSetter.Warning);
            }
            else
            {
                Console.WriteLine("");
                ColorSetter.WriteLine("Liste des élèves :", ColorSetter.Information);
                foreach (Student student in students)
                {
                    ColorSetter.Write(student.Id + " ", ColorSetter.Information);
                    ColorSetter.Write(student.FirstName + " ", ColorSetter.Information);
                    ColorSetter.WriteLine(student.LastName, ColorSetter.Information);
                }
            }
            Log.Information("Showed all the students.");
        }

        public static void ShowAll(List<Subject> subjects)
        {
            if (subjects.Count == 0)
            {
                Console.WriteLine("");
                ColorSetter.WriteLine("Aucun cours répertorié.", ColorSetter.Warning);
            }
            else
            {
                Console.WriteLine("");
                ColorSetter.WriteLine("Liste des cours :", ColorSetter.Information);
                foreach (Subject el in subjects)
                {
                    ColorSetter.Write(el.Id + " ", ColorSetter.Information);
                    ColorSetter.WriteLine(el.Name, ColorSetter.Information);
                }
            }
            Log.Information("Showed all the subjects.");
        }

        public static void ShowAll(List<Promotion> promotions)
        {
            if (promotions.Count == 0)
            {
                Console.WriteLine("");
                ColorSetter.WriteLine("Aucune promotion répertoriée.", ColorSetter.Warning);
            }
            else
            {
                Console.WriteLine("");
                ColorSetter.WriteLine("Liste des promotions :", ColorSetter.Information);
                foreach (Promotion el in promotions)
                {
                    ColorSetter.Write(el.Id + " ", ColorSetter.Information);
                    ColorSetter.WriteLine(el.Name, ColorSetter.Information);
                }
            }
            Log.Information("Showed all the promotions.");
        }

        public static void Show(Student student)
        {
            Console.WriteLine("");
            ColorSetter.WriteLine("--------------------", ColorSetter.Information);
            ColorSetter.WriteLine("Informations sur l'élève :", ColorSetter.Information);
            Console.WriteLine("");
            ColorSetter.Write("Identifiant       ", ColorSetter.Information);
            ColorSetter.WriteLine($": {student.Id}", ColorSetter.Information);
            ColorSetter.Write("Prénom            ", ColorSetter.Information);
            ColorSetter.WriteLine($": {student.FirstName}", ColorSetter.Information);
            ColorSetter.Write("Nom               ", ColorSetter.Information);
            ColorSetter.WriteLine($": {student.LastName}", ColorSetter.Information);
            ColorSetter.Write("Date de naissance ", ColorSetter.Information);
            ColorSetter.WriteLine($": {student.Birthday.ToString("dd/MM/yyyy")}", ColorSetter.Information);
            ColorSetter.Write("Promotion         ", ColorSetter.Information);
            ColorSetter.WriteLine($": {student.Promotion.Name}", ColorSetter.Information);
            Console.WriteLine("");
            ColorSetter.WriteLine("Résultats scolaires :", ColorSetter.Information);
            ShowGrades(student);
            ShowAverage(student);
            ColorSetter.WriteLine("--------------------", ColorSetter.Information);

            Log.Information($"Showed the student {student.Id} {student.FirstName} {student.LastName}.");
        }

        public static void ShowGrades(Student student)
        {
            if (student.GetGrades().Any())
            {
                foreach (Grade grade in student.GetGrades())
                {
                    Subject currentSubject = grade.GetSubject();
                    ColorSetter.Write("     Cours            ", ColorSetter.Information);
                    ColorSetter.WriteLine($": {currentSubject.Name}", ColorSetter.Information);
                    ColorSetter.Write("     Note             ", ColorSetter.Information);
                    ColorSetter.WriteLine($": {grade.Score}/20", ColorSetter.Information);
                    ColorSetter.Write("     Appréciation     ", ColorSetter.Information);
                    ColorSetter.WriteLine($": {grade.Appreciation}", ColorSetter.Information);
                    Console.WriteLine("");
                }
            }
            else ColorSetter.WriteLine("     Cet élève n'a pas encore de note.", ColorSetter.Warning);
        }

        public static void ShowAverage(Student student)
        {
            if (student.GetGrades().Any())
            {
                ColorSetter.Write("     Moyenne          ", ColorSetter.Information);
                ColorSetter.WriteLine($": {Math.Round(student.GetAverage(), 1)}/20", ColorSetter.Information);
            }
        }

        public static void ShowAverage(Promotion promotion)
        {
            List<Subject> subjects = ListsManagement.GetSubjects();

            Console.WriteLine("");
            ColorSetter.WriteLine("--------------------", ColorSetter.Information);
            ColorSetter.WriteLine($"Moyennes des élèves de la promotion {promotion.Name} :", ColorSetter.Information);
            Console.WriteLine("");
            foreach (Subject subject in subjects)
            {
                ColorSetter.Write($"{subject.Name} :\t\t", ColorSetter.Information);
                if (subject.GetGrades(promotion).Any()) ColorSetter.WriteLine($"{subject.GetAverage(promotion)}/20", ColorSetter.Information);
                else ColorSetter.WriteLine("Aucune moyenne pour ce cours.", ColorSetter.Warning);
            }
            ColorSetter.WriteLine("--------------------", ColorSetter.Information);
        }
    }
}
