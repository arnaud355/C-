using System;
using System.Collections.Generic;
using System.Text;

namespace OOPMonsters
{
    public class MonstreFacile : Ennemi
    {
        public MonstreFacile()
        {
     
        }
        public MonstreFacile(int Id)
        {
            compteurMonstre++;
            m_Id = Id;
        }
        public static int compteurMonstre { get; set; }
        public int m_Id { get; set; }
        
      

    }
}
