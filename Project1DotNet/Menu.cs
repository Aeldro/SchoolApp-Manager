using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal class Menu
    {
        // Menu de départ (0)
        public int StartMenu(int menu)
        {
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
                        return 1;
                    case 2:
                        return 2;
                    case 3:
                        return -1;
                    default:
                        IncorrectInput();
                        return menu;
                }
            }
            catch (Exception ex)
            {
                IncorrectInput();
                return menu;
            }
        }

        // Menu élèves (1)
        public int StudentMenu(int menu, Database database)
        {
            Console.WriteLine("____________________");
            Console.WriteLine("(Élèves) Choisissez une action à effectuer.");
            Console.WriteLine("1: Afficher tous les élèves");
            Console.WriteLine("2: Ajouter un nouvel élève");
            Console.WriteLine("3: Consulter un élève");
            Console.WriteLine("4: Ajouter une note à un élève");
            Console.WriteLine("5: Revenir au menu principal");
            Console.WriteLine("6: Quitter l'application");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                switch (userInput)
                {
                    case 1:
                        database.ShowStudents();
                        return menu;
                    case 2:
                        return 10;
                    case 3:
                        return 11;
                    case 4:
                        return 12;
                    case 5:
                        return 0;
                    case 6:
                        return -1;
                    default:
                        IncorrectInput();
                        return menu;
                }
            }
            catch (Exception ex)
            {
                IncorrectInput();
                return menu;
            }
        }

        // Menu cours (2)
        public int SubjectMenu(int menu, Database database)
        {
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
                        database.ShowSubjects();
                        return menu;
                    case 2:
                        return 20;
                    case 3:
                        return 21;
                    case 4:
                        return 0;
                    case 5:
                        return -1;
                    default:
                        IncorrectInput();
                        return menu;
                }
            }
            catch (Exception ex)
            {
                IncorrectInput();
                return menu;
            }
        }

        // Ajouter un élève (10)
        public int AddStudentMenu(int menu, Database database)
        {
            Console.WriteLine("____________________");
            Console.WriteLine("Entrez le prénom de l'étudiant.");
            string firstName = Console.ReadLine();

            Console.WriteLine("Entrez le nom de famille de l'étudiant.");
            string lastName = Console.ReadLine().ToUpper();

            Console.WriteLine("Entrez la date de naissance de l'étudiant. (DD/MM/YYYY)");
            string stringedBirthday = Console.ReadLine();
            string dateFormat = "dd/MM/yyyy";

            // Teste la validité de la date de naissance rentrée par l'utilisateur
            try
            {
                DateTime tryBirthday = DateTime.ParseExact(stringedBirthday, dateFormat, null);
            }
            catch (Exception ex)
            {
                IncorrectBirthday();
                return menu;
            }

            DateTime birthday = DateTime.ParseExact(stringedBirthday, dateFormat, null);
            database.Students.Add(new Student(database.GenerateStudentId(), firstName, lastName, birthday));
            Console.WriteLine($"L'étudiant {firstName} {lastName} a bien été ajouté.");
            return 1;
        }

        public int ConsultStudentMenu(int menu, Database database)
        {
            Console.WriteLine("____________________");
            Console.WriteLine("Entrez le numéro d'identité de l'étudiant.");
            int id = Convert.ToInt32(Console.ReadLine());
            database.ShowStudent(id);
            return 1;
        }


        // Fonction de saisie utilisateur incorrecte
        public void IncorrectInput()
        {
            Console.WriteLine("____________________");
            Console.WriteLine("Saisie incorrecte. Veuillez utiliser le numéro affiché devant votre sélection.");
        }

        public void IncorrectBirthday()
        {
            Console.WriteLine("____________________");
            Console.WriteLine("La date de naissance est incorrecte. Elle doit suivre le schéma suivant : DD/MM/YYYY.");
        }
    }
}


