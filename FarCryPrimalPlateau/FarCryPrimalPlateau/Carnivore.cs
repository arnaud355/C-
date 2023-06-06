using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FarCryPrimalPlateau.Herbivore;

namespace FarCryPrimalPlateau
{
    public class Carnivore : Animal, ICarnivore
    {
        private TypeCarnivore m_typeDeCarnivore { get; set; }

        public enum TypeCarnivore
        {
            Canide,
            Felin,
            PredateurPuissant,
        }

        public Carnivore(int id, string name, string espece, int ptsVie, float force, int reactivite, string typeCarnivore, Coords coords) : base(id, name, espece, ptsVie, force, reactivite, coords)
        {
            m_typeDeCarnivore = (TypeCarnivore)Enum.Parse(typeof(TypeCarnivore), typeCarnivore);
        }

        public void AttaqueCarnivore(Joueur joueur)
        {
            Console.WriteLine("Attaque façon {0}", m_typeDeCarnivore);
  
            if (m_typeDeCarnivore == TypeCarnivore.Canide)
            {
                joueur.SubitDegats(m_force * 1.1f);
            }
            else if(m_typeDeCarnivore == TypeCarnivore.Felin)
            {
                joueur.SubitDegats(m_force * 1.3f);
            }
            else
            {
                joueur.SubitDegats(m_force * 1.7f);
            }

        }
    }
}
