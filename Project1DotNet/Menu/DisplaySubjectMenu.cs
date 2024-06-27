using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.menu
{
    internal class DisplaySubjectMenu
    {
        // Menu cours (2)
        public int SubjectMenu(int menu)
        {
            Log.Information($"User accesses the subjects menu. Code menu: {menu}.");
            Console.WriteLine("____________________");
            Console.WriteLine("(Cours) Choisissez une action à effectuer.");
            Console.WriteLine("1: Afficher les cours");
            Console.WriteLine("2: Ajouter un nouveau cours");
            Console.WriteLine("3: Supprimer un cours");
            Console.WriteLine("4: Revenir au menu principal");
            Console.WriteLine("5: Quitter l'application");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        List<Subject> subjects = ListsManagement.GetSubjects();
                        DisplayElement.ShowAll(subjects);
                        return menu;
                    case 2:
                        return MenuConst.ADD_GRADE_MENU;
                    case 3:
                        return MenuConst.DELETE_SUBJECT_MENU;
                    case 4:
                        return MenuConst.MAIN_MENU;
                    case 5:
                        return MenuConst.EXIT_APP;
                    default:
                        IncorrectInput.IncorrectMenu();
                        return menu;
                }
            }
            catch (Exception ex)
            {
                IncorrectInput.IncorrectMenu();
                return menu;
            }
        }

        // Ajouter un cours (20)
        public int AddSubjectMenu(int menu)
        {
            Log.Information($"User accesses the menu to add a subject. Code menu: {menu}.");
            Console.WriteLine("Choisissez un nom pour le nouveau cours.");
            Log.Information($"User is asked for a subject name. Code menu: {menu}.");
            string nameInput = Console.ReadLine();
            Log.Information($"User entered a subject name: {nameInput}. Code menu: {menu}.");

            List<Subject> subjects = ListsManagement.GetSubjects();
            Subject subject = new Subject(Generate.GenerateId(subjects), nameInput);
            ListsManagement.AddElement(subject, subjects);
            return MenuConst.SUBJECT_MENU;
        }

        // Supprimer un cours (21)
        public int DeleteSubjectMenu(int menu)
        {
            Log.Information($"User accesses the menu to delete a subject. Code menu: {menu}.");

            List<Subject> subjects = ListsManagement.GetSubjects();
            DisplayElement.ShowAll(subjects);

            Console.WriteLine("Entrez l'identifiant du cours à supprimer.");
            try
            {
                Log.Information($"User is asked for subject ID to delete a subject. Code menu: {menu}.");
                int idSubjectInput = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a subject ID to delete a subject: {idSubjectInput}. Code menu: {menu}.");
                
                Console.WriteLine($"La suppression de ce cours entraînement la suppression de toutes les notes qui lui sont associées. Confirmer? (y/n)");
                Log.Information($"User is asked to validate the subject removal. ID to remove: {idSubjectInput}. Code menu: {menu}.");
                string confirmInput = Console.ReadLine();
                Log.Information($"User entered a validation answer: {confirmInput}. Code menu: {menu}.");

                if (confirmInput != "y" && confirmInput != "n")
                {
                    Log.Error($"The user entered a wront validation character: {confirmInput}. y or n expected. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ La confirmation a échouée.");
                    return menu;
                }
                else if (confirmInput == "n")
                {
                    Log.Information($"User canceled the subject removal: {confirmInput}. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ La suppression du cours a été annulée.");
                    return MenuConst.SUBJECT_MENU;
                }

                Subject subject = ListsManagement.GetFromList(idSubjectInput, subjects);
                List<Grade> grades = ListsManagement.GetGrades();
                ListsManagement.DeleteElement(subject, subjects, grades);
                return MenuConst.SUBJECT_MENU;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong. Seems to failed converting string to int. Code menu: {menu}.");
                IncorrectInput.IncorrectId();
                return menu;
            }
        }
    }
}
