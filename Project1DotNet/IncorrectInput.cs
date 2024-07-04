using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1DotNet
{
    internal static class IncorrectInput
    {
        // Fonction de saisie utilisateur incorrecte
        public static void IncorrectMenu()
        {
            Console.WriteLine(@"/!\ Saisie incorrecte. Veuillez utiliser le numéro affiché devant votre sélection.");
        }

        public static void NameAlreadyExists()
        {
            Console.WriteLine(@"/!\ Ce nom existe déjà.");
        }

        public static void InputTooShort()
        {
            Console.WriteLine(@"/!\ Cette entrée doit contenir au moins 2 caractères.");
        }

        public static void IncorrectBirthday()
        {
            Console.WriteLine(@"/!\ La date de naissance est incorrecte. Elle doit suivre le schéma suivant : DD/MM/YYYY.");
        }

        public static void IncorrectId()
        {
            Console.WriteLine(@"/!\ L'identifiant doit être un nombre existant.");
        }

        public static void IncorrectScore()
        {
            Console.WriteLine(@"/!\ La note doit être comprise entre 0 et 20.");
        }

        public static void IncorrectValidation()
        {
            Console.WriteLine(@"/!\ Validation incorrecte. Utilisez y pour valider ou n pour annuler.");
        }

        public static void IncorrectGlobal()
        {
            Console.WriteLine(@"/!\ Entrée incorrecte.");
        }
    }
}
