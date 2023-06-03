﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FarCryPrimalPlateau.Arme;

namespace FarCryPrimalPlateau
{
    internal class Herbivore : Animal
    {
        private TypeHerbivore m_typeHerbivore { get; set; }

        public enum TypeHerbivore
        {
            Brouteur,
            Chargeur
        }
        public Herbivore(string name, string espece, int ptsVie, float force, Coords coords, string typeHerbivore = "Brouteur") : base(name, espece, ptsVie, force, coords)
        {
            m_typeHerbivore = (TypeHerbivore)Enum.Parse(typeof(TypeHerbivore), typeHerbivore);
        }

        public void AttaqueHerbivore(Joueur joueur)
        {
            Console.WriteLine("Attaque façon {0}", m_typeHerbivore);

            if(m_typeHerbivore == TypeHerbivore.Chargeur)
            {
                joueur.SubitDegats(m_force * 1.3f);
            }
            else
            {
                joueur.SubitDegats(m_force);
            }
            

        }
    }
}