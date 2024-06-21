using Serilog;
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
            Log.Information($"User accesses the students menu. Code menu: {menu}.");
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
            Log.Information($"User accesses the subjects menu. Code menu: {menu}.");
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
            Log.Information($"User accesses the menu to add a student. Code menu: {menu}.");

            Console.WriteLine("____________________");
            Console.WriteLine("Entrez le prénom de l'étudiant.");
            string firstName = Console.ReadLine();
            Log.Information($"User entered a firstname: {firstName}. Code menu: {menu}.");

            Console.WriteLine("Entrez le nom de famille de l'étudiant.");
            string lastName = Console.ReadLine().ToUpper();
            Log.Information($"User entered a lastname: {lastName}. Code menu: {menu}.");

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
                IncorrectBirthday();
                Log.Error(ex, $"The birthday is not valid: {stringedBirthday}. Seems to failed converting string to DateTime. Code menu: {menu}.");
                return menu;
            }

            database.AddStudent(firstName, lastName, birthday);
            return 1;
        }

        // Consulter un élève (11)
        public int ConsultStudentMenu(int menu, Database database)
        {
            Log.Information($"User accesses the menu to consult a student. Code menu: {menu}.");
            database.ShowStudents();
            Console.WriteLine("____________________");
            Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant.");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a valid student ID: {id}. Code menu: {menu}.");
                database.ShowStudent(id, database);
                return 1;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"The user entered a wrong student ID. Seems to failed converting string to int. Code menu: {menu}.");
                IncorrectId();
                return menu;
            }
        }

        // Ajouter une note à un élève (12)
        public int AddGradeMenu(int menu, Database database)
        {
            Log.Information($"User accesses the menu to give a grade to a student. Code menu: {menu}.");

            try
            {
                // On demande l'ID de l'étudiant
                database.ShowStudents();
                Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant à qui ajouter une note.");
                Log.Information($"User is asked for a student ID. Code menu: {menu}.");
                int idStudent = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a student ID: {idStudent}. Code menu: {menu}.");

                if (database.GetStudent(idStudent) == null) return 1;
                Student currentStudent = database.GetStudent(idStudent);

                // On demande l'ID du cours
                database.ShowSubjects();
                Console.WriteLine($"({currentStudent.FirstName} {currentStudent.LastName}) Entrez le numéro d'identifiant du cours.");
                Log.Information($"User is asked for a subject ID. Code menu: {menu}.");
                int idSubject = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a subject ID: {idSubject}. Code menu: {menu}.");

                if (database.GetSubject(idSubject) == null) return 1;

                // On demande la note
                Console.WriteLine($"({currentStudent.FirstName} {currentStudent.LastName}) Entrez une note sur 20.");
                Log.Information($"User is asked for a grade score. Code menu: {menu}.");
                double score = Convert.ToDouble(Console.ReadLine());
                Log.Information($"User entered a grade score: {score}. Code menu: {menu}.");
                if (score > 20 || score < 0)
                {
                    Log.Error($"The user entered a wrong grade score. Must be between 0 and 20. Code menu: {menu}.");
                    IncorrectScore();
                    return menu;
                }

                // On demande l'appréciation
                Console.WriteLine($"({currentStudent.FirstName} {currentStudent.LastName}) Entrez une appréciation. (facultatif)");
                string appreciation = "";
                Log.Information($"User is asked for appreciation. Code menu: {menu}.");
                appreciation = Console.ReadLine();
                Log.Information($"User entered an appreciation: {appreciation}. Code menu: {menu}.");

                // On demande de valider
                Console.WriteLine($"Un {score}/20 en {database.GetSubject(idSubject).Name} sera ajouté à {currentStudent.FirstName} {currentStudent.LastName}. Confirmer? (y/n)");
                Log.Information($"User is asked to validate the grade. Code menu: {menu}.");
                string confirm = Console.ReadLine();
                Log.Information($"User entered a validation answer: {confirm}. Code menu: {menu}.");
                if (confirm != "y" && confirm != "n")
                {
                    Log.Error($"The user entered a wront validation character: {confirm}. y or n expected. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ La confirmation a échouée.");
                    return menu;
                }
                else if (confirm == "n")
                {
                    Log.Information($"User canceled the grade attribution: {confirm}. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ Attribution de la note annulée.");
                    return 1;
                }

                database.AddGrade(idStudent, idSubject, score, appreciation);
                return 1;

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wront. Seems to failed converting the score grade from string to double. Code menu: {menu}.");
                IncorrectGlobal();
                return menu;
            }
        }

        // Ajouter un cours (20)
        public int AddSubjectMenu(int menu, Database database)
        {
            Log.Information($"User accesses the menu to add a subject. Code menu: {menu}.");
            Console.WriteLine("Choisissez un nom pour le nouveau cours.");
            Log.Information($"User is asked for a subject name. Code menu: {menu}.");
            string name = Console.ReadLine();
            Log.Information($"User entered a subject name: {name}. Code menu: {menu}.");
            database.AddSubject(name);
            return 2;
        }

        // Supprimer un cours (21)
        public int DeleteSubjectMenu(int menu, Database database)
        {
            Log.Information($"User accesses the menu to delete a subject. Code menu: {menu}.");
            Console.WriteLine("Entrez l'identifiant du cours à supprimer.");
            try
            {
                Log.Information($"User is asked for subject ID to delete a subject. Code menu: {menu}.");
                int idSubject = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a subject ID to delete a subject: {idSubject}. Code menu: {menu}.");
                Console.WriteLine($"La suppression de ce cours entraînement la suppression de toutes les notes qui lui sont associées. Confirmer? (y/n)");
                Log.Information($"User is asked to validate the subject removal. ID to remove: {idSubject}. Code menu: {menu}.");
                string confirm = Console.ReadLine();
                Log.Information($"User entered a validation answer: {confirm}. Code menu: {menu}.");
                if (confirm != "y" && confirm != "n")
                {
                    Log.Error($"The user entered a wront validation character: {confirm}. y or n expected. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ La confirmation a échouée.");
                    return menu;
                }
                else if (confirm == "n")
                {
                    Log.Information($"User canceled the subject removal: {confirm}. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ La suppression du cours a été annulée.");
                    return 2;
                }
                database.DeleteSubject(idSubject);
                return 2;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wrong. Seems to failed converting string to int. Code menu: {menu}.");
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


