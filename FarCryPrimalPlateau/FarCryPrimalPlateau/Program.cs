﻿// See https://aka.ms/new-console-template for more information



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
Il démarre avec une massue de niveau 1 (3 niveaux), si il tombe sur une case de changement d'arme,
changement automatique arme, et arme mise au niveau de maitrise le plus bas, sans tenir compte
de l'historique armes possédés.
à chaque déplacement un tour en plus,
La partie se termine qaund le joueur a trouvé le graal avant ou s'il meurt.

Plateau de 49 cases, 13 ennemis, 5 cases lit de camps pour récupérer toute sa vie, 3
cases où se trouve un arc, 2 pour la sagaie, 3 cases d'upgrade de l'arc, 3 cases upgrade
masse, 2 cases upgrade sagaie, 2 cases plantes bleu pour augmenter pendant 3 tours la réactivité
de plus 25.

Mis à part le joueur, tous les autres êtres vivant reste fixés à la même case.
Réactivité de chaque ennemis et du joueur est fixé aléatoirement à chaque tour, entre 5 à 100.

Si joueur tombe sur une case ennemis, comparaison des 2 réactivités, la plus forte peut
attaquer en premier. S'ensuit combat à mort, le joueur récupére 30pts de vie (jusqu à son max de vie), 
à chaque combat victorieux, sinon game over.

 */

// tab 2 dimensions de 7 lignes 7 colonnes
int[,] OrosArray = new int[7, 7];
int sizeRow = 7;
bool continuer = true;
bool gameOver = false;
int tour = 0;
string partie;
string quitter;

