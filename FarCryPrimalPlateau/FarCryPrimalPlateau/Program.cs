// See https://aka.ms/new-console-template for more information



using FarCryPrimalPlateau;
using System;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using static FarCryPrimalPlateau.UpgradeRepos;

/*
Regle du jeu : Le but du jeu est de tomber sur la case où se trouve le Graal, il est 
positionné en début de partie à un emplacement aléatoire fixe.

Le joueur ne peut se déplacer que d'une seule case à la fois, vers la gauche, droite,
en bas, en haut, dans les limites du plateau.
Il démarre avec une massue de niveau 1 (3 niveaux).
à chaque déplacement un tour en plus,
à 50 tours max, la partie se termine, sauf si le joueur a trouvé le graal avant,
ou si il meurt.

Plateau de 49 cases, 13 ennemis, 5 cases lit de camps pour récupérer 25 pts de vie, 3
cases où se trouve un arc, 2 pour la sagaie, 3 cases d'upgrade de l'arc, 3 cases upgrade
masse, 2 cases upgrade sagaie, 2 cases plantes bleu pour augmenter pendant 3 tours la réactivité
de plus 25.

Mis à part le joueur, tous les autres êtres vivant reste fixés à la même case.
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
        Izila Perso1Izila = new Izila(Singleton.GetRandomId(), "izilaPerso1", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Masse","1"),false);
        Izila Perso2Izila = new Izila(Singleton.GetRandomId(), "izilaPerso2", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Arc","1"),false);
        Izila Batari = new Izila(Singleton.GetRandomId(), "Batari", 120, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Sagaie","3"),true);

        Udam Uii = new Udam(Singleton.GetRandomId(), "Uii", 120, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron", new Arme("Masse","3"),true);
        Udam Perso1Udam = new Udam(Singleton.GetRandomId(), "udamPerso1", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron fonce", new Arme("Sagaie","1"),false);
        Udam Perso2Udam = new Udam(Singleton.GetRandomId(), "udamPerso2", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron", new Arme("Masse","2"),false);

        Herbivore Mammouth1 = new Herbivore(Singleton.GetRandomId(), "Mammouth1", "Mammouth", 130, 150f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Chargeur");
        Herbivore Rhino1 = new Herbivore(Singleton.GetRandomId(), "Rhino1", "Rhinoceros", 105, 110f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Chargeur");
        Herbivore Chevre1 = new Herbivore(Singleton.GetRandomId(), "Chevre1", "Chevre", 35, 12f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Brouteur");
        Herbivore Sanglier1 = new Herbivore(Singleton.GetRandomId(), "Sanglier1", "Sanglier", 45, 20f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Brouteur");

        Carnivore Loup1 = new Carnivore(Singleton.GetRandomId(), "Loup1", "Loup", 80, 50f, Singleton.GetRandomReactivite(), "Canide", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        Carnivore Lion1 = new Carnivore(Singleton.GetRandomId(), "Lion1", "Lion", 100, 90f, Singleton.GetRandomReactivite(), "Felin", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        Carnivore TigreDentSable1 = new Carnivore(Singleton.GetRandomId(), "TigreDentSable1", "TigreDentSable", 100, 90f, Singleton.GetRandomReactivite(), "PredateurPuissant", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));

        UpgradeRepos graal = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.graal, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos litRepos = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.litCamps, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos litRepos2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.litCamps, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos litRepos3 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.litCamps, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos litRepos4 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.litCamps, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos litRepos5 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.litCamps, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos masse = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.masse, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos masse2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.masse, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos masse3 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.masse, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos arc = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.arc, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos arc2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.arc, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos sagaie = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.sagaie, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos sagaie2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.sagaie, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos masseUpgrade = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.upgradeMasse, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos masseUpgrade2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.upgradeMasse, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos arcUpgrade = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.upgradeArc, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos arcUpgrade2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.upgradeArc, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos sagaieUpgrade = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.upgradeSagaie, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        UpgradeRepos sagaieUpgrade2 = new UpgradeRepos(Singleton.GetRandomId(), NomUpgrade.upgradeSagaie, new Coords(Singleton.GetRandom(), Singleton.GetRandom()));

        Joueur takkar = new Joueur(Singleton.GetRandomId(), "Takkar", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), new Arme("Masse", "1"));

        // List de toutes les intances du jeu
        List<IItem> InstancesList = new List<IItem> { takkar,Perso1Izila, Perso2Izila, Batari, Uii,Perso1Udam,Perso2Udam,Mammouth1,Rhino1,Chevre1,Sanglier1,Loup1,Lion1,TigreDentSable1,graal,litRepos,litRepos2 };

        // Positionnement de toutes les intances du jeu
        foreach (IItem instance in InstancesList)
        {
            for(int i = 0; i < OrosArray.Length; i++)
            {
                for (int j = 0; j < OrosArray.Length; j++)
                {
                    if(i == instance.GetPosX() && j == instance.GetPosY())
                    {
                        OrosArray[i,j] = instance.GetId();
                    }
                    
                }
            }
        }

        ConsoleKeyInfo inputTouch;

        while (!gameOver)
        {
            Console.WriteLine("Entrez une direction avec une des fleches pour vous deplacez");
            inputTouch = Console.ReadKey(true);
            int nextMoveX = 0;
            int nextMoveY = 0;
            //Console.WriteLine(inputTouch.Key);

            switch (inputTouch.Key.ToString())
            {
                case "UpArrow":
                    nextMoveY = takkar.GetPosY() - 1;

                    //Teste si en dehors des limites
                    if(nextMoveY < 0)
                    {
                        Console.WriteLine("Mouvement impossible !");
                        nextMoveY = 0;
                    }
                    else
                    {
                        takkar.SetPosY(nextMoveY);
                        // Si une instance est bien présente et non zéro
                        if (OrosArray[takkar.GetPosX(), nextMoveY] != 0)
                        {
                            int idToFind = OrosArray[takkar.GetPosX(), nextMoveY];
                           
                            var instanceQuery =
                            from instanceEnCours in InstancesList
                            where (instanceEnCours.GetId() == idToFind)
                            select instanceEnCours;

                            Type instance = instanceQuery.GetType();

                            switch(instance.Name)
                            {
                                  
                                case "Izila":                                

                                    var instanceIzila =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Izila izila = instanceIzila as Izila;

                                    if (izila != null)
                                    {
                                        while (izila.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if(izila.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if(izila.GetHeros() == true)
                                                {
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                    takkar.Attaque(izila);
                                                }
                                                else
                                                {
                                                    izila.Attaque(takkar);
                                                    takkar.Attaque(izila);
                                                }                                               
                                            }
                                            else
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    takkar.Attaque(izila);
                                                    izila.AttaqueSpecialHeros(true, takkar);                                                    
                                                }
                                                else
                                                {
                                                    takkar.Attaque(izila);
                                                    izila.Attaque(takkar);                                                    
                                                }
                                            }
                                        }

                                        if(izila != null && izila.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            izila = null;
                                        }

                                        if(takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                    }                                    
                                    break;
                                case "Udam":
                                    // code block
                                    break;
                                case "Herbivore":
                                    // code block
                                    break;
                                case "Carnivore":
                                    // code block
                                    break;
                                case "UpgradeRepos":
                                    // code block
                                    break;
                                default:
                                    Console.WriteLine("Classe non trouvée");
                                    break;                                   
                            }
                                
                        }                      
                    }
                    break;
                case "DownArrow":
                    nextMoveY = takkar.GetPosY() + 1;

                    if (nextMoveY > 6)
                    {
                        Console.WriteLine("Mouvement impossible !");
                        nextMoveY = 0;
                    }
                    else
                    {
                        takkar.SetPosY(nextMoveY);
                    }
                    break;
                case "LeftArrow":
                    nextMoveX = takkar.GetPosX() - 1;

                    if (nextMoveX < 0)
                    {
                        Console.WriteLine("Mouvement impossible !");
                        nextMoveX = 0;
                    }
                    else
                    {
                        takkar.SetPosX(nextMoveX);
                    }
                    break;
                case "RightArrow":
                    nextMoveX = takkar.GetPosX() + 1;

                    if (nextMoveX > 6)
                    {
                        Console.WriteLine("Mouvement impossible !");
                        nextMoveX = 0;
                    }
                    else
                    {
                        takkar.SetPosX(nextMoveX);
                    }
                    break;
                default:
                    Console.WriteLine("Veuillez entrez une des 4 fleches directionnelles s'il vous plaît");
                    break;
            }

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


