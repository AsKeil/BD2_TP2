using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_0657657
{
    public static class Output
    {
        // ***** Méthodes *****
        public static void AfficherMenuTitre(string titre)
        // Affiche un titre avec un certain format
        {
            int longueurAvantTitre  = 5;
            int longueurApresTitre  = 5;
            string caractereAffiche = "*";
            string titreModifie     = "";
            int i;
            for (i = 0; i < longueurAvantTitre; i++)
            {
                titreModifie = titreModifie + caractereAffiche;
            }
            titreModifie = titreModifie + " " + titre + " ";
            for (i = 0; i < longueurApresTitre; i++)
            {
                titreModifie = titreModifie + caractereAffiche;
            }
            Console.WriteLine(titreModifie);
        }
        public static void AfficherMenuOption(List<string> infoMenu)
        // Affiche les options d'un menu
        {
            int espacesAvantOption          = 1;
            int caractereMaxOption          = 2;
            int espacesApresOption          = 1;
            int caractereAvantSeparation    = espacesAvantOption + caractereMaxOption + espacesApresOption;
            string caractereSeparation      = "-";
            string optionModifie;
            int i,j;
            for (i = 0; i < infoMenu.Count; i++) // Boucle du nombre d'options
            {
                optionModifie = "";
                for (j = 0; j < espacesAvantOption; j++) // Boucle du nombre d'espace avant les caractères d'options
                {
                    optionModifie = optionModifie + " ";
                }
                optionModifie = optionModifie + infoMenu[i].Split('*')[0]; // Ajoute les caractères de sélection de l'option
                while (optionModifie.Length < (caractereAvantSeparation)) // Ajoute des espace selon le nombre de caractère maximum des options
                {
                    optionModifie = optionModifie + " ";
                }
                optionModifie = optionModifie + caractereSeparation + " ";
                optionModifie = optionModifie + infoMenu[i].Split('*')[1]; // Ajoute l'option
                Console.WriteLine(optionModifie);
            }
        }
        public static void AfficherMenu(List<string> infoMenu)
        // Affiche un menu à partir d'une liste.
        // Le premier élément de la liste doit être le titre.
        // Les autres éléments sont les options.
        // Les options doivent déjà être énumérés et être suivi s'une étoile *.
        {
            AfficherMenuTitre(infoMenu[0]);
            infoMenu.RemoveAt(0); // Retire le titre
            AfficherMenuOption(infoMenu);
        }
    }
}
