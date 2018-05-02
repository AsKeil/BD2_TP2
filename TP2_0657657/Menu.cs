// BD2 TP2 Olivier Samson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_0657657
{
    public class Menu
    {
        // ***** Attributs *****
        public PROJETSESSIONBD20657657Entities context;
        public CRUDUsage crudUsage;
        public CRUDImprimante crudImprimante;

        // ***** Constructeur *****
        public Menu(PROJETSESSIONBD20657657Entities context)
        {
            this.context        = context;
            this.crudUsage      = new CRUDUsage(context);
            this.crudImprimante = new CRUDImprimante(context);
        }

        // ***** Méthodes *****
        public void MenuPrincipal()
        // Affiche le menu principale
        // Switch case du menu principale
        {
            int choixMenu;
            do
            {
                AfficherMenuPrincipal();
                choixMenu = Input.InputIntInList("Que voulez vous faire : ", new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 });
                switch (choixMenu)
                {
                    case 1:
                        MenuCRUDImprimante();
                        break;
                    case 2:
                        MenuCRUDUsage();
                        break;
                    case 3:
                        MenuCRUDFilament();
                        break;
                    case 4:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 5:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 6:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 7:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 8:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 9:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 10:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 11:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 12:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 13:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 14:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 0:
                        Console.WriteLine("Fin de l'application");
                        Input.AppuyerSurEntree();
                        break;
                }
            } while (choixMenu != 0);
        }
        public void AfficherMenuPrincipal()
        {
            Console.Clear();
            List<string> infoMenu = new List<string>();
            infoMenu.Add("Menu principale");
            infoMenu.Add("1*CRUD d'une imprimante");
            infoMenu.Add("2*CRUD d’un usagé");
            infoMenu.Add("3*CRUD d’un filament");
            infoMenu.Add("4*Création d’un essai complet");
            infoMenu.Add("5*Modification de la quantité de filament utilisé");
            infoMenu.Add("6*Modification d'une configuration");
            infoMenu.Add("7*Afficher tous les essais ayant été fait pour un modèle");
            infoMenu.Add("8*Afficher qui est l’utilisateur principal pour un filament pour une période donnée");
            infoMenu.Add("9*Afficher la création ayant été essayée le plus souvent");
            infoMenu.Add("10*Afficher les usagers, leur impressions et le modèle (lazy loading)");
            infoMenu.Add("11*Afficher les usagers, leur impressions et le modèle (eager loading)");
            infoMenu.Add("12*Afficher les usagers, leur impressions et le modèle (projection)");
            infoMenu.Add("13*Afficher le nombre d’impression faites par un usager (syntaxe par méthodes)");
            infoMenu.Add("14*Afficher le nombre d’impression faites par un usager (syntaxe par requêtes)");
            infoMenu.Add("0*Quitter");
            Output.AfficherMenu(infoMenu);
        }
        public void MenuCRUDImprimante()
        // Affiche le menu imprimante
        // Switch case du menu imprimante
        {
            int choixMenu;
            do
            {
                AfficherMenuCRUDImprimante();
                choixMenu = Input.InputIntInList("Que voulez vous faire : ", new List<int> { 0, 1, 2, 3, 4});
                switch (choixMenu)
                {
                    case 1:
                        crudImprimante.CImprimante();
                        Input.AppuyerSurEntree();
                        break;
                    case 2:
                        crudImprimante.RImprimante();
                        Input.AppuyerSurEntree();
                        break;
                    case 3:
                        crudImprimante.UImprimante();
                        Input.AppuyerSurEntree();
                        break;
                    case 4:
                        crudImprimante.DImprimante();
                        Input.AppuyerSurEntree();
                        break;
                    case 0:
                        break;
                }
            } while (choixMenu != 0);
        }
        public void AfficherMenuCRUDImprimante()
        {
            Console.Clear();
            List<string> infoMenu = new List<string>();
            infoMenu.Add("Menu CRUD d'une imprimante");
            infoMenu.Add("1*Ajouter une imprimante");
            infoMenu.Add("2*Afficher une imprimante selon son id");
            infoMenu.Add("3*Modifier une imprimante");
            infoMenu.Add("4*Suprimer une imprimante");
            infoMenu.Add("0*Retour");
            Output.AfficherMenu(infoMenu);
        }
        public void MenuCRUDUsage()
        // Affiche le menu CRUD usagé
        // Switch case du menu CRUD usagé
        {
            int choixMenu;
            do
            {
                AfficherMenuCRUDUsage();
                choixMenu = Input.InputIntInList("Que voulez vous faire : ", new List<int> { 0, 1, 2, 3, 4 });
                switch (choixMenu)
                {
                    case 1:
                        crudUsage.CUsage();
                        Input.AppuyerSurEntree();
                        break;
                    case 2:
                        crudUsage.RUsage();
                        Input.AppuyerSurEntree();
                        break;
                    case 3:
                        crudUsage.UUsage();
                        Input.AppuyerSurEntree();
                        break;
                    case 4:
                        crudUsage.DUsage();
                        Input.AppuyerSurEntree();
                        break;
                    case 0:
                        break;
                }
            } while (choixMenu != 0);
        }
        public void AfficherMenuCRUDUsage()
        {
            Console.Clear();
            List<string> infoMenu = new List<string>();
            infoMenu.Add("Menu CRUD d'un usagé");
            infoMenu.Add("1*Ajouter un usagé");
            infoMenu.Add("2*Afficher un usagé selon son id");
            infoMenu.Add("3*Modifier un usagé");
            infoMenu.Add("4*Suprimer un usagé");
            infoMenu.Add("0*Retour");
            Output.AfficherMenu(infoMenu);
        }
        public void MenuCRUDFilament()
        // Affiche le menu filament
        // Switch case du menu filament
        {
            int choixMenu;
            do
            {
                AfficherMenuCRUDFilament();
                choixMenu = Input.InputIntInList("Que voulez vous faire : ", new List<int> { 0, 1, 2, 3, 4 });
                switch (choixMenu)
                {
                    case 1:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 2:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 3:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 4:
                        Console.WriteLine("TODO");
                        Input.AppuyerSurEntree();
                        break;
                    case 0:
                        break;
                }
            } while (choixMenu != 0);
        }
        public void AfficherMenuCRUDFilament()
        {
            Console.Clear();
            List<string> infoMenu = new List<string>();
            infoMenu.Add("Menu CRUD d'un filament");
            infoMenu.Add("1*Ajouter un filament");
            infoMenu.Add("2*Afficher un filament selon son ID");
            infoMenu.Add("3*Modifier un filament");
            infoMenu.Add("4*Suprimer un filament");
            infoMenu.Add("0*Retour");
            Output.AfficherMenu(infoMenu);
        }
    }
}
