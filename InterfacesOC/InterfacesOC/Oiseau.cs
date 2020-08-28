using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesOC
{
   public class Oiseau : IVolant
    {
        public int NombrePropulseurs { get; set; }

        public void Voler()
        {
            Console.WriteLine("Je vole grâce à " + NombrePropulseurs + " ailes");
        }
    }
}
