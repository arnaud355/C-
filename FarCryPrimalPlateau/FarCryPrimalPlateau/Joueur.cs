using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public class Joueur : IItem
    {
        private float m_ptsVie { get; set; }
        private string m_name { get; set; }
        private int m_id { get; set; }

        private bool m_alive = true;

        private int m_reactivite { get; set; }

        protected Coords m_coords;

        Arme m_arme { get; set; }

        public Joueur(int id, string name, float ptsVie, int reactivite, Coords coords, Arme arme)
        {
            m_name = name;
            m_ptsVie = ptsVie;
            m_arme = arme;
            m_reactivite = reactivite;

            if (Singleton.gamesId.Contains(id))
            {
                while (Singleton.gamesId.Contains(id))
                {
                    id = Singleton.GetRandomId();
                }
            }

            Singleton.gamesId.Add(id);
            m_id = id;

            if (Singleton.gamesCoordX.Contains(coords.X) && Singleton.gamesCoordX.Contains(coords.Y))
            {
                while (Singleton.gamesCoordX.Contains(coords.X) && Singleton.gamesCoordX.Contains(coords.Y))
                {
                    coords.X = Singleton.GetRandom();
                    coords.Y = Singleton.GetRandom();
                }
            }

            Singleton.gamesCoordX.Add(coords.X);
            Singleton.gamesCoordY.Add(coords.X);
            this.m_coords = coords;
        }

        ~Joueur()
        {
            Console.WriteLine("Destructor Joueur was called");
        }
        public string GetName()
        {
            return m_name;
        }
        public bool IsAlive()
        {
            return m_alive;
        }

        public void SetIsAlive(bool living)
        {
            m_alive = living;    
        }

        public int GetId()
        {
            return m_id;
        }

        public int GetReactivite()
        {
            return m_reactivite;
        }

        public int GetPosX()
        {
            return m_coords.X;
        }

        public int GetPosY()
        {
            return m_coords.Y;
        }

        public void SetPosX(int x)
        {
            m_coords.X = x;
        }

        public void SetPosY(int y)
        {
            m_coords.Y = y;
        }
        //Polymorphisme, 3 methodes Attaque() overlode, elles prennent type d'entrée différents
        public void Attaque(Izila personne)
        {
            int degat = 0;

            if (personne != null)
            {
                if (m_arme != null)
                {
                   
                    switch (m_arme.GetNomArme())
                    {
                        case "Masse":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 10;
                                    break;
                                case "Medium":
                                    degat = degat + 20;
                                    break;
                                case "High":
                                    degat = degat + 30;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        case "Arc":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 20;
                                    break;
                                case "Medium":
                                    degat = degat + 30;
                                    break;
                                case "High":
                                    degat = degat + 40;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        case "Sagaie":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 30;
                                    break;
                                case "Medium":
                                    degat = degat + 40;
                                    break;
                                case "High":
                                    degat = degat + 50;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("DDiantre!");
                            break;
                    }
                }
                personne.SubitDegats(degat);
            }
          
        }
        public void Attaque(Udam personne)
        {
            int degat = 0;

            if (personne != null)
            {
                if (m_arme != null)
                {
                    
                    switch (m_arme.GetNomArme())
                    {
                        case "Masse":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 10;
                                    break;
                                case "Medium":
                                    degat = degat + 20;
                                    break;
                                case "High":
                                    degat = degat + 30;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        case "Arc":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 20;
                                    break;
                                case "Medium":
                                    degat = degat + 30;
                                    break;
                                case "High":
                                    degat = degat + 40;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        case "Sagaie":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 30;
                                    break;
                                case "Medium":
                                    degat = degat + 40;
                                    break;
                                case "High":
                                    degat = degat + 50;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("DDiantre!");
                            break;
                    }
                }
                personne.SubitDegats(degat);
            }

        }
        public void Attaque(Animal animal)
        {
            float degat = 0;

            if (animal != null)
            {
                if (m_arme != null)
                {

                    switch (m_arme.GetNomArme())
                    {
                        case "Masse":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 10;
                                    break;
                                case "Medium":
                                    degat = degat + 20;
                                    break;
                                case "High":
                                    degat = degat + 30;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        case "Arc":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 20;
                                    break;
                                case "Medium":
                                    degat = degat + 30;
                                    break;
                                case "High":
                                    degat = degat + 40;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        case "Sagaie":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 30;
                                    break;
                                case "Medium":
                                    degat = degat + 40;
                                    break;
                                case "High":
                                    degat = degat + 50;
                                    break;
                                default:
                                    Console.WriteLine("Diantre");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine("DDiantre!");
                            break;
                    }
                }
                animal.SubitDegats(degat);
            }
            
        }
  
        public void SubitDegats(float dommage)
        {
 
            m_ptsVie = m_ptsVie - dommage;

            Console.WriteLine("Points de vie de Takkar: {0}",m_ptsVie);
            
            if(m_ptsVie < 0)
            {
                Console.WriteLine("Mort de notre joueur {0}", m_name);
                m_ptsVie = 0;
                SetIsAlive(false);
            }
        }

        public Arme GetArme()
        {
            return m_arme;
        }

        public string GetNomArmeJoueur()
        {
            return m_arme.GetNomArme();
        }

        public string GetLevelArmeJoueur()
        {
            return m_arme.GetLevelArme();
        }

        public void SetNomArmeJoueur(string nomArme)
        {
            m_arme.SetNomArme(nomArme);
        }

        public void SetLevelArmeJoueur(string levelArme)
        {
            m_arme.SetLevelArme(levelArme);
        }

        public void CheckGameOver()
        {
            if(m_ptsVie == 0)
            {
                Console.WriteLine("Game Over");                
            }
        }

        public void GetInfoOfItem()
        {
            Console.WriteLine("Je suis {0}, pts vie : {1},  arme : {2}, niveau arme : {3}, coord X: {4}, coord Y : {5} ", m_name, m_ptsVie,m_arme.GetNomArme(),m_arme.GetLevelArme(), m_coords.X,m_coords.Y);
        }

        public void SetPtsVie(float ptsVie)
        {
            m_ptsVie += ptsVie;
            if(m_ptsVie > 110)
            {
                m_ptsVie = 110;
            }
        }
    }
}
