using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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
            database.AddStudent(firstName, lastName, birthday);
            return 1;
        }

        // Consulter un élève (11)
        public int ConsultStudentMenu(int menu, Database database)
        {
            database.ShowStudents();
            Console.WriteLine("____________________");
            Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant.");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                database.ShowStudent(id, database);
                return 1;
            }
            catch (Exception ex)
            {
                IncorrectId();
                return menu;
            }
        }

        // Ajouter une note à un élève (12)
        public int AddGradeMenu(int menu, Database database)
        {
            try
            {
                // On demande l'ID de l'étudiant
                database.ShowStudents();
                Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant à qui ajouter une note.");
                int idStudent = Convert.ToInt32(Console.ReadLine());
                if (database.GetStudent(idStudent) == null) return 1;
                Student currentStudent = database.GetStudent(idStudent);

                // On demande l'ID du cours
                database.ShowSubjects();
                Console.WriteLine($"({currentStudent.FirstName} {currentStudent.LastName}) Entrez le numéro d'identifiant du cours.");
                int idSubject = Convert.ToInt32(Console.ReadLine());
                if (database.GetSubject(idSubject) == null) return 1;

                // On demande la note
                Console.WriteLine($"({currentStudent.FirstName} {currentStudent.LastName}) Entrez une note sur 20.");
                double score = Convert.ToDouble(Console.ReadLine());
                if (score > 20 || score < 0)
                {
                    IncorrectScore();
                    return menu;
                }

                // On demande l'appréciation
                Console.WriteLine($"({currentStudent.FirstName} {currentStudent.LastName}) Entrez une appréciation. (facultatif)");
                string appreciation = "";
                appreciation = Console.ReadLine();

                // On demande de valider
                Console.WriteLine($"Un {score}/20 en {database.GetSubject(idSubject).Name} sera ajouté à {currentStudent.FirstName} {currentStudent.LastName}. Confirmer? (y/n)");
                string confirm = Console.ReadLine();
                if (confirm != "y" && confirm != "n")
                {
                    Console.WriteLine(@"/!\ La confirmation a échouée.");
                    return menu;
                }
                else if (confirm == "n")
                {
                    Console.WriteLine(@"/!\ Attribution de la note annulée.");
                    return 1;
                }

                database.AddGrade(idStudent, idSubject, score, appreciation);
                return 1;

            }
            catch (Exception ex)
            {
                IncorrectGlobal();
                return menu;
            }
        }

        // Ajouter un cours (20)
        public int AddSubjectMenu(int menu, Database database)
        {
            Console.WriteLine("Choisissez un nom pour le nouveau cours.");
            string name = Console.ReadLine();
            database.AddSubject(name);
            return 2;
        }

        // Supprimer un cours (21)
        public int DeleteSubjectMenu(int menu, Database database)
        {
            Console.WriteLine("Entrez l'identifiant du cours à supprimer.");
            try
            {
                int idSubject = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"La suppression de ce cours entraînement la suppression de toutes les notes qui lui sont associées. Confirmer? (y/n)");
                string confirm = Console.ReadLine();
                if (confirm != "y" && confirm != "n")
                {
                    Console.WriteLine(@"/!\ La confirmation a échouée.");
                    return menu;
                }
                else if (confirm == "n")
                {
                    Console.WriteLine(@"/!\ La suppression du cours a été annulée.");
                    return 2;
                }
                database.DeleteSubject(idSubject);
                return 2;
            }
            catch (Exception ex)
            {
                IncorrectId();
                return menu;
            }
        }


        // Fonction de saisie utilisateur incorrecte
        public void IncorrectInput()
        {
            Console.WriteLine("____________________");
            Console.WriteLine(@"/!\ Saisie incorrecte. Veuillez utiliser le numéro affiché devant votre sélection.");
        }

        public void IncorrectBirthday()
        {
            Console.WriteLine("____________________");
            Console.WriteLine(@"/!\ La date de naissance est incorrecte. Elle doit suivre le schéma suivant : DD/MM/YYYY.");
        }

        public void IncorrectId()
        {
            Console.WriteLine("____________________");
            Console.WriteLine(@"/!\ L'identifiant doit être un nombre existant.");
        }

        public void IncorrectScore()
        {
            Console.WriteLine("____________________");
            Console.WriteLine(@"/!\ La note doit être comprise entre 0 et 20.");
        }
        public void IncorrectGlobal()
        {
            Console.WriteLine("____________________");
            Console.WriteLine(@"/!\ Entrée incorrecte.");
        }
    }
}


