using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public class Joueur
    {
        private float m_ptsVie { get; set; }
        private string m_name { get; set; }
        private int points { get; set; }

        Arme m_arme { get; set; }

        public Joueur(string name, float ptsVie, Arme arme)
        {
            m_name = name;
            m_ptsVie = ptsVie;
            m_arme = arme;
        }

        ~Joueur()
        {
            Console.WriteLine("Destructor Joueur was called");
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

            Console.WriteLine(m_ptsVie);
            
            if(m_ptsVie < 0)
            {
                m_ptsVie = 0;
            }
        }

        public void CheckGameOver()
        {
            if(m_ptsVie == 0)
            {
                Console.WriteLine("Game Over");                
            }
        }
    }
}
