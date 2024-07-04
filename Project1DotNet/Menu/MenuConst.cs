using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet.menu
{
    internal static class MenuConst
    {
        // Codes menus :
        // -1 : Quitte l'application
        // 0 : Menu de départ
        // 1 : Menu élèves
        // 2 : Menu cours
        // 10 : Ajouter un nouvel élève
        // 11 : Consulter un élève
        // 12 : Ajouter une note à un élève
        // 20 : Ajouter un cours
        // 21 : Supprimer un cours

        public const int EXIT_APP = -1;

        public const int MAIN_MENU = 0;

        public const int STUDENT_MENU = 1;
        public const int ADD_STUDENT_MENU = 10;
        public const int CONSULT_STUDENT_MENU = 11;
        public const int ADD_GRADE_MENU = 12;

        public const int SUBJECT_MENU = 2;
        public const int ADD_SUBJECT_MENU = 20;
        public const int DELETE_SUBJECT_MENU = 21;

        public const int PROMOTION_MENU = 3;
        public const int STUDENTS_PROMOTION_MENU = 30;
        public const int AVERAGE_PROMOTION_MENU = 31;
        public const int ADD_PROMOTION_MENU = 32;
    }
}
