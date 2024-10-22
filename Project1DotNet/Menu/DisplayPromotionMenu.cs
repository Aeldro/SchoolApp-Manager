﻿using Project1DotNet.Menu;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.menu
{
    internal class DisplayPromotionMenu
    {
        // Menu promotions (3)
        public int PromotionMenu(int menu)
        {
            Log.Information($"User accesses the promotions menu. Code menu: {menu}.");

            Console.WriteLine("");
            Console.WriteLine("(Promotions) Choisissez une action à effectuer.");
            Console.WriteLine("1: Afficher les promotions");
            Console.WriteLine("2: Afficher les élèves d'une promotion");
            Console.WriteLine("3: Afficher la moyenne d'une promotion");
            Console.WriteLine("4: Revenir au menu principal");
            Console.WriteLine("5: Quitter l'application");

            int userInput = UserInputsValidation.MenuInput(menu, new List<int> { 1, 2, 3, 4, 5 });
            switch (userInput)
            {
                case 1:
                    List<Promotion> promotions = ListsManagement.GetPromotions();
                    DisplayElement.ShowAll(promotions);
                    return menu;
                case 2:
                    return MenuConst.STUDENTS_PROMOTION_MENU;
                case 3:
                    return MenuConst.AVERAGE_PROMOTION_MENU;
                case 4:
                    return MenuConst.MAIN_MENU;
                case 5:
                    return MenuConst.EXIT_APP;
                default:
                    DisplayIncorrectInput.IncorrectMenu();
                    return menu;
            }
        }

        // Consulter les élèves d'une promotion (30)
        public int StudentPromotionMenu(int menu)
        {
            Log.Information($"User accesses the menu to consult the students from a specific promotion. Code menu: {menu}.");

            List<Promotion> promotions = ListsManagement.GetPromotions();

            // On vérifie que la base de données contienne au moins une promotion
            if (promotions.Count == 0)
            {
                Console.WriteLine("");
                ColorSetter.WriteLine(@"/!\ La base de données ne contient aucune promotion.", ColorSetter.Error);
                return MenuConst.PROMOTION_MENU;
            }

            DisplayElement.ShowAll(promotions);

            Console.WriteLine("");
            Console.WriteLine("Entrez un numéro de promotion.");
            int id = UserInputsValidation.IdInput(menu, promotions);

            Promotion promotion = ListsManagement.GetFromList(id, promotions);

            List<Student> students = promotion.GetStudents();
            DisplayElement.ShowAll(students);

            return MenuConst.PROMOTION_MENU;
        }

        // Consulter les moyennes d'une promotion (31)
        public int AveragePromotionMenu(int menu)
        {
            Log.Information($"User accesses the menu to consult the average from a specific promotion. Code menu: {menu}.");

            List<Promotion> promotions = ListsManagement.GetPromotions();

            // On vérifie que la base de données contienne au moins une promotion
            if (promotions.Count == 0)
            {
                Console.WriteLine("");
                ColorSetter.WriteLine(@"/!\ La base de données ne contient aucune promotion.", ColorSetter.Error);
                return MenuConst.PROMOTION_MENU;
            }

            DisplayElement.ShowAll(promotions);

            Console.WriteLine("");
            Console.WriteLine("Entrez un numéro de promotion.");
            int id = UserInputsValidation.IdInput(menu, promotions);

            Promotion promotion = ListsManagement.GetFromList(id, promotions);
            DisplayElement.ShowAverage(promotion);

            return MenuConst.PROMOTION_MENU;
        }

        // Ajouter une promotion (32) (non utilisée pour l'instant)
        public int AddPromotionMenu(int menu)
        {
            Log.Information($"User accesses the menu to add a promotion. Code menu: {menu}.");

            List<Promotion> promotions = ListsManagement.GetPromotions();

            Console.WriteLine("");
            Console.WriteLine("Entrez un nom pour la nouvelle promotion.");
            string name = UserInputsValidation.NameInput(menu);
            Log.Information($"User entered a name for a new promotion. Code menu: {menu}.");
            Promotion promotion = new Promotion(Generate.GenerateId(promotions), name);
            ListsManagement.AddElement(promotion, promotions);

            return MenuConst.PROMOTION_MENU;
        }

    }
}
