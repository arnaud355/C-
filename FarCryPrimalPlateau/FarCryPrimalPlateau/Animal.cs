using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public abstract class Animal : IItem
    {
        protected string m_name { get; set; }
        protected string m_espece { get; set; }
        protected float m_ptsVie { get; set; }
        protected float m_force{ get; set; }

        protected bool m_alive = true;
        protected int m_reactivite { get; set; }

        protected int m_id { get; set; }

        protected Coords m_coords;

        public Animal(int id, string name, string espece, float ptsVie, float force, int reactivite, Coords coords) 
        { 
            m_name = name;
            m_espece = espece;
            m_ptsVie = ptsVie; 
            m_force = force;
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

        public string GetName()
        {
            return m_name;
        }
        public int GetId()
        {
            return m_id;
        }

        public int GetReactivite()
        {
            return m_reactivite;
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

        public void GetInfoOfItem()
        {
            Console.WriteLine("Je suis {0}, espece : {1},  pts vie : {2},  force : {3} ", m_name, m_espece,m_ptsVie,m_force);
        }

        public int GetPosX()
        {
            return m_coords.X;
        }

        public int GetPosY()
        {
            return m_coords.Y;
        }
    }
}
