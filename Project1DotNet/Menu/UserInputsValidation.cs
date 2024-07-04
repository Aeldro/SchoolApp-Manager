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

        public static string NameInput<T>(int menu, IEnumerable<T> enumList)
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
                //Vérifie que le nom n'existe pas déjà si la méthode est appelée avec un paramètre énumerable
                if (enumList is List<Promotion> promotionsList)
                {
                    List<Promotion> promotions = ListsManagement.GetPromotions();
                    if (promotionsList.Any(el => el.Name == name))
                    {
                        IncorrectInput.NameAlreadyExists();
                        continue;
                    }
                }
                else if (enumList is List<Subject> subjectsList)
                {
                    List<Promotion> promotions = ListsManagement.GetPromotions();
                    if (subjectsList.Any(el => el.Name == name))
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

        public static int MenuInput(int menu, List<int> validInputs)
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

        public static int IdInput<T>(int menu, IEnumerable<T> enumList)
        {
            while (true)
            {
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    Log.Information($"User entered an ID: {id}. Code menu: {menu}.");
                    if (enumList is List<Student> studentsList && studentsList.Any(el => el.Id == id)) return id;
                    else if (enumList is List<Subject> subjectsList && subjectsList.Any(el => el.Id == id)) return id;
                    else if (enumList is List<Promotion> promotionsList && promotionsList.Any(el => el.Id == id)) return id;
                    else
                    {
                        IncorrectInput.IncorrectId();
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectId();
                    Log.Error(ex, $"The user entered a wrong student ID. Seems to failed converting string to int. Code menu: {menu}.");
                    continue;
                }
            }
        }

        public static double GradeInput(int menu)
        {
            while (true)
            {
                try
                {
                    double score = Convert.ToDouble(Console.ReadLine());
                    if (score < 0 || score > 20)
                    {
                        IncorrectInput.IncorrectScore();
                        Log.Error($"The user entered a wrong score. Must be between 0 and 20. Code menu: {menu}.");
                        continue;
                    }
                    else return score;
                }
                catch (Exception ex)
                {
                    IncorrectInput.IncorrectScore();
                    Log.Error(ex, $"The user entered a wrong score. Seems to failed converting string to double. Code menu: {menu}.");
                    continue;
                }
            }
        }

        public static string ValidationInput(int menu)
        {
            while (true)
            {
                string validation = Console.ReadLine();
                Log.Information($"User entered a validation: {validation}. Code menu: {menu}.");

                if (validation == "y" || validation == "n") return validation;
                else
                {
                    IncorrectInput.IncorrectValidation();
                    Log.Error($"The user entered a wrong validation. Must be y or n. Code menu: {menu}.");
                    continue;
                }
            }
        }
    }
}
