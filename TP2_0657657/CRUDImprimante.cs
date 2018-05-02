using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_0657657
{
    public class CRUDImprimante
    // A1
    // CRUD d'une imprimante
    {
        // ***** Attributs *****
        public PROJETSESSIONBD20657657Entities context;

        // ***** Constructeur *****
        public CRUDImprimante(PROJETSESSIONBD20657657Entities context)
        {
            this.context = context;
        }

        // ***** Méthodes *****
        public void CImprimante()
        // Fonction pour créer une imprimante dans la BD.
        // A1 C
        {
            string[] tableInput = CreateImprimanteInput();
            if (CreateImprimanteEstValide(tableInput))
            {
                string description  = tableInput[0];
                decimal prix        = decimal.Parse(tableInput[1]);
                Math.Round(prix, 2);
                int modeleId        = Int32.Parse(tableInput[2]);

                var imprimante = new Imprimante();
                imprimante.Description  = description;
                imprimante.Prix         = prix;
                imprimante.ModeleId     = modeleId;
                this.context.Imprimantes.Add(imprimante);
                this.context.SaveChanges();

                Console.WriteLine("L'imprimante a été créé.");
            }
            else
            {
                Console.WriteLine("L'imprimante n'a pas été créé.");
            }
            Console.Write("Appuyez sur la touche entrée");
            Console.ReadLine();
        }
        public string[] CreateImprimanteInput()
        // Input de base pour créer une imprimante
        // description = tableInput[0]
        // prixString = tableInput[1]
        // modeleId = tableInput[2];
        {
            String description, prixString, modeleIdString;
            float prixFloat             = 0;
            int modeleIdInt             = 0;
            string[] tableInput         = new string[3];
            List<int> idModelePossible  = new List<int>();
            do
            {
                Console.WriteLine("Entrez la description de l'imprimante : ");
                description = Console.ReadLine();
            } while (description == "");
            do
            {
                Console.WriteLine("Entrez le prix de l'imprimante : ");
                prixString = Console.ReadLine().Replace(".", ",");
                float.TryParse(prixString, out prixFloat);
            } while (prixFloat == 0);
            idModelePossible = AfficherModeleImprimante();
            do
            {
                Console.WriteLine("Entrez le id du modèle de l'imprimante : ");
                modeleIdString = Console.ReadLine();
                int.TryParse(modeleIdString, out modeleIdInt);
            } while (!idModelePossible.Any(c => c == modeleIdInt)); // Vérifie si l'id de modèle entrée est dans la liste des modèles possibles
            tableInput[0] = description;
            tableInput[1] = prixString;
            tableInput[2] = modeleIdString;
            return tableInput;
        }
        public bool CreateImprimanteEstValide(string[] tableInput)
        // Input de confirmation pour créer un usagé
        // Retourne true si l'utilisateur veut le créer et false si il a changé d'idée
        {
            string estValideString;
            bool estValideBool = false;
            string description = tableInput[0];
            decimal prix = decimal.Parse(tableInput[1]);
            Math.Round(prix, 2);
            int modeleId = Int32.Parse(tableInput[2]);

            Console.WriteLine("");
            Console.WriteLine("0 - Annuler");
            Console.WriteLine("1 - Créer imprimante");
            Console.WriteLine("Voulez-vous créer " + description + " $" + prix + " Modele #" + modeleId + " :");
            do
            {
                Console.WriteLine("Entrez 0 ou 1 : ");
                estValideString = Console.ReadLine();
            } while (estValideString != "0" && estValideString != "1");
            if (estValideString == "1")
            {
                estValideBool = true;
            }
            return estValideBool;
        }
        public int RImprimante()
        // Fonction pour rechercher une imprimante dans la BD à l'aide de son ID.
        // Retourne le id de si elle existe.
        // Retourne zéro si elle n'existe pas.
        // Retourne zéro si l'utilisateur annule.
        // A1 R
        {
            string input;
            int imprimanteID;
            do
            {
                Console.WriteLine("Entrez le id de l'imprimante (0 pour annuler) : ");
                input = Console.ReadLine();
            } while (!int.TryParse(input, out imprimanteID));
            if (imprimanteID != 0)
            {
                var imprimante = this.context.Imprimantes.Find(imprimanteID);
                if (imprimante == null)
                {
                    Console.WriteLine("Il n'y a aucune imprimante avec ce id.");
                    imprimanteID = 0;
                }
                else
                {
                    Console.WriteLine(
                        "Imprimante #{0} \n" +
                        "Fabricant  #{1} {2} \n" +
                        "Modèle     #{3} \n" +
                        "Description modèle     : {4} \n" +
                        "Description imprimante : {5} \n" +
                        "Prix réel / suggéré    : ${6} / ${7} \n",
                        imprimante.ID,
                        imprimante.ModeleImprimante.FabricantId,
                        imprimante.ModeleImprimante.Fabricant.Nom.Trim(),
                        imprimante.ModeleId,
                        imprimante.ModeleImprimante.Description.Trim(),
                        imprimante.Description.Trim(),
                        imprimante.Prix,
                        imprimante.ModeleImprimante.Prix
                        );
                }
            }
            return imprimanteID;
        }
        public List<int> AfficherModeleImprimante()
        // Affiche la liste des modèle d'imprimante et retourne une liste des id possibles.
        {
            List<int> idModelePossible = new List<int>();
            var modeles = this.context.ModeleImprimantes;
            foreach (var modele in modeles)
            {
                Console.WriteLine("Modele #{0} {1}",
                        modele.ID,
                        modele.Description.Trim());
                        idModelePossible.Add(modele.ID);
            }
            return idModelePossible;
        }
        public void UImprimante()
        // Fonction pour mettre à jour une imprimante
        // A1 U
        {
            AfficherToutesImprimantes();
            int imprimanteId = RImprimante(); // Recherche de l'imprimante à mettre à jour. Retourne 0 si l'imprimante n'existe pas
            decimal modificationDecimal = 0;
            string choixMenu;
            string modification = "";
            if (imprimanteId != 0)
            {
                Console.WriteLine("1 - Mettre à jour la description");
                Console.WriteLine("2 - Mettre à jour le prix d'achat");
                Console.WriteLine("0 - Annuler");
                do
                {
                    Console.WriteLine("Que voulez-vous faire : ");
                    choixMenu = Console.ReadLine();
                } while (choixMenu != "0" && choixMenu != "1" && choixMenu != "2");
                switch (choixMenu)
                {
                    case "1":
                        Console.WriteLine("Entrez la nouvelle description :");
                        do
                        {
                            modification = Console.ReadLine();
                        } while (modification == "");

                        var imrpimante = this.context.Imprimantes.Where(c => c.ID == imprimanteId).First(); // L'imprimante que l'on veut modifier
                        imrpimante.Description = modification;
                        this.context.SaveChanges();

                        Console.WriteLine("Le description a été modifiée.");
                        break;
                    case "2":
                        Console.WriteLine("Entrez le nouveau prix :");
                        do
                        {
                            modification = Console.ReadLine();
                        } while (!decimal.TryParse(modification, out modificationDecimal));
                        modificationDecimal = Math.Round(modificationDecimal,2);

                        var imprimante = this.context.Imprimantes.Where(c => c.ID == imprimanteId).First(); // L'imprimante que l'on veut modifier
                        imprimante.Prix = modificationDecimal;
                        this.context.SaveChanges();

                        Console.WriteLine("Le prix a été modifié.");
                        break;
                    case "0":
                        break;
                }
            }
            Console.Write("Appuyez sur la touche entrée");
            Console.ReadLine();
        }
        public void DImprimante()
        // Fonction pour supprimer une imprimante
        // A1 D
        {
            AfficherToutesImprimantes();
            int imprimanteId = RImprimante(); // Recherche de l'imprimante à mettre à jour. Retourne 0 si elle n'existe pas
            string choixMenu;
            if (imprimanteId != 0)
            {
                DImprimanteAfficherEffet(imprimanteId);
                do
                {
                    Console.WriteLine("Êtes-vous certain de vouloir supprimer cette imprimante? (1-oui / 0-non)");
                    choixMenu = Console.ReadLine();
                } while (choixMenu != "0" && choixMenu != "1");
                if (choixMenu == "1")
                {
                    Buse b;
                    var idDeBuses = this.context.ConfigPhysiques
                        .Where(c => c.ImprimanteId == imprimanteId)
                        .ToList();

                    foreach (ConfigPhysique bb in idDeBuses)
                    {
                        b = this.context.Buses.Find(idDeBuses);
                        foreach (ConfigPhysique cp in b.ConfigPhysiques.ToList())
                        {
                            b.ConfigPhysiques.Remove(cp);       // dissocie les config de la buse
                        }
                    }
                    context.SaveChanges();

                    var imprimante = this.context.Imprimantes.Where(c => c.ID == imprimanteId).First(); // L'imprimante que l'on veut supprimer
                    this.context.Imprimantes.Remove(imprimante);
                    this.context.SaveChanges();
                    Console.WriteLine("L'imprimante a été supprimer.");
                }
            }
            Console.WriteLine("Appuyez sur la touche entrée");
            Console.ReadLine();
        }
        public void DImprimanteAfficherEffet(int imprimanteId)
        // Fonction pour afficher les effets de la suppression d'une imprimantes
        {
            Console.WriteLine("TODO");
        }
        public void AfficherToutesImprimantes()
        // Fonction pour afficher toutes les imprimantes
        {
            var imprimantes = this.context.Imprimantes;
            foreach (var imprimante in imprimantes)
            {
                Console.WriteLine("{0} {1} {2} {3}",
                                imprimante.ID,
                                imprimante.Description.Trim(),
                                imprimante.ModeleImprimante.Description.Trim(),
                                imprimante.ModeleImprimante.Fabricant.Nom.Trim());
            }
        }
    }
}
