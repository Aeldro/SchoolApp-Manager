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
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ Saisie incorrecte. Veuillez utiliser le numéro affiché devant votre sélection.", ColorSetter.Error);
        }

        public static void NameAlreadyExists()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ Ce nom existe déjà.", ColorSetter.Error);
        }

        public static void InputTooShort()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ Cette entrée doit contenir au moins 2 caractères.", ColorSetter.Error);
        }

        public static void IncorrectBirthday()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ La date de naissance est incorrecte. Elle doit suivre le schéma suivant : DD/MM/YYYY.", ColorSetter.Error);
        }

        public static void IncorrectId()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ L'identifiant doit être un nombre existant.", ColorSetter.Error);
        }

        public static void IncorrectScore()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ La note doit être comprise entre 0 et 20.", ColorSetter.Error);
        }

        public static void IncorrectValidation()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ Validation incorrecte. Utilisez y pour valider ou n pour annuler.", ColorSetter.Error);
        }

        public static void IncorrectGlobal()
        {
            Console.WriteLine("");
            ColorSetter.WriteLine(@"/!\ Entrée incorrecte.", ColorSetter.Error);
        }
    }
}
