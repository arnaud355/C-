using System;

namespace OOPMonsters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in the Magic world!");
            
            int mode = 0;

            Console.WriteLine("Quelle mode de jeu ? 1 ou 2");
            // Converted string to int 
            mode = Convert.ToInt32(Console.ReadLine());

            if (mode == 1)
            {
                Joueur joueur = new Joueur("Isildur", 150);
                Random randomMonster = new Random();
                int tirageMonster = 0;
                int desJoueur = 0;
                int desMonstreDifficile = 0;
                int desMonstre = 0;
                bool notGameOver = true;
                int id = 0;
                bool rejouer = true;
                string jouer = "";

                do
                {
                    while (notGameOver)
                    {
                        tirageMonster = randomMonster.Next(1, 3);
                        if (tirageMonster == 1)
                        {
                            MonstreDifficile beast = new MonstreDifficile(id);
                            id++;
                            desJoueur = Des.LanceDe();
                            desMonstreDifficile = Des.LanceDe();

                            if (desJoueur >= desMonstreDifficile)
                            {
                                joueur.Attaque(beast);
                            }
                            else
                            {
                                joueur.SubitDegats();
                                // sort monstre
                                beast.JeterSort(joueur);
                            }
                        }
                        else
                        {
                            MonstreFacile beast = new MonstreFacile(id);
                            id++;                  
                            desJoueur = Des.LanceDe();
                            desMonstre = Des.LanceDe();
                            if (desJoueur >= desMonstreDifficile)
                            {
                                joueur.Attaque(beast);
                            }
                            else
                            {
                                joueur.SubitDegats();
                            }
                        }
                        if (joueur.m_ptsVie <= 0)
                        {
                            notGameOver = false;
                        }
                    }

                    if (!notGameOver)
                    {
                        joueur.points = MonstreFacile.compteurMonstre + (MonstreDifficile.compteurMonstreDifficile * 2);
                        Console.WriteLine("Le joueur {0} a tué {1} monstres difficiles et {2} monstres faciles, {3} points gagnés", joueur.m_name, MonstreDifficile.compteurMonstreDifficile, MonstreFacile.compteurMonstre, joueur.points);
                        Console.WriteLine("Voulez vous rejouer o/n ?");
                        jouer = Console.ReadLine();
                    }
                    if(jouer != "o")
                    {
                        rejouer = false;
                    }
                } while (rejouer);
            }
            else if (mode == 2)
            {
                Random random = new Random();
                Joueur joueur = new Joueur("Isildur", 150);
                Boss boss = new Boss(250);
                bool continuer = true;

                while(continuer)
                {

                    if (random.Next(2) == 1)
                    {
                        boss.Attaque(joueur);
                        Console.WriteLine("Boss attacks, he has {0}", boss.m_ptsVie);
                    }
                    else
                    {
                        joueur.Attaque(boss);
                        Console.WriteLine("{0} attacks, he has {1}", joueur.m_name, joueur.m_ptsVie);
                    }
                    if(joueur.m_ptsVie <= 0)
                    {
                        Console.WriteLine("{0} is dead", joueur.m_name);
                    }
                    if (!boss.GetIsAlive())
                    {
                        Console.WriteLine("You killed the boss");
                    }
                    if (joueur.m_ptsVie <= 0 || !boss.GetIsAlive())
                    {
                        continuer = false;
                    }
                }

                if(joueur.m_ptsVie > 0)
                {
                    Console.WriteLine("{0} wins with {1}", joueur.m_name, joueur.m_ptsVie);
                }
                else
                {
                    Console.WriteLine("Boss wins with {0}", boss.m_ptsVie);
                }
                
            }
            else
            {
                Console.WriteLine("Entrez 1 ou 2");
            }
            

               

        }
    }
}
