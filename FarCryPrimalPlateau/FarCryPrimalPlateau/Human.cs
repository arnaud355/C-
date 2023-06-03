using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FarCryPrimalPlateau
{
    public abstract class Human
    {
        protected string m_name { get; set; }
        protected int m_id = 0;
        protected int m_ptsVie { get; set; }
        protected bool m_alive = true;

        protected Coords m_coords;

        public Human(string name, int id,int ptsVie, Coords coords)
        {
            // Constructor Statements
            m_name = name;
            m_id = id;
            m_ptsVie = ptsVie;

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
        public void GetUserDetails()
        {
            Console.WriteLine("Id: {0}, Name: {1}, Pts vie: {2}", m_id, m_name,m_ptsVie);
        }

        public bool GetIsAlive()
        {
            return m_alive;
        }
        public void SetIsAlive(bool value)
        {
            m_alive = value;
        }

        public int GetPosX()
        {
            return m_coords.X;
        }

        public int GetPosY()
        {
            return m_coords.Y;
        }

        public virtual void Attaque(Joueur joueur)
        {

        }
        public virtual void SubitDegats(int coup)
        {
            m_ptsVie = m_ptsVie - coup;
            if (m_ptsVie <= 0)
            {
                SetIsAlive(false);
                Console.WriteLine("Mort de {0}",m_name);
            }
        }
    }
}
