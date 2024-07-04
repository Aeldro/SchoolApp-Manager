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
            ColorSetter.InformationColor();
            Console.WriteLine("(Élèves) Choisissez une action à effectuer.");
            Console.WriteLine("1: Afficher tous les élèves");
            Console.WriteLine("2: Ajouter un nouvel élève");
            Console.WriteLine("3: Consulter un élève");
            Console.WriteLine("4: Ajouter une note à un élève");
            Console.WriteLine("5: Revenir au menu principal");
            Console.WriteLine("6: Quitter l'application");
            ColorSetter.Reset();

            int userInput = UserInputsValidation.MenuInput(menu, new List<int> { 1, 2, 3, 4, 5, 6 });
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

        // Ajouter un élève (10)
        public int AddStudentMenu(int menu)
        {
            Log.Information($"User accesses the menu to add a student. Code menu: {menu}.");

            ColorSetter.InformationColor();
            Console.WriteLine("Entrez le prénom de l'étudiant.");
            ColorSetter.Reset();
            string firstName = UserInputsValidation.NameInput(menu);
            Log.Information($"Firstname set: {firstName}. Code menu: {menu}.");

            ColorSetter.InformationColor();
            Console.WriteLine("Entrez le nom de famille de l'étudiant.");
            ColorSetter.Reset();
            string lastName = UserInputsValidation.NameInput(menu);
            Log.Information($"Lastname set: {lastName}. Code menu: {menu}.");

            ColorSetter.InformationColor();
            Console.WriteLine("Entrez la date de naissance de l'étudiant. (DD/MM/YYYY)");
            ColorSetter.Reset();
            DateTime birthday = UserInputsValidation.BirthdayInput(menu);
            Log.Information($"Birthday set: {birthday}. Code menu: {menu}.");

            List<Promotion> promotions = ListsManagement.GetPromotions();
            DisplayElement.ShowAll(promotions);

            int choice;
            if (promotions.Count > 0)
            {
                ColorSetter.InformationColor();
                Console.WriteLine("(Élèves) Choisissez une action à effectuer.");
                Console.WriteLine("0: Attribuer l'élève à une promotion existante");
                Console.WriteLine("1: Attribuer l'élève à une nouvelle promotion");
                ColorSetter.Reset();
                choice = UserInputsValidation.MenuInput(menu, new List<int> { 0, 1 });
            }
            else { choice = 1; }

            Promotion promotion;
            switch (choice)
            {
                case 0:
                    ColorSetter.InformationColor();
                    Console.WriteLine("Entrez le numéro de promotion de l'élève.");
                    ColorSetter.Reset();
                    int promoId = UserInputsValidation.IdInput(menu, promotions);
                    promotion = ListsManagement.GetFromList(promoId, promotions);
                    break;

                case 1:
                    ColorSetter.InformationColor();
                    Console.WriteLine("Entrez un nom pour la nouvelle promotion.");
                    ColorSetter.Reset();
                    string promoName = UserInputsValidation.NameInput(menu, promotions);
                    Log.Information($"User entered a name for a new promotion. Code menu: {menu}.");
                    promotion = new Promotion(Generate.GenerateId(promotions), promoName);
                    ListsManagement.AddElement(promotion, promotions);
                    break;

                default: //Grâce à la vérification de la variable choice via la méthode MenuInput, ce cas n'est jamais censé arriver
                    IncorrectInput.IncorrectMenu();
                    Log.Error($"This case wasn't supposed to happen. User managed to get through the menu verification. Code menu: {menu}.");

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
            Log.Information($"User accesses the menu to consult a student. Code menu: {menu}.");

            List<Student> students = ListsManagement.GetStudents();

            // On vérifie que la base de données contienne au moins un étudiant
            if (students.Count == 0)
            {
                ColorSetter.ErrorColor();
                Console.WriteLine(@"/!\ La base de données ne contient aucun étudiant.");
                ColorSetter.Reset();
                return MenuConst.STUDENT_MENU;
            }

            DisplayElement.ShowAll(students);
            ColorSetter.InformationColor();
            Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant.");
            ColorSetter.Reset();
            int id = UserInputsValidation.IdInput(menu, students);
            Log.Information($"User entered a valid student ID: {id}. Code menu: {menu}.");
            Student student = ListsManagement.GetFromList(id, students);
            DisplayElement.Show(student);

            return MenuConst.STUDENT_MENU;
        }

        // Ajouter une note à un élève (12)
        public int AddGradeMenu(int menu)
        {
            Log.Information($"User accesses the menu to give a grade to a student. Code menu: {menu}.");

            List<Student> students = ListsManagement.GetStudents();
            List<Subject> subjects = ListsManagement.GetSubjects();

            // On vérifie que la base de données contienne au moins un étudiant et un cours
            if (students.Count == 0)
            {
                ColorSetter.ErrorColor();
                Console.WriteLine(@"/!\ La base de données ne contient aucun étudiant.");
                ColorSetter.Reset();
                return MenuConst.STUDENT_MENU;
            }
            else if (subjects.Count == 0)
            {
                ColorSetter.ErrorColor();
                Console.WriteLine(@"/!\ La base de données ne contient aucun cours.");
                ColorSetter.Reset();
                return MenuConst.STUDENT_MENU;
            }

            // On demande l'ID de l'étudiant
            DisplayElement.ShowAll(students);
            ColorSetter.InformationColor();
            Console.WriteLine("Entrez le numéro d'identifiant de l'étudiant à qui ajouter une note.");
            ColorSetter.Reset();
            Log.Information($"User is asked for a student ID. Code menu: {menu}.");
            int idStudentInput = UserInputsValidation.IdInput(menu, students);
            Log.Information($"User entered a student ID: {idStudentInput}. Code menu: {menu}.");

            Student student = ListsManagement.GetFromList(idStudentInput, students);

            // On demande l'ID du cours
            DisplayElement.ShowAll(subjects);
            ColorSetter.InformationColor();
            Console.WriteLine($"({student.FirstName} {student.LastName}) Entrez le numéro d'identifiant du cours.");
            ColorSetter.Reset();
            Log.Information($"User is asked for a subject ID. Code menu: {menu}.");
            int idSubjectInput = UserInputsValidation.IdInput(menu, subjects);
            Log.Information($"User entered a subject ID: {idSubjectInput}. Code menu: {menu}.");

            Subject subject = ListsManagement.GetFromList(idSubjectInput, subjects);

            // On demande la note
            ColorSetter.InformationColor();
            Console.WriteLine($"({student.FirstName} {student.LastName} - {subject.Name}) Entrez une note sur 20.");
            ColorSetter.Reset();
            Log.Information($"User is asked for a grade score. Code menu: {menu}.");
            double scoreInput = UserInputsValidation.GradeInput(menu);
            Log.Information($"User entered a grade score: {scoreInput}. Code menu: {menu}.");

            // On demande l'appréciation
            ColorSetter.InformationColor();
            Console.WriteLine($"({student.FirstName} {student.LastName} - {subject.Name}) Entrez une appréciation. (facultatif)");
            ColorSetter.Reset();
            Log.Information($"User is asked for appreciation. Code menu: {menu}.");
            string appreciationInput = Console.ReadLine();
            Log.Information($"User entered an appreciation: {appreciationInput}. Code menu: {menu}.");

            // On demande de valider
            ColorSetter.WarningColor();
            Console.WriteLine($"Un {scoreInput}/20 en {subject.Name} sera ajouté à {student.FirstName} {student.LastName}. Confirmer? (y/n)");
            ColorSetter.Reset();
            Log.Information($"User is asked to validate the grade. Code menu: {menu}.");
            string confirmInput = UserInputsValidation.ValidationInput(menu);
            Log.Information($"User entered a validation answer: {confirmInput}. Code menu: {menu}.");
            if (confirmInput == "n")
            {
                Log.Information($"User canceled the grade attribution: {confirmInput}. Code menu: {menu}.");
                ColorSetter.InformationColor();
                Console.WriteLine(@"L'attribution de la note a été annulée.");
                ColorSetter.Reset();
                return MenuConst.STUDENT_MENU;
            }

            List<Grade> grades = ListsManagement.GetGrades();
            ListsManagement.AddElement(student, subject, scoreInput, appreciationInput, grades);

            return MenuConst.STUDENT_MENU;
        }
    }
}


