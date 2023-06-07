using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static FarCryPrimalPlateau.Arme;

namespace FarCryPrimalPlateau
{
    public class Izila : Human, IHeros
    {
        string m_colorClothes{ get; set; }
        bool m_heros = false;
        Arme m_arme;

        public Izila(int id, string name, int ptsVie, int reactivite, Coords coords, string colorClothes, Arme arme, bool heros = false) : base(id, name, ptsVie,reactivite, coords)
        {
            m_colorClothes = colorClothes;
            m_heros = heros;
            m_arme = arme;
        }

        public override void SubitDegats(int coup)
        {
            m_ptsVie = m_ptsVie - coup;
            if (m_ptsVie <= 0)
            {
                SetIsAlive(false);
                Console.WriteLine("Mort de {0}", m_name);
            }
        }

        public override void Attaque(Joueur joueur)
        {
            float degat = 0f;

            if( joueur != null )
            {
                if( m_arme != null )
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
                joueur.SubitDegats(degat);
            }
                  
        }

        public bool GetHeros()
        {
            return m_heros;
        }

        public void AttaqueSpecialHeros(bool heros, Joueur joueur)
        {
            int degat = 0;

            if (joueur != null)
            {
                if (m_arme != null)
                {

                    switch (m_arme.GetNomArme())
                    {
                        case "Masse":
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
                        case "Arc":
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
                        case "Sagaie":
                            switch (m_arme.GetLevelArme())
                            {
                                case "Low":
                                    degat = degat + 40;
                                    break;
                                case "Medium":
                                    degat = degat + 50;
                                    break;
                                case "High":
                                    degat = degat + 60;
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
                joueur.SubitDegats(degat);
            }
        }
    }
}
