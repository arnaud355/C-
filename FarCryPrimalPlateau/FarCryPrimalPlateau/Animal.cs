using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public abstract class Animal
    {
        protected string m_name { get; set; }
        protected string m_espece { get; set; }
        protected float m_ptsVie { get; set; }
        protected float m_force{ get; set; }

        protected bool m_alive = true;

        protected Coords m_coords;

        public Animal(string name, string espece, float ptsVie, float force, Coords coords) 
        { 
            m_name = name;
            m_espece = espece;
            m_ptsVie = ptsVie; 
            m_force = force;

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

        public bool GetIsAlive()
        {
            return m_alive;
        }
        public void SetIsAlive(bool value)
        {
            m_alive = value;
        }

        public virtual void SubitDegats(float coup)
        {
            m_ptsVie = m_ptsVie - coup;
            if (m_ptsVie <= 0)
            {
                SetIsAlive(false);
                Console.WriteLine("Mort de {0}", m_name);
            }
        }
    }
}
