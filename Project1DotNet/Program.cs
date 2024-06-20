using static System.Formats.Asn1.AsnWriter;

namespace Project1DotNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menus :
            // -1 : Quitte l'application
            // 0 : Menu de départ
            // 1 : Menu élèves
            // 2 : Menu cours
            // 10 : Ajouter un nouvel élève
            // 11 : Consulter un élève
            // 12 : Ajouter une note à un élève
            // 20 : Ajouter un cours
            // 21 : Supprimer un cours

            Database database = new Database();
            Menu menuManager = new Menu();
            int menu = 0;

            database.AddStudent("Coralie", "ALINI", new DateTime(2001, 6, 19));
            database.AddStudent("Alex", "PREFI", new DateTime(1995, 1, 8));
            database.AddStudent("Sandrine", "SCRUA", new DateTime(1999, 8, 25));
            database.AddSubject("Mathématiques");
            database.AddSubject("Français");
            database.AddSubject("Anglais");
            foreach (Student student in database.Students)
            {
                foreach (Subject subject in database.Subjects)
                {
                    database.AddGrade(student.Id, subject.Id, 15, $"Appréciation de {student.FirstName}.");
                }
            }
            database.AddGrade(0, 0, 15.5, $"Appréciation de .");
            database.AddGrade(0, 0, 16.5, $"Appréciation de .");
            database.AddGrade(0, 0, 9.3333, $"Appréciation de .");


            while (true)
            {

                // Menu de départ (0)
                if (menu == 0)
                {
                    menu = menuManager.StartMenu(menu);
                }

                // Menu élèves (1)
                if (menu == 1)
                {
                    menu = menuManager.StudentMenu(menu, database);
                }

                // Menu cours (2)
                if (menu == 2)
                {
                    menu = menuManager.SubjectMenu(menu, database);
                }

                // Ajouter un élève (10)
                if (menu == 10)
                {
                    menu = menuManager.AddStudentMenu(menu, database);
                }

                // Consulter un élève (11)
                if (menu == 11)
                {
                    menu = menuManager.ConsultStudentMenu(menu, database);
                }

                // Ajouter une note à un élève (12)
                if (menu == 12)
                {
                    menu = menuManager.AddGradeMenu(menu, database);
                }

                // Ajouter un cours (20)
                if (menu == 20)
                {
                    menu = menuManager.AddSubjectMenu(menu, database);
                }

                // Supprimer un cours (21)
                if (menu == 21)
                {
                    menu = menuManager.DeleteSubjectMenu(menu, database);
                }

                // Quitte l'application (-1)
                if (menu == -1)
                {
                    Console.WriteLine("____________________");
                    Console.WriteLine("Au revoir.");
                    break;
                }
            }
        }


    }
}

