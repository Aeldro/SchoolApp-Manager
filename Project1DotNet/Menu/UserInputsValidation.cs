using Project1DotNet.menu;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.Menu
{
    internal static class UserInputsValidation
    {
        public static string NameInput(int menu)
        {
            return NameInput(menu, new List<int>());
        }

        public static string NameInput<T>(int menu, IEnumerable<T> list)
        {
            while (true)
            {
                string name = Console.ReadLine();
                Log.Information($"User entered a name: {name}. Code menu: {menu}.");
                //Vérifie que la longueur du nom est de 1 caractère minimum
                if (name.Length <= 1)
                {
                    IncorrectInput.InputTooShort();
                    continue;
                }
                //Vérifie que le nom n'existe pas déjà si la méthode est appelée avec un second énumerable
                if (list is List<Promotion> promoList)
                {
                    List<Promotion> promotions = ListsManagement.GetPromotions();
                    if (promoList.Any(el => el.Name == name))
                    {
                        IncorrectInput.NameAlreadyExists();
                        continue;
                    }
                }
                return name;
            }
        }

        public static DateTime BirthdayInput(int menu)
        {
            while (true)
            {
                string stringedBirthday = Console.ReadLine();
                string dateFormat = "dd/MM/yyyy";
                Log.Information($"User entered a birthday: {stringedBirthday}. Code menu: {menu}.");

                DateTime birthday;
                try
                {
                    birthday = DateTime.ParseExact(stringedBirthday, dateFormat, null);
                    Log.Information($"The birthday is valid: {birthday}. Code menu: {menu}.");
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectBirthday();
                    Log.Error(ex, $"The birthday is not valid: {stringedBirthday}. Seems to failed converting string to DateTime. Code menu: {menu}.");
                    continue;
                }
                return birthday;
            }
        }

        public static int MenuInput(List<int> validInputs)
        {
            while (true)
            {
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (validInputs.Contains(choice)) return choice;
                    else
                    {
                        IncorrectInput.IncorrectMenu();
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectMenu();
                    continue;
                }
            }
        }

        public static int IdInput(int menu, List<Promotion> list)
        {
            while (true)
            {
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    Log.Information($"User entered an ID: {id}. Code menu: {menu}.");
                    if (list.Any(el => el.Id == id)) return id;
                    else
                    {
                        IncorrectInput.IncorrectId();
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectId();
                    continue;
                }
            }
        }

        public static Promotion StudentPromotionInput(int menu)
        {
            List<Promotion> promotions = ListsManagement.GetPromotions();
            DisplayElement.ShowAll(promotions);

            Console.WriteLine("Entrez le numéro de promotion de l'élève. (+ pour ajouter une nouvelle promotion)");
            string stringedPromoId = Console.ReadLine();
            Log.Information($"User entered an ID: {stringedPromoId}. Code menu: {menu}.");
            int promoId;
            Promotion promotion;
            if (stringedPromoId == "+")
            {
                try { promotion = PromotionCreation(menu); }
                catch (Exception ex)
                {
                    IncorrectInput.NameAlreadyExists();
                    Log.Error(ex, $"The user entered a name that already exists. Code menu: {menu}.");
                    throw;
                }
            }
            else
            {
                try
                {
                    promoId = Convert.ToInt32(stringedPromoId);
                    promotion = ListsManagement.GetFromList(promoId, promotions);
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectId();
                    Log.Error(ex, $"The user entered a wrong promotion ID. Seems to failed converting string to int. Code menu: {menu}.");
                    throw;
                }
            }

            return promotion;
        }

        public static Promotion PromotionCreation(int menu)
        {
            List<Promotion> promotions = ListsManagement.GetPromotions();

            Console.WriteLine("Entrez un nom pour la nouvelle promotion.");
            string promoName = Console.ReadLine();
            Log.Information($"User entered a name for a new promotion: {promoName}. Code menu: {menu}.");

            if (promotions.Any(el => el.Name == promoName)) throw new Exception("This name already exists.");

            Promotion promotion = new Promotion(Generate.GenerateId(promotions), promoName);
            ListsManagement.AddElement(promotion, promotions);

            return promotion;
        }

        public static Promotion PromotionInput(int menu)
        {
            List<Promotion> promotions = ListsManagement.GetPromotions();
            DisplayElement.ShowAll(promotions);

            Console.WriteLine("Entrez un numéro de promotion.");
            int idPromo;
            Promotion promotion;
            try
            {
                idPromo = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a promotion ID: {idPromo}. Code menu: {menu}.");
                promotion = ListsManagement.GetFromList(idPromo, promotions);
                return promotion;
            }
            catch (Exception ex)
            {
                IncorrectInput.IncorrectId();
                Log.Error(ex, $"The user entered a wrong promotion ID. Seems to failed converting string to int. Code menu: {menu}.");
                throw;
            }
        }
    }
}
