using Project1DotNet.Menu;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project1DotNet.menu
{
    internal class DisplayMainMenu
    {
        // Menu de départ (0)
        public int StartMenu(int menu)
        {
            Log.Information($"User accesses the starting menu. Code menu: {menu}.");

            Console.WriteLine("");
            Console.WriteLine("Choisissez une entrée :");
            Console.WriteLine("1: Élèves");
            Console.WriteLine("2: Cours");
            Console.WriteLine("3: Promotions");
            Console.WriteLine("4: Quitter l'application");

            int userInput = UserInputsValidation.MenuInput(menu, new List<int> { 1, 2, 3, 4 });
            switch (userInput)
            {
                case 1:
                    return MenuConst.STUDENT_MENU;
                case 2:
                    return MenuConst.SUBJECT_MENU;
                case 3:
                    return MenuConst.PROMOTION_MENU;
                case 4:
                    return MenuConst.EXIT_APP;
                default:
                    DisplayIncorrectInput.IncorrectMenu();
                    return menu;
            }

        }
    }
}


