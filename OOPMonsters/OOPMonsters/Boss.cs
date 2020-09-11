using System;
using System.Collections.Generic;
using System.Text;

namespace OOPMonsters
{
    public class Boss : Ennemi
    {
        public Boss()
        {

        }
        public Boss(int ptsVie)
        {
            m_ptsVie = ptsVie;
        }

        public override void Attaque(Joueur joueur)
        {
            int borneMax = 26;
            int degat = Des.LanceDe(borneMax);
            joueur.SubitDegats(degat);
        }
    }
}
