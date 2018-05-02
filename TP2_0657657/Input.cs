using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_0657657
{
    public static class Input
    {
        // ***** Méthodes *****
        public static string InputString(string question)
        // Pose une question.
        // Retourne un string qui peut être vide.
        {
            Console.WriteLine(question);
            string choixString = Console.ReadLine();
            return choixString;
        }
        public static string InputStringNonVide(string question)
        // Pose une question jusqu'à avoir un string non vide.
        // Retourne un string non vide.
        {
            string choix = "";
            do
            {
                choix = InputString(question);
            } while (choix == "");
            return choix;
        }
        public static int InputInt(string question)
        // Pose une question jusqu'à avoir un int.
        // Retourne un int.
        {
            string choixString;
            int choixInt;
            do
            {
                Console.WriteLine(question);
                choixString = Console.ReadLine();
            } while (!Int32.TryParse(choixString, out choixInt));
            return choixInt;
        }
        public static string InputStringInList(string question, List<string> valeurPossible)
        // Pose une question jusqu'à avoir un élément dans la liste.
        // Retourne un string.
        {
            string choix;
            do
            {
                choix = InputString(question);
            } while (!valeurPossible.Contains(choix));
            return choix;
        }
        public static int InputIntInList(string question, List<int> valeurPossible)
        // Pose une question jusqu'à avoir un élément dans la liste.
        // Retourne un int.
        {
            int choixInt;
            do
            {
                choixInt = InputInt(question);
            } while (!valeurPossible.Contains(choixInt));
            return choixInt;
        }
        public static int InputIntMinMax(string question, int min, int max)
        // Pose une question jusqu'à avoir un int entre min et max inclusivement.
        // Retourne un int.
        {
            int choixInt;
            do
            {
                choixInt = InputInt(question);
            } while (max < choixInt || choixInt < min);
            return choixInt;
        }
        public static bool InputConfirmation(string question)
        // Pose une question jusqu'à avoir un int 0 ou 1
        // Retourne false si 0
        // Retourne true si 1
        {
            bool vraiOuFaux;
            question = ("0 - Annuler\n" + "1 - Confirmer\n" + question);
            int zeroOuUn = InputIntInList(question, new List<int> { 0, 1 });
            if (zeroOuUn == 1)
            {
                vraiOuFaux = true;
            }
            else
            {
                vraiOuFaux = false;
            }
            return vraiOuFaux;
        }
        public static void AppuyerSurEntree()
        // Fonction qui demande d'appuyer sur entrée
        {
            Console.Write("Appuyez sur la touche entrée");
            Console.ReadLine();
        }
    }
}
