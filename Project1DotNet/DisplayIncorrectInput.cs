using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class DisplayIncorrectInput
    {
        // Fonction de saisie utilisateur incorrecte
        public static void IncorrectMenu()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ Saisie incorrecte. Veuillez utiliser le numéro affiché devant votre sélection.");
            ColorSetter.Reset();
        }

        public static void NameAlreadyExists()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ Ce nom existe déjà.");
            ColorSetter.Reset();
        }

        public static void InputTooShort()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ Cette entrée doit contenir au moins 2 caractères.");
            ColorSetter.Reset();
        }

        public static void IncorrectBirthday()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ La date de naissance est incorrecte. Elle doit suivre le schéma suivant : DD/MM/YYYY.");
            ColorSetter.Reset();
        }

        public static void IncorrectId()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ L'identifiant doit être un nombre existant.");
            ColorSetter.Reset();
        }

        public static void IncorrectScore()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ La note doit être comprise entre 0 et 20.");
            ColorSetter.Reset();
        }

        public static void IncorrectValidation()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ Validation incorrecte. Utilisez y pour valider ou n pour annuler.");
            ColorSetter.Reset();
        }

        public static void IncorrectGlobal()
        {
            ColorSetter.ErrorColor();
            Console.WriteLine("");
            Console.WriteLine(@"/!\ Entrée incorrecte.");
            ColorSetter.Reset();
        }
    }
}
