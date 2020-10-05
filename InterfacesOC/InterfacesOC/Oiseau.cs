using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesOC
{
   public class Oiseau : IVolant
    {
        public int M_NombrePropulseurs { get; set; }

        public Oiseau()
        {

        }
        public Oiseau(int NombrePropulseurs)
        {
            M_NombrePropulseurs = NombrePropulseurs;
        }

        public void Voler()
        {
            Console.WriteLine("Je vole grâce à " + M_NombrePropulseurs + " ailes");
        }
    }
}
