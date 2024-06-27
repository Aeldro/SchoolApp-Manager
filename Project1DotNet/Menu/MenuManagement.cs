using Project1DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.Menu
{
    internal static class MenuManagement
    {
        private static DisplayMainMenu MainMenuDisplay { get; } = new DisplayMainMenu();
        private static DisplayStudentMenu StudentMenuDisplay { get; } = new DisplayStudentMenu();
        private static DisplaySubjectMenu SubjectMenuDisplay { get; } = new DisplaySubjectMenu();
        private static int Menu = MenuConst.MAIN_MENU;

        public static void RunMenu()
        {
            while (true)
            {

                // Menu de départ (0)
                if (Menu == MenuConst.MAIN_MENU)
                {
                    Menu = MainMenuDisplay.StartMenu(Menu);
                }

                // Menu élèves (1)
                if (Menu == MenuConst.STUDENT_MENU)
                {
                    Menu = StudentMenuDisplay.StudentMenu(Menu);
                }

                // Menu cours (2)
                if (Menu == MenuConst.SUBJECT_MENU)
                {
                    Menu = SubjectMenuDisplay.SubjectMenu(Menu);
                }

                // Ajouter un élève (10)
                if (Menu == MenuConst.ADD_STUDENT_MENU)
                {
                    Menu = StudentMenuDisplay.AddStudentMenu(Menu);
                }

                // Consulter un élève (11)
                if (Menu == MenuConst.CONSULT_STUDENT_MENU)
                {
                    Menu = StudentMenuDisplay.ConsultStudentMenu(Menu);
                }

                // Ajouter une note à un élève (12)
                if (Menu == MenuConst.ADD_GRADE_MENU)
                {
                    Menu = StudentMenuDisplay.AddGradeMenu(Menu);
                }

                // Ajouter un cours (20)
                if (Menu == MenuConst.ADD_SUBJECT_MENU)
                {
                    Menu = SubjectMenuDisplay.AddSubjectMenu(Menu);
                }

                // Supprimer un cours (21)
                if (Menu == MenuConst.DELETE_SUBJECT_MENU)
                {
                    Menu = SubjectMenuDisplay.DeleteSubjectMenu(Menu);
                }

                // Quitte l'application (-1)
                if (Menu == MenuConst.EXIT_APP)
                {
                    Console.WriteLine("____________________");
                    Console.WriteLine("Au revoir.");
                    break;
                }
            }
        }

    }
}
