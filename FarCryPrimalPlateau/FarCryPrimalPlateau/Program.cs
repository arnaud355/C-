// See https://aka.ms/new-console-template for more information



using FarCryPrimalPlateau;
using System;
using System.Runtime.Intrinsics.X86;

/*
Regle du jeu : Le but du jeu est de tomber sur la case où se trouve le Graal, il est 
positionné en début de partie à un emplacement aléatoire fixe.

Le joueur ne peut se déplacer que d'une seule case à la fois, vers la gauche, droite,
en bas, en haut, dans les limites du plateau.
Il démarre avec une massue de niveau 1 (3 niveaux).
à chaque déplacement un tour en plus,
à 50 tours max, la partie se termine, sauf si le joueur a trouvé le graal avant,
ou si il meurt.

Plateau de 49 cases, 14 ennemis, 5 cases lit de camps pour récupérer 25 pts de vie, 3
cases où se trouve un arc, 2 pour la sagaie, 3 cases d'upgrade de l'arc, 3 cases upgrade
masse, 2 cases upgrade sagaie, 2 cases plantes bleu pour augmenter pendant 3 tours la réactivité
de plus 25.

Réactivité de chaque ennemis et du joueur est fixé aléatoirement à chaque tour, entre 5 à 100.

Si joueur tombe sur une case ennemis, comparaison des 2 réactivités, la plus forte peut
attaquer en premier. S'ensuit combat à mort, le joueur prend plusieurs dizaine
de pts de vie (110 pts vie max, commence à 110 pts de vie), selon adversaire,
si il gagne, sinon game over.

 */

// tab 2 dimensions de 7 lignes 7 colonnes
int[,] OrosArray = new int[7, 7];
bool continuer = true;
bool gameOver = false;

while (continuer)
{
    string partie;
    string quitter;

    Console.WriteLine("********** Far cyr Primal Plateau **********");
    Console.WriteLine("Lancer une partie o/n");

    partie = Console.ReadLine();

   
       
    if (partie == "o" || partie == "O")
    {       

        Console.WriteLine(" Bon courage dans le monde d'Oros!");
        Izila Perso1Izila = new Izila("izilaPerso1", 12, 100, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Masse","1"),false);
        Izila Perso2Izila = new Izila("izilaPerso2", 22, 100, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Arc","1"),false);
        Izila Batari = new Izila("Batari", 1, 120, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Sagaie","3"),true);

        Udam Uii = new Udam("Uii", 2, 120, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron", new Arme("Masse","3"),true);
        Udam Perso1Udam = new Udam("udamPerso1", 2, 120, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron fonce", new Arme("Sagaie","1"),false);
        Udam Perso2Udam = new Udam("udamPerso2", 2, 120, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron", new Arme("Masse","2"),false);

        Herbivore Mammouth1 = new Herbivore("Mammouth1", "Mammouth", 130, 150f, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Chargeur");
        Herbivore Rhino1 = new Herbivore("Rhino1", "Rhinoceros", 105, 110f, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Chargeur");
        Herbivore Chevre1 = new Herbivore("Chevre1", "Chevre", 35, 12f, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Brouteur");
        Herbivore Sanglier1 = new Herbivore("Sanglier1", "Sanglier", 45, 20f, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Brouteur");

        Carnivore Loup1 = new Carnivore("Loup1", "Loup", 80, 50f, "Canide", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        Carnivore Lion1 = new Carnivore("Lion1", "Lion", 100, 90f, "Felin", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        Carnivore TigreDentSable1 = new Carnivore("TigreDentSable1", "TigreDentSable", 100, 90f, "PredateurPuissant", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));

        UpgradeRepos graal = new UpgradeRepos("non", "non", "non", "non", "non","non", "non", "Graal");
        UpgradeRepos litRepos = new UpgradeRepos("litCamps", "non", "non", "non", "non","non", "non", "non");
        UpgradeRepos litRepos2 = new UpgradeRepos("litCamps", "non", "non", "non", "non","non", "non", "non");
        UpgradeRepos litRepos3 = new UpgradeRepos("litCamps", "non", "non", "non", "non","non", "non", "non");
        UpgradeRepos litRepos4 = new UpgradeRepos("litCamps", "non", "non", "non", "non","non", "non", "non");
        UpgradeRepos litRepos5 = new UpgradeRepos("litCamps", "non", "non", "non", "non","non", "non", "non");
        UpgradeRepos masse = new UpgradeRepos("non", "non", "non", "non", "masse","non", "non", "non");
        UpgradeRepos masse2 = new UpgradeRepos("non", "non", "non", "non", "masse","non", "non", "non");
        UpgradeRepos masse3 = new UpgradeRepos("non", "non", "non", "non", "masse","non", "non", "non");
        UpgradeRepos arc = new UpgradeRepos("non", "non", "non", "non", "non","arc", "non", "non");
        UpgradeRepos arc2 = new UpgradeRepos("non", "non", "non", "non", "non","arc", "non", "non");
        UpgradeRepos sagaie = new UpgradeRepos("non", "non", "non", "non", "non","non", "sagaie", "non");
        UpgradeRepos sagaie2 = new UpgradeRepos("non", "non", "non", "non", "non","non", "sagaie", "non");
        UpgradeRepos masseUpgrade = new UpgradeRepos("non", "oui", "non", "non", "non","non", "non", "non");
        UpgradeRepos masseUpgrade2 = new UpgradeRepos("non", "oui", "non", "non", "non","non", "non", "non");
        UpgradeRepos arcUpgrade = new UpgradeRepos("non", "non", "oui", "non", "non","non", "non", "non");
        UpgradeRepos arcUpgrade2 = new UpgradeRepos("non", "non", "oui", "non", "non","non", "non", "non");
        UpgradeRepos sagaieUpgrade = new UpgradeRepos("non", "non", "non", "oui", "non","non", "non", "non");
        UpgradeRepos sagaieUpgrade2 = new UpgradeRepos("non", "non", "non", "oui", "non","non", "non", "non");

        Joueur takkar = new Joueur("Takkar", 100, new Coords(Singleton.GetRandom(), Singleton.GetRandom()), new Arme("Masse", "1"));

        List<IItem> ItemsList = new List<IItem> { takkar,Perso1Izila, Perso2Izila, Batari, Uii,Perso1Udam,Perso2Udam,Mammouth1,Rhino1,Chevre1,Sanglier1,Loup1,Lion1,TigreDentSable1,graal,litRepos,litRepos2 };

        foreach (IItem ItemList in ItemsList)
        {
            /*volant.Voler();
            Avion a = volant as Avion;
            if (a != null)
            {
                a.DemarrerLeMoteur();
                a.Rouler();
                Console.WriteLine(a.M_NomDuCommandant);
            }*/
        }

    }
    else
        {
        Console.WriteLine("Voulez vous quitter le jeu ? o/n");
        quitter = Console.ReadLine();
        if (quitter == "o" || quitter == "O")
        {
            Console.WriteLine("Bye");
            continuer = false;
        }
    }
  
}


