﻿using Project1DotNet.Menu;
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

            Console.WriteLine("");
            Console.WriteLine("(Cours) Choisissez une action à effectuer.");
            Console.WriteLine("1: Afficher les cours");
            Console.WriteLine("2: Ajouter un nouveau cours");
            Console.WriteLine("3: Supprimer un cours");
            Console.WriteLine("4: Revenir au menu principal");
            Console.WriteLine("5: Quitter l'application");

            int userInput = UserInputsValidation.MenuInput(menu, new List<int> { 1, 2, 3, 4, 5 });
            switch (userInput)
            {
                case 1:
                    List<Subject> subjects = ListsManagement.GetSubjects();
                    DisplayElement.ShowAll(subjects);
                    return menu;
                case 2:
                    return MenuConst.ADD_SUBJECT_MENU;
                case 3:
                    return MenuConst.DELETE_SUBJECT_MENU;
                case 4:
                    return MenuConst.MAIN_MENU;
                case 5:
                    return MenuConst.EXIT_APP;
                default:
                    DisplayIncorrectInput.IncorrectMenu();
                    return menu;
            }
        }

        // Ajouter un cours (20)
        public int AddSubjectMenu(int menu)
        {
            Log.Information($"User accesses the menu to add a subject. Code menu: {menu}.");

            List<Subject> subjects = ListsManagement.GetSubjects();

            Console.WriteLine("");
            Console.WriteLine("Choisissez un nom pour le nouveau cours.");
            Log.Information($"User is asked for a subject name. Code menu: {menu}.");
            string nameInput = UserInputsValidation.NameInput(menu, subjects);
            Log.Information($"User entered a subject name: {nameInput}. Code menu: {menu}.");

            Subject subject = new Subject(Generate.GenerateId(subjects), nameInput);
            ListsManagement.AddElement(subject, subjects);
            return MenuConst.SUBJECT_MENU;
        }

        // Supprimer un cours (21)
        public int DeleteSubjectMenu(int menu)
        {
            Log.Information($"User accesses the menu to delete a subject. Code menu: {menu}.");

            List<Subject> subjects = ListsManagement.GetSubjects();

            // On vérifie que la base de données contienne au moins un cours
            if (subjects.Count == 0)
            {
                Console.WriteLine("");
                ColorSetter.WriteLine(@"/!\ La base de données ne contient aucun cours.", ColorSetter.Error);
                return MenuConst.SUBJECT_MENU;
            }

            DisplayElement.ShowAll(subjects);
            Console.WriteLine("");
            Console.WriteLine("Entrez l'identifiant du cours à supprimer.");

            Log.Information($"User is asked for subject ID to delete a subject. Code menu: {menu}.");
            int idSubjectInput = UserInputsValidation.IdInput(menu, subjects);
            Log.Information($"User entered a subject ID to delete a subject: {idSubjectInput}. Code menu: {menu}.");

            Console.WriteLine("");
            ColorSetter.WriteLine($"La suppression de ce cours entraînement la suppression de toutes les notes qui lui sont associées. Confirmer? (y/n)", ColorSetter.Warning);
            Log.Information($"User is asked to validate the subject removal. ID to remove: {idSubjectInput}. Code menu: {menu}.");
            string confirmInput = UserInputsValidation.ValidationInput(menu);
            Log.Information($"User entered a validation answer: {confirmInput}. Code menu: {menu}.");
            if (confirmInput == "n")
            {
                Log.Information($"User canceled the subject removal: {confirmInput}. Code menu: {menu}.");
                Console.WriteLine("");
                ColorSetter.WriteLine(@"/!\ La suppression du cours a été annulée.", ColorSetter.Information);

                return MenuConst.SUBJECT_MENU;
            }

            Subject subject = ListsManagement.GetFromList(idSubjectInput, subjects);
            List<Grade> grades = ListsManagement.GetGrades();
            ListsManagement.DeleteElement(subject, subjects, grades);

            return MenuConst.SUBJECT_MENU;
        }
    }
}
