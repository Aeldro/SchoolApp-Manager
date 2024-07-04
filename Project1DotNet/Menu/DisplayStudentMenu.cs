using Project1DotNet.Menu;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.menu
{
    internal class DisplayStudentMenu
    {
        // Menu élèves (1)
        public int StudentMenu(int menu)
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
                        List<Student> students = ListsManagement.GetStudents();
                        DisplayElement.ShowAll(students);
                        return menu;
                    case 2:
                        return MenuConst.ADD_STUDENT_MENU;
                    case 3:
                        return MenuConst.CONSULT_STUDENT_MENU;
                    case 4:
                        return MenuConst.ADD_GRADE_MENU;
                    case 5:
                        return MenuConst.MAIN_MENU;
                    case 6:
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

        // Ajouter un élève (10)
        public int AddStudentMenu(int menu)
        {
            Log.Information($"User accesses the menu to add a student. Code menu: {menu}.");

            Console.WriteLine("____________________");

            Console.WriteLine("Entrez le prénom de l'étudiant.");
            string firstName = UserInputsValidation.NameInput(menu);
            Log.Information($"Firstname set: {firstName}. Code menu: {menu}.");

            Console.WriteLine("Entrez le nom de famille de l'étudiant.");
            string lastName = UserInputsValidation.NameInput(menu);
            Log.Information($"Lastname set: {lastName}. Code menu: {menu}.");

            Console.WriteLine("Entrez la date de naissance de l'étudiant. (DD/MM/YYYY)");
            DateTime birthday = UserInputsValidation.BirthdayInput(menu);
            Log.Information($"Birthday set: {birthday}. Code menu: {menu}.");

            List<Promotion> promotions = ListsManagement.GetPromotions();
            DisplayElement.ShowAll(promotions);

            int choice;
            if (promotions.Count > 0)
            {
                Console.WriteLine("(Élèves) Choisissez une action à effectuer.");
                Console.WriteLine("0: Attribuer l'élève à une promotion existante");
                Console.WriteLine("1: Attribuer l'élève à une nouvelle promotion");
                choice = UserInputsValidation.MenuInput(new List<int> { 0, 1 });
            }
            else { choice = 1; }

            Promotion promotion;
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Entrez le numéro de promotion de l'élève.");
                    int promoId = UserInputsValidation.IdInput(menu, promotions);
                    promotion = ListsManagement.GetFromList(promoId, promotions);
                    break;

                case 1:
                    Console.WriteLine("Entrez un nom pour la nouvelle promotion.");
                    string promoName = UserInputsValidation.NameInput(menu, promotions);
                    Log.Information($"User entered a name for a new promotion. Code menu: {menu}.");
                    promotion = new Promotion(Generate.GenerateId(promotions), promoName);
                    ListsManagement.AddElement(promotion, promotions);
                    break;

                default: //Grâce à la vérification de la variable choice via la méthode MenuInput, ce cas n'est jamais censé arriver
                    IncorrectInput.IncorrectMenu();
                    Log.Error(@$"/!\ This case wasn't supposed to happen. User managed to get through the menu verification. Code menu: {menu}.");
                    return menu;
            }

            List<Student> students = ListsManagement.GetStudents();
            Student student = new Student(Generate.GenerateId(students), firstName, lastName, birthday, promotion);
            ListsManagement.AddElement(student, students);
            return MenuConst.STUDENT_MENU;
        }

        // Consulter un élève (11)
        public int ConsultStudentMenu(int menu)
        {
            List<Student> students = ListsManagement.GetStudents();

            Log.Information($"User accesses the menu to consult a student. Code menu: {menu}.");
            DisplayElement.ShowAll(students);
            Console.WriteLine("____________________");
            Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant.");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a valid student ID: {id}. Code menu: {menu}.");
                Student student = ListsManagement.GetFromList(id, students);
                DisplayElement.Show(student);
                return MenuConst.STUDENT_MENU;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"The user entered a wrong student ID. Seems to failed converting string to int. Code menu: {menu}.");
                IncorrectInput.IncorrectId();
                return menu;
            }
        }

        // Ajouter une note à un élève (12)
        public int AddGradeMenu(int menu)
        {
            Log.Information($"User accesses the menu to give a grade to a student. Code menu: {menu}.");
            List<Student> students = ListsManagement.GetStudents();
            List<Subject> subjects = ListsManagement.GetSubjects();

            try
            {
                // On demande l'ID de l'étudiant
                DisplayElement.ShowAll(students);
                Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant à qui ajouter une note.");
                Log.Information($"User is asked for a student ID. Code menu: {menu}.");
                int idStudentInput = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a student ID: {idStudentInput}. Code menu: {menu}.");

                Student student = ListsManagement.GetFromList(idStudentInput, students);
                if (student == null) return MenuConst.STUDENT_MENU;

                // On demande l'ID du cours
                DisplayElement.ShowAll(subjects);
                Console.WriteLine($"({student.FirstName} {student.LastName}) Entrez le numéro d'identifiant du cours.");
                Log.Information($"User is asked for a subject ID. Code menu: {menu}.");
                int idSubjectInput = Convert.ToInt32(Console.ReadLine());
                Log.Information($"User entered a subject ID: {idSubjectInput}. Code menu: {menu}.");

                Subject subject = ListsManagement.GetFromList(idSubjectInput, subjects);
                if (subject == null) return MenuConst.STUDENT_MENU;

                // On demande la note
                Console.WriteLine($"({student.FirstName} {student.LastName} - {subject.Name}) Entrez une note sur 20.");
                Log.Information($"User is asked for a grade score. Code menu: {menu}.");
                double scoreInput = Convert.ToDouble(Console.ReadLine());
                Log.Information($"User entered a grade score: {scoreInput}. Code menu: {menu}.");
                if (scoreInput > 20 || scoreInput < 0)
                {
                    Log.Error($"The user entered a wrong grade score. Must be between 0 and 20. Code menu: {menu}.");
                    IncorrectInput.IncorrectScore();
                    return menu;
                }

                // On demande l'appréciation
                Console.WriteLine($"({student.FirstName} {student.LastName} - {subject.Name}) Entrez une appréciation. (facultatif)");
                Log.Information($"User is asked for appreciation. Code menu: {menu}.");
                string appreciationInput = Console.ReadLine();
                Log.Information($"User entered an appreciation: {appreciationInput}. Code menu: {menu}.");

                // On demande de valider
                Console.WriteLine($"Un {scoreInput}/20 en {subject.Name} sera ajouté à {student.FirstName} {student.LastName}. Confirmer? (y/n)");
                Log.Information($"User is asked to validate the grade. Code menu: {menu}.");
                string confirmInput = Console.ReadLine();
                Log.Information($"User entered a validation answer: {confirmInput}. Code menu: {menu}.");
                if (confirmInput != "y" && confirmInput != "n")
                {
                    Log.Error($"The user entered a wront validation character: {confirmInput}. y or n expected. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ La confirmation a échouée.");
                    return menu;
                }
                else if (confirmInput == "n")
                {
                    Log.Information($"User canceled the grade attribution: {confirmInput}. Code menu: {menu}.");
                    Console.WriteLine(@"/!\ Attribution de la note annulée.");
                    return MenuConst.STUDENT_MENU;
                }

                List<Grade> grades = ListsManagement.GetGrades();
                ListsManagement.AddElement(student, subject, scoreInput, appreciationInput, grades);
                return MenuConst.STUDENT_MENU;

            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Something went wront. Seems to failed converting the score grade from string to double. Code menu: {menu}.");
                IncorrectInput.IncorrectGlobal();
                return menu;
            }
        }
    }
}