while (continuer)
{

    Console.WriteLine("********** Far cyr Primal Plateau **********");
    Console.WriteLine("Lancer une partie o/n");
    
    partie = Console.ReadLine();
    

    if (partie == "o" || partie == "O")
    {       

        Console.WriteLine(" Bon courage dans le monde d'Oros!");
        Izila Perso1Izila = new Izila(Singleton.GetRandomId(), "izilaPerso1", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Masse","Low"),false);
        Izila Perso2Izila = new Izila(Singleton.GetRandomId(), "izilaPerso2", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Arc","Low"),false);
        Izila Batari = new Izila(Singleton.GetRandomId(), "Batari", 120, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "bleu", new Arme("Sagaie","High"),true);

        Udam Uii = new Udam(Singleton.GetRandomId(), "Uii", 120, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron", new Arme("Masse","High"),true);
        Udam Perso1Udam = new Udam(Singleton.GetRandomId(), "udamPerso1", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron fonce", new Arme("Sagaie","Low"),false);
        Udam Perso2Udam = new Udam(Singleton.GetRandomId(), "udamPerso2", 100, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "marron", new Arme("Masse","Medium"),false);

        Herbivore Mammouth1 = new Herbivore(Singleton.GetRandomId(), "Mammouth1", "Mammouth", 130f, 150f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Chargeur");
        Herbivore Rhino1 = new Herbivore(Singleton.GetRandomId(), "Rhino1", "Rhinoceros", 105f, 110f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Chargeur");
        Herbivore Chevre1 = new Herbivore(Singleton.GetRandomId(), "Chevre1", "Chevre", 35f, 12f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Brouteur");
        Herbivore Sanglier1 = new Herbivore(Singleton.GetRandomId(), "Sanglier1", "Sanglier", 45f, 20f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), "Brouteur");

        Carnivore Loup1 = new Carnivore(Singleton.GetRandomId(), "Loup1", "Loup", 80f, 50f, Singleton.GetRandomReactivite(), "Canide", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        Carnivore Lion1 = new Carnivore(Singleton.GetRandomId(), "Lion1", "Lion", 100f, 90f, Singleton.GetRandomReactivite(), "Felin", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));
        Carnivore TigreDentSable1 = new Carnivore(Singleton.GetRandomId(), "TigreDentSable1", "TigreDentSable", 100f, 90f, Singleton.GetRandomReactivite(), "PredateurPuissant", new Coords(Singleton.GetRandom(), Singleton.GetRandom()));

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

        Joueur takkar = new Joueur(Singleton.GetRandomId(), "Takkar", 110f, Singleton.GetRandomReactivite(), new Coords(Singleton.GetRandom(), Singleton.GetRandom()), new Arme("Masse", "Low"));

        Console.WriteLine("Objets initiés!");
        // List de toutes les intances du jeu
        List<IItem> InstancesList = new List<IItem> { takkar,Perso1Izila, Perso2Izila, Batari, Uii,Perso1Udam,Perso2Udam,Mammouth1,Rhino1,Chevre1,Sanglier1,Loup1,Lion1,TigreDentSable1,graal,litRepos,litRepos2 };
        Console.WriteLine("Objets initiés!");
        // Positionnement de toutes les intances du jeu
        
        foreach (IItem instance in InstancesList)
        {
            for(int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeRow; j++)
                {
                    if(i == instance.GetPosX() && j == instance.GetPosY())
                    {                        
                        OrosArray[i,j] = instance.GetId();
                    }
                    
                }
            }
        }

        for (int i = 0; i < sizeRow; i++)
        {
            for (int j = 0; j < sizeRow; j++)
            {
                Console.WriteLine(OrosArray[i, j]);
           }
        }

        Console.WriteLine("Objets placés!");
        ConsoleKeyInfo inputTouch;

       do{
        
            takkar.GetInfoOfItem();
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
                        tour++;
                        takkar.SetPosY(nextMoveY);
                        takkar.GetInfoOfItem();
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
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }                                               
                                            }
                                            else
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);                                                    
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
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
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }                                    
                                    break;
                                case "Udam":
                                    var instanceUdam =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Udam udam = instanceUdam as Udam;

                                    if (udam != null)
                                    {
                                        while (udam.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (udam.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                            }
                                            else
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (udam != null && udam.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            udam = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Herbivore":
                                    var instanceHerbivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Herbivore herbivore = instanceHerbivore as Herbivore;

                                    if (herbivore != null)
                                    {
                                        while (herbivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (herbivore.GetReactivite() > takkar.GetReactivite())
                                            {                                              
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), takkar.GetName());
                                                herbivore.AttaqueHerbivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);                                                
                                            }
                                            else
                                            {                                                
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), herbivore.GetName());
                                                herbivore.AttaqueHerbivore(takkar);
                                                
                                            }
                                        }

                                        if (herbivore != null && herbivore.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            herbivore = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Carnivore":
                                    var instanceCarnivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Carnivore carnivore = instanceCarnivore as Carnivore;

                                    if (carnivore != null)
                                    {
                                        while (carnivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (carnivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), takkar.GetName());
                                                carnivore.AttaqueCarnivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), carnivore.GetName());
                                                carnivore.AttaqueCarnivore(takkar);

                                            }
                                        }

                                        if (carnivore != null && carnivore.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            carnivore = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "UpgradeRepos":
                                    var instanceUpgradeRepos =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    UpgradeRepos upgradeRepos = instanceUpgradeRepos as UpgradeRepos;

                                    if (upgradeRepos != null)
                                    {
                                        switch (upgradeRepos.GetNomUpgrade())
                                        {
                                            case "graal":
                                                Console.WriteLine("Congratulation !!! Vous avez gagné");
                                                gameOver = true;
                                                break;
                                            case "litCamps":
                                                Console.WriteLine("zzzz Dodo !");
                                                takkar.SetPtsVie(110f);
                                                break;
                                            case "upgradeMasse":                                               
                                                if(takkar.GetNomArmeJoueur() == "Masse")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }                                             
                                                break;
                                            case "upgradeArc":
                                                if (takkar.GetNomArmeJoueur() == "Arc")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeSagaie":
                                                if (takkar.GetNomArmeJoueur() == "Sagaie")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "masse":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");
             
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                         break;
                                                               
                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "arc":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "sagaie":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Sagaie":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("pas d'upgrade dispo");
                                                break;
                                        }

                                        OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                        upgradeRepos = null;                                     
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Classe non trouvée");
                                    break;                                   
                            }
                                
                        }
                        else
                        {
                            Console.WriteLine("Case nature");
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
                        tour++;
                        takkar.SetPosY(nextMoveY);
                        takkar.GetInfoOfItem();
                        // Si une instance est bien présente et non zéro
                        if (OrosArray[takkar.GetPosX(), nextMoveY] != 0)
                        {
                            int idToFind = OrosArray[takkar.GetPosX(), nextMoveY];

                            var instanceQuery =
                            from instanceEnCours in InstancesList
                            where (instanceEnCours.GetId() == idToFind)
                            select instanceEnCours;

                            Type instance = instanceQuery.GetType();

                            switch (instance.Name)
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
                                            if (izila.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                            }
                                            else
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (izila != null && izila.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            izila = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Udam":
                                    var instanceUdam =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Udam udam = instanceUdam as Udam;

                                    if (udam != null)
                                    {
                                        while (udam.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (udam.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                            }
                                            else
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (udam != null && udam.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            udam = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Herbivore":
                                    var instanceHerbivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Herbivore herbivore = instanceHerbivore as Herbivore;

                                    if (herbivore != null)
                                    {
                                        while (herbivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (herbivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), takkar.GetName());
                                                herbivore.AttaqueHerbivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), herbivore.GetName());
                                                herbivore.AttaqueHerbivore(takkar);

                                            }
                                        }

                                        if (herbivore != null && herbivore.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            herbivore = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Carnivore":
                                    var instanceCarnivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Carnivore carnivore = instanceCarnivore as Carnivore;

                                    if (carnivore != null)
                                    {
                                        while (carnivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (carnivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), takkar.GetName());
                                                carnivore.AttaqueCarnivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), carnivore.GetName());
                                                carnivore.AttaqueCarnivore(takkar);

                                            }
                                        }

                                        if (carnivore != null && carnivore.GetIsAlive() == false)
                                        {
                                            OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                            carnivore = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "UpgradeRepos":
                                    var instanceUpgradeRepos =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    UpgradeRepos upgradeRepos = instanceUpgradeRepos as UpgradeRepos;

                                    if (upgradeRepos != null)
                                    {
                                        switch (upgradeRepos.GetNomUpgrade())
                                        {
                                            case "graal":
                                                Console.WriteLine("Congratulation !!! Vous avez gagné");
                                                gameOver = true;
                                                break;
                                            case "litCamps":
                                                Console.WriteLine("zzzz Dodo !");
                                                takkar.SetPtsVie(110f);
                                                break;
                                            case "upgradeMasse":
                                                if (takkar.GetNomArmeJoueur() == "Masse")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeArc":
                                                if (takkar.GetNomArmeJoueur() == "Arc")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeSagaie":
                                                if (takkar.GetNomArmeJoueur() == "Sagaie")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "masse":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");

                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;

                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "arc":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "sagaie":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Sagaie":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("pas d'upgrade dispo");
                                                break;
                                        }

                                        OrosArray[takkar.GetPosX(), nextMoveY] = 0;
                                        upgradeRepos = null;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Classe non trouvée");
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Case nature");
                        }
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
                        tour++;
                        takkar.SetPosX(nextMoveX);
                        takkar.GetInfoOfItem();
                        // Si une instance est bien présente et non zéro
                        if (OrosArray[nextMoveX, takkar.GetPosY()] != 0)
                        {
                            int idToFind = OrosArray[nextMoveX, takkar.GetPosY()];

                            var instanceQuery =
                            from instanceEnCours in InstancesList
                            where (instanceEnCours.GetId() == idToFind)
                            select instanceEnCours;

                            Type instance = instanceQuery.GetType();

                            switch (instance.Name)
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
                                            if (izila.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                            }
                                            else
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (izila != null && izila.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            izila = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Udam":
                                    var instanceUdam =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Udam udam = instanceUdam as Udam;

                                    if (udam != null)
                                    {
                                        while (udam.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (udam.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                            }
                                            else
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (udam != null && udam.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            udam = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Herbivore":
                                    var instanceHerbivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Herbivore herbivore = instanceHerbivore as Herbivore;

                                    if (herbivore != null)
                                    {
                                        while (herbivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (herbivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), takkar.GetName());
                                                herbivore.AttaqueHerbivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), herbivore.GetName());
                                                herbivore.AttaqueHerbivore(takkar);

                                            }
                                        }

                                        if (herbivore != null && herbivore.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            herbivore = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Carnivore":
                                    var instanceCarnivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Carnivore carnivore = instanceCarnivore as Carnivore;

                                    if (carnivore != null)
                                    {
                                        while (carnivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (carnivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), takkar.GetName());
                                                carnivore.AttaqueCarnivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), carnivore.GetName());
                                                carnivore.AttaqueCarnivore(takkar);

                                            }
                                        }

                                        if (carnivore != null && carnivore.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            carnivore = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "UpgradeRepos":
                                    var instanceUpgradeRepos =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    UpgradeRepos upgradeRepos = instanceUpgradeRepos as UpgradeRepos;

                                    if (upgradeRepos != null)
                                    {
                                        switch (upgradeRepos.GetNomUpgrade())
                                        {
                                            case "graal":
                                                Console.WriteLine("Congratulation !!! Vous avez gagné");
                                                gameOver = true;
                                                break;
                                            case "litCamps":
                                                Console.WriteLine("zzzz Dodo !");
                                                takkar.SetPtsVie(110f);
                                                break;
                                            case "upgradeMasse":
                                                if (takkar.GetNomArmeJoueur() == "Masse")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeArc":
                                                if (takkar.GetNomArmeJoueur() == "Arc")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeSagaie":
                                                if (takkar.GetNomArmeJoueur() == "Sagaie")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "masse":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");

                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;

                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "arc":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "sagaie":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Sagaie":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("pas d'upgrade dispo");
                                                break;
                                        }

                                        OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                        upgradeRepos = null;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Classe non trouvée");
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Case nature");
                        }
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
                        tour++;
                        takkar.SetPosX(nextMoveX);
                        takkar.GetInfoOfItem();
                        // Si une instance est bien présente et non zéro
                        if (OrosArray[nextMoveX, takkar.GetPosY()] != 0)
                        {
                            int idToFind = OrosArray[nextMoveX, takkar.GetPosY()];

                            var instanceQuery =
                            from instanceEnCours in InstancesList
                            where (instanceEnCours.GetId() == idToFind)
                            select instanceEnCours;

                            Type instance = instanceQuery.GetType();

                            switch (instance.Name)
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
                                            if (izila.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                }
                                            }
                                            else
                                            {
                                                if (izila.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), izila.GetName());
                                                    takkar.Attaque(izila);
                                                    Console.WriteLine("{0} attaque {1} ", izila.GetName(), takkar.GetName());
                                                    izila.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (izila != null && izila.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            izila = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Udam":
                                    var instanceUdam =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Udam udam = instanceUdam as Udam;

                                    if (udam != null)
                                    {
                                        while (udam.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (udam.GetReactivite() > takkar.GetReactivite())
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                }
                                            }
                                            else
                                            {
                                                if (udam.GetHeros() == true)
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.AttaqueSpecialHeros(true, takkar);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("{0} attaque {1} ", takkar.GetName(), udam.GetName());
                                                    takkar.Attaque(udam);
                                                    Console.WriteLine("{0} attaque {1} ", udam.GetName(), takkar.GetName());
                                                    udam.Attaque(takkar);
                                                }
                                            }
                                        }

                                        if (udam != null && udam.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            udam = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Herbivore":
                                    var instanceHerbivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Herbivore herbivore = instanceHerbivore as Herbivore;

                                    if (herbivore != null)
                                    {
                                        while (herbivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (herbivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), takkar.GetName());
                                                herbivore.AttaqueHerbivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), herbivore.GetName());
                                                takkar.Attaque(herbivore);
                                                Console.WriteLine("{0} attaque {1} ", herbivore.GetName(), herbivore.GetName());
                                                herbivore.AttaqueHerbivore(takkar);

                                            }
                                        }

                                        if (herbivore != null && herbivore.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            herbivore = null;
                                            takkar.SetPtsVie(30f);
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "Carnivore":
                                    var instanceCarnivore =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    Carnivore carnivore = instanceCarnivore as Carnivore;

                                    if (carnivore != null)
                                    {
                                        while (carnivore.GetIsAlive() && takkar.IsAlive())
                                        {
                                            if (carnivore.GetReactivite() > takkar.GetReactivite())
                                            {
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), takkar.GetName());
                                                carnivore.AttaqueCarnivore(takkar);
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                            }
                                            else
                                            {
                                                Console.WriteLine("{0} attaque {1} ", takkar.GetName(), carnivore.GetName());
                                                takkar.Attaque(carnivore);
                                                Console.WriteLine("{0} attaque {1} ", carnivore.GetName(), carnivore.GetName());
                                                carnivore.AttaqueCarnivore(takkar);

                                            }
                                        }

                                        if (carnivore != null && carnivore.GetIsAlive() == false)
                                        {
                                            OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                            carnivore = null;
                                        }

                                        if (takkar.IsAlive() == false)
                                        {
                                            gameOver = true;
                                        }
                                        else
                                        {
                                            takkar.SetPtsVie(30f);
                                        }
                                    }
                                    break;
                                case "UpgradeRepos":
                                    var instanceUpgradeRepos =
                                    from objectEnCours in InstancesList
                                    where (objectEnCours.GetId() == idToFind)
                                    select objectEnCours;

                                    UpgradeRepos upgradeRepos = instanceUpgradeRepos as UpgradeRepos;

                                    if (upgradeRepos != null)
                                    {
                                        switch (upgradeRepos.GetNomUpgrade())
                                        {
                                            case "graal":
                                                Console.WriteLine("Congratulation !!! Vous avez gagné");
                                                gameOver = true;
                                                break;
                                            case "litCamps":
                                                Console.WriteLine("zzzz Dodo !");
                                                takkar.SetPtsVie(110f);
                                                break;
                                            case "upgradeMasse":
                                                if (takkar.GetNomArmeJoueur() == "Masse")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeArc":
                                                if (takkar.GetNomArmeJoueur() == "Arc")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "upgradeSagaie":
                                                if (takkar.GetNomArmeJoueur() == "Sagaie")
                                                {
                                                    switch (takkar.GetLevelArmeJoueur())
                                                    {
                                                        case "Low":
                                                            takkar.SetLevelArmeJoueur("Medium");
                                                            break;
                                                        case "Medium":
                                                            takkar.SetLevelArmeJoueur("High");
                                                            break;
                                                        default:
                                                            Console.WriteLine("Pas d'upgrade dispo");
                                                            break;
                                                    }
                                                }
                                                break;
                                            case "masse":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");

                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;

                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "arc":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    case "Sagaie":
                                                        takkar.SetNomArmeJoueur("Sagaie");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            case "sagaie":
                                                switch (takkar.GetNomArmeJoueur())
                                                {
                                                    case "Masse":
                                                        takkar.SetNomArmeJoueur("Masse");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Arc":
                                                        takkar.SetNomArmeJoueur("Arc");
                                                        switch (takkar.GetLevelArmeJoueur())
                                                        {
                                                            case "Medium":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            case "High":
                                                                takkar.SetLevelArmeJoueur("Low");
                                                                break;
                                                            default:
                                                                Console.WriteLine("Pas d'upgrade dispo");
                                                                break;
                                                        }
                                                        break;
                                                    case "Sagaie":
                                                        Console.WriteLine("Arme déja possédée");
                                                        break;
                                                    default:
                                                        Console.WriteLine("Pas d'arme dispo");
                                                        break;
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("pas d'upgrade dispo");
                                                break;
                                        }

                                        OrosArray[nextMoveX, takkar.GetPosY()] = 0;
                                        upgradeRepos = null;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Classe non trouvée");
                                    break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Case nature");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Veuillez entrez une des 4 fleches directionnelles s'il vous plaît");
                    break;
            }

        } while (!gameOver);
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


