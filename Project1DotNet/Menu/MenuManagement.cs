using Project1DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.menu
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
                switch (Menu)
                {
                    // Menu de départ (0)
                    case MenuConst.MAIN_MENU:
                        Menu = MainMenuDisplay.StartMenu(Menu);
                        break;

                    // Menu élèves (1)
                    case MenuConst.STUDENT_MENU:
                        Menu = StudentMenuDisplay.StudentMenu(Menu);
                        break;

                    // Menu cours (2)
                    case MenuConst.SUBJECT_MENU:
                        Menu = SubjectMenuDisplay.SubjectMenu(Menu);
                        break;

                    // Ajouter un élève (10)
                    case MenuConst.ADD_STUDENT_MENU:
                        Menu = StudentMenuDisplay.AddStudentMenu(Menu);
                        break;

                    // Consulter un élève (11)
                    case MenuConst.CONSULT_STUDENT_MENU:
                        Menu = StudentMenuDisplay.ConsultStudentMenu(Menu);
                        break;

                    // Ajouter une note à un élève (12)
                    case MenuConst.ADD_GRADE_MENU:
                        Menu = StudentMenuDisplay.AddGradeMenu(Menu);
                        break;

                    // Ajouter un cours (20)
                    case MenuConst.ADD_SUBJECT_MENU:
                        Menu = SubjectMenuDisplay.AddSubjectMenu(Menu);
                        break;

                    // Supprimer un cours (21)
                    case MenuConst.DELETE_SUBJECT_MENU:
                        Menu = SubjectMenuDisplay.DeleteSubjectMenu(Menu);
                        break;

                    // Quitte l'application (-1)
                    case MenuConst.EXIT_APP:
                        goto End;
                }
            }

        End:
            Console.WriteLine("____________________");
            Console.WriteLine("Au revoir.");
        }

    }
}
