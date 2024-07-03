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
            Console.WriteLine("____________________");
            Console.WriteLine("(Promotions) Choisissez une action à effectuer.");
            Console.WriteLine("1: Afficher les promotions");
            Console.WriteLine("2: Afficher les élèves d'une promotion");
            Console.WriteLine("3: Afficher la moyenne d'une promotion");
            Console.WriteLine("4: Revenir au menu principal");
            Console.WriteLine("5: Quitter l'application");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
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
