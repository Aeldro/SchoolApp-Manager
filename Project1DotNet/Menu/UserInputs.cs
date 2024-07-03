using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.Menu
{
    internal static class UserInputs
    {
        public static string FirstNameInput(int menu)
        {
            Console.WriteLine("Entrez le prénom de l'étudiant.");
            string firstName = Console.ReadLine();
            Log.Information($"User entered a firstname: {firstName}. Code menu: {menu}.");
            return firstName;
        }

        public static string LastNameInput(int menu)
        {
            Console.WriteLine("Entrez le nom de famille de l'étudiant.");
            string lastName = Console.ReadLine().ToUpper();
            Log.Information($"User entered a lastname: {lastName}. Code menu: {menu}.");
            return lastName;
        }

        public static DateTime BirthdayInput(int menu)
        {
            Console.WriteLine("Entrez la date de naissance de l'étudiant. (DD/MM/YYYY)");
            string stringedBirthday = Console.ReadLine();
            string dateFormat = "dd/MM/yyyy";
            Log.Information($"User entered a birthday: {stringedBirthday}. Code menu: {menu}.");

            DateTime birthday;
            // Teste la validité de la date de naissance rentrée par l'utilisateur
            try
            {
                Log.Information($"Validity testing... {stringedBirthday}. Code menu: {menu}.");
                birthday = DateTime.ParseExact(stringedBirthday, dateFormat, null);
                Log.Information($"The birthday is valid: {birthday}. Code menu: {menu}.");
            }
            catch (Exception ex)
            {
                IncorrectInput.IncorrectBirthday();
                Log.Error(ex, $"The birthday is not valid: {stringedBirthday}. Seems to failed converting string to DateTime. Code menu: {menu}.");
                throw;
            }
            return birthday;
        }

        public static Promotion PromotionInput(int menu)
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
                Console.WriteLine("Entrez un nom pour la nouvelle promotion.");
                string promoName = Console.ReadLine();
                Log.Information($"User entered a name for a new promotion: {stringedPromoId}. Code menu: {menu}.");
                promotion = new Promotion(Generate.GenerateId(promotions), promoName);
                ListsManagement.AddElement(promotion, promotions);
            }
            else
            {
                try
                {
                    promoId = Convert.ToInt32(stringedPromoId);
                    promotion = promotions.First(el => el.Id == promoId);
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectId();
                    Log.Error(ex, $"The user entered a wrong student ID. Seems to failed converting string to int. Code menu: {menu}.");
                    throw;
                }
            }

            return promotion;
        }
    }
}
