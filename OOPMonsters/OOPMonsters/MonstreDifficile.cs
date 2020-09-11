using System;
using System.Collections.Generic;
using System.Text;

namespace OOPMonsters
{
    public class MonstreDifficile : MonstreFacile
    {
        public MonstreDifficile()
        {
   
        }
        public MonstreDifficile(int Id)
        {
            compteurMonstreDifficile++;
            m_Id = Id;
        }
        public static int compteurMonstreDifficile { get; set; }
        public void JeterSort(Joueur joueur)
        {
            int sort = 0;
            int coupSubi = 0;
            sort = Des.LanceDe();

            if(sort != 6)
            {
                coupSubi *= sort;
                joueur.m_ptsVie -= coupSubi; 
            }
        }

    }
}
