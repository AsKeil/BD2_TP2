using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_0657657
{
    public class CRUDUsage
    // A2
    // CRUD d'un usagé
    {
        // ***** Attributs *****
        public PROJETSESSIONBD20657657Entities context;

        // ***** Constructeur *****
        public CRUDUsage(PROJETSESSIONBD20657657Entities context)
        {
            this.context = context;
        }

        // ***** Méthodes *****
        public void CUsage()
        // Fonction pour créer un usagé dans la BD.
        // A2 C
        {
            string nom                  = Input.InputStringNonVide("Entrez le nom : ");
            string prenom               = Input.InputStringNonVide("Entrez le prénom : ");
            string motDePasseString     = Input.InputStringNonVide("Entrez le mot de passe : ");
            string[] motDePasseTable    = Password.SimpleHash.ComputeHash(motDePasseString, "SHA512", null);
            string questionConfirmation = ("Voulez-vous créer " + nom + " " + prenom + " " + motDePasseString + " :");
            if (Input.InputConfirmation(questionConfirmation)) {
                {
                    var usage = new Usager();
                    usage.Nom = nom;
                    usage.Prenom = prenom;
                    usage.MotDePasse = motDePasseTable[1];
                    usage.Salt = motDePasseTable[2];
                    this.context.Usagers.Add(usage);
                    this.context.SaveChanges();
                }
                Console.WriteLine("L'usagé a été créé.");
            } else {
                Console.WriteLine("L'usagé n'a pas été créé.");
            }
        }
        public int RUsage()
        // Fonction pour rechercher un usagé dans la BD à l'aide de son ID.
        // Retourne le id de l'usagé si il existe.
        // Retourne zéro si l'usagé n'existe pas.
        // Retourne zéro si l'utilisateur annule.
        // A2 R
        {
            int usageID = Input.InputInt("Entrez le id de l'usagé (0 pour annuler) : ");
            if (usageID != 0) {
                var usage = this.context.Usagers.Find(usageID);
                if (usage == null) {
                    Console.WriteLine("Il n'y a aucun usagé avec ce id.");
                    usageID = 0;
                } else {
                    AfficherUnUsage(usage);
                }
            }
            return usageID;
        }
        public void UUsage()
        // Fonction pour mettre à jour un usagé
        // A2 U
        {
            Console.Clear();
            AfficherLesUsages();
            int usageId = RUsage(); // Recherche de l'usagé à mettre à jour. Retourne 0 si l'usagé n'existe pas
            int choixMenu;
            string modification;
            if (usageId != 0) {
                AfficherMenuUpdateUsage();
                choixMenu = Input.InputIntInList("Que voulez vous faire : ", new List<int> { 0, 1, 2, 3 });
                var usage = this.context.Usagers.Where(c => c.ID == usageId).First(); // L'usagé que l'on veut modifier
                switch (choixMenu) {
                    case 1:
                        modification = Input.InputStringNonVide("Entrez le nouveau nom :");
                        usage.Nom = modification;
                        Console.WriteLine("Le nom a été modifié.");
                        break;
                    case 2:
                        modification = Input.InputStringNonVide("Entrez le nouveau prénom :");
                        usage.Prenom = modification;
                        Console.WriteLine("Le prénom a été modifié.");
                        break;
                    case 3:
                        modification = Input.InputStringNonVide("Entrez le nouveau mot de passe :");
                        string[] motDePasse = new string[3];
                        motDePasse = Password.SimpleHash.ComputeHash(modification, "SHA512", null);
                        usage.MotDePasse = motDePasse[1];
                        usage.Salt = motDePasse[2];
                        Console.WriteLine("Le mot de passe a été modifié.");
                        break;
                    case 0:
                        break;
                }
                this.context.SaveChanges();
            }
        }
        public void AfficherMenuUpdateUsage()
        {
            List<string> infoMenu = new List<string>();
            infoMenu.Add("Menu modification d'un usagé");
            infoMenu.Add("1*Mettre à jour le nom");
            infoMenu.Add("2*Mettre à jour le prénom");
            infoMenu.Add("3*Mettre un nouveau mot de passe");
            infoMenu.Add("0*Annuler");
            Output.AfficherMenu(infoMenu);
        }
        public void DUsage()
        // Fonction pour supprimer un usagé
        // A2 D
        {
            bool veutSupprime;
            bool estSupprimable = true;
            int usageId = RUsage(); // Recherche de l'usagé à supprimer. Retourne 0 si l'usagé n'existe pas
            if (usageId != 0) {
                var impressions = this.context.Impressions.Where(c => c.UsagerId == usageId).FirstOrDefault(); // Est-ce que l'usagé a fait une impression
                var filaments = this.context.Filaments.Where(c => c.ProprietaireId == usageId).FirstOrDefault(); // Est-ce que l'usagé a fait un achat
                if (impressions != null){
                    estSupprimable = false; // Si il y a un élément dans une des deux tables, on ne doit pas supprimer l'usagé
                } else if (filaments != null) {
                    estSupprimable = false;
                }
                if (!estSupprimable) {
                    Console.WriteLine("Cet usagé a effectué des opérations et ne peut pas être supprimer.");
                } else {
                    veutSupprime = Input.InputConfirmation("Êtes-vous certain de vouloir supprimer cet usagé : ");
                    if (veutSupprime) {
                        var usage = this.context.Usagers.Where(c => c.ID == usageId).First(); // L'usagé que l'on veut supprimer
                        this.context.Usagers.Remove(usage);
                        this.context.SaveChanges();
                        Console.WriteLine("L'usagé a été supprimer.");
                    }
                }
            }
            Console.WriteLine("Appuyez sur la touche entrée");
            Console.ReadLine();
        }
        public void AfficherUnUsage(Usager usage)
        // Fonction pour afficher un usagé
        {
            Console.WriteLine("#{0} {1} {2}",
                                    usage.ID,
                                    usage.Nom.Trim(),
                                    usage.Prenom.Trim());
        }
        public void AfficherLesUsages()
        // Fonction pour afficher tous les usagés
        {
            var usages = this.context.Usagers;
            foreach (var usage in usages)
            {
                AfficherUnUsage(usage);
            }
        }
    }
}
