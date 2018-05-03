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
                    Usager usage = new Usager();
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
                Usager usage = this.context.Usagers.Find(usageID);
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
                Usager usage = this.context.Usagers.Where(c => c.ID == usageId).First(); // L'usagé que l'on veut modifier
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
        // Le propriétaire d'un filament ne peut être supprimé si un autre usagé a fait une impression avec son filament
        // A2 D
        {
            bool veutSupprimer;
            Console.Clear();
            AfficherLesUsages();
            int usageId = RUsage(); // Recherche le id de l'usagé à supprimer. Retourne 0 si l'usagé n'existe pas
            if (usageId != 0) { // Si il n'y a pas d'annulation
                Usager usageAEffacer = this.context.Usagers.Find(usageId);
                Console.Clear();
                AfficherElementsUsageASupprimer(usageAEffacer);
                veutSupprimer = Input.InputConfirmation("Êtes-vous certain de vouloir supprimer cet usagé et tout ce qui en découle: ");
                if (veutSupprimer) { // Si on veut bel et bien supprimer cet usagé
                    SupprimerUsage(usageAEffacer);
                    this.context.SaveChanges();
                    Console.WriteLine("L'usagé a été supprimer.");
                }
            }
        }
        private void AfficherElementsUsageASupprimer(Usager usageAEffacer)
        // Fonction pour afficher les éléments supprimés en même temps qu'un usagé
        {
            AfficherImpressionASupprimer(usageAEffacer);
            AfficherFilamentASupprimer(usageAEffacer);
            Console.WriteLine("---------------------------------------");
            AfficherUnUsage(usageAEffacer);
        }
        private void AfficherImpressionASupprimer(Usager usageAEffacer)
        // Fonction pour afficher les impression à supprimer en même temps qu'un usagé
        {
            var impressions = this.context.Impressions.Where(c => c.UsagerId == usageAEffacer.ID);
            foreach (Impression impression in impressions) // Affiche chaque impression de l'usage
            {
                Console.WriteLine("Impression #" + impression.ID + " " + impression.Nom.Trim());
                foreach (Essaie essaie in impression.Essaies) // Affiche chaque essaie de l'impression
                {
                    Console.WriteLine("Essaie #" + essaie.ID + " " + essaie.Commentaire.Trim());
                    foreach (EssaieFilament essaieFilament in essaie.EssaieFilaments) // Affiche chaque essaieFilament de l'essaie
                    {
                        Console.WriteLine("Essaie Filament #" + essaieFilament.EssaieId);
                    }
                }
            }
        }
        private void AfficherFilamentASupprimer(Usager usageAEffacer)
        // Fonction pour afficher les filaments à supprimer en même temps qu'un usagé
        {
            var filaments = this.context.Filaments.Where(c => c.ProprietaireId == usageAEffacer.ID);
            foreach (Filament filament in filaments)
            {
                Console.WriteLine("Essaie Filament #" + filament.ID + " " + filament.TypeFilament.Materiel.Trim() + " " + filament.TypeFilament.Diametre);
            }
        }
        private void SupprimerUsage(Usager usageAEffacer)
        // Fonction pour supprimer un usagé
        {
            var impressions = this.context.Impressions.Where(c => c.UsagerId == usageAEffacer.ID);
            foreach (Impression impression in impressions) // Pour chaque impression de l'usage
            {
                var essaies = impression.Essaies;
                foreach (Essaie essaie in essaies) // Supprime chaque essaie
                {
                    var essaieFilaments = essaie.EssaieFilaments;
                    foreach (EssaieFilament essaieFilament in essaieFilaments) // Supprime chaque essaieFilament de l'essaie
                    {
                        this.context.EssaieFilaments.Remove(essaieFilament);
                    }
                    this.context.Essaies.Remove(essaie);
                }
            }
            var filaments = this.context.Filaments.Where(c => c.ProprietaireId == usageAEffacer.ID);
            foreach (Filament filament in filaments) // Supprime chaque filament dont l'usage est le propriétaire
            {
                this.context.Filaments.Remove(filament);
            }
            this.context.Usagers.Remove(usageAEffacer); // Supprime l'usage
        }
        private void AfficherUnUsage(Usager usage)
        // Fonction pour afficher un usagé
        {
            Console.WriteLine("#{0} {1} {2}",
                                    usage.ID,
                                    usage.Nom.Trim(),
                                    usage.Prenom.Trim());
        }
        private void AfficherLesUsages()
        // Fonction pour afficher tous les usagés
        {
            var usages = this.context.Usagers;
            foreach (Usager usage in usages)
            {
                AfficherUnUsage(usage);
            }
        }
    }
}
