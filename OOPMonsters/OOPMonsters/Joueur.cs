using System;
using System.Collections.Generic;
using System.Text;

namespace OOPMonsters
{
    public class Joueur
    {
        public Joueur()
        {

        }
        public Joueur(string name, int ptsVie)
        {
            this.m_name = name;
            this.m_ptsVie = ptsVie;
        }
        public int m_ptsVie { get; set; }
        public string m_name { get; protected set; }
        public int points { get; set; }
        
        //Polymorphisme, 3 methodes Attaque() overlode, elles prennent type d'entrée différents
        public void Attaque(MonstreFacile monstre)
        {
            monstre.SetIsAlive(false);
        }
        public void Attaque(MonstreDifficile monstre)
        {
            monstre.SetIsAlive(false);
        }
        public void Attaque(Boss monstre)
        {
            int borneMax = 26;
            int degat = Des.LanceDe(borneMax);
            monstre.SubitDegats(degat);
        }
        public void SubitDegats()
        {
            int degat = 0;
            degat = Des.LanceDe();
            if (degat > 2)
            {
                this.m_ptsVie = this.m_ptsVie - 10;
            }
        }
        public void SubitDegats(int dommage)
        {     
            int nivResistanceBouclier = 15;

            if (dommage > nivResistanceBouclier)
            {
                this.m_ptsVie = this.m_ptsVie - dommage;
                nivResistanceBouclier -= 3;
            }
        }
    }
}
