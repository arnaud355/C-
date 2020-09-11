using System;
using System.Collections.Generic;
using System.Text;

namespace OOPMonsters
{
    public abstract class Ennemi
    {
        public int m_ptsVie { get; set; }
        protected bool alive = true;
        public bool GetIsAlive()
        {
            return alive;       
        }
        public void SetIsAlive(bool value)
        {
            alive = value;
        }
    
        public virtual void Attaque(Joueur joueur)
        {

        }
        public void SubitDegats(int coup)
        {
            this.m_ptsVie = this.m_ptsVie - coup;
            if(this.m_ptsVie <= 0)
            {
                this.SetIsAlive(false);
            }
        }
    }
}
