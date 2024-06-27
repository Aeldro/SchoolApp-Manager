using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Project1DotNet.Menu
{
    internal class DisplayMainMenu
    {
        // Menu de départ (0)
        public int StartMenu(int menu)
        {
            Log.Information($"User accesses the starting menu. Code menu: {menu}.");
            Console.WriteLine("____________________");
            Console.WriteLine("Choisissez une entrée :");
            Console.WriteLine("1: Élèves");
            Console.WriteLine("2: Cours");
            Console.WriteLine("3: Quitter l'application");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        return MenuConst.STUDENT_MENU;
                    case 2:
                        return MenuConst.SUBJECT_MENU;
                    case 3:
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

        
    }
}


