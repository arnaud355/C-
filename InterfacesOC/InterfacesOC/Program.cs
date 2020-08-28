using System;
using System.Collections.Generic;

namespace InterfacesOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture[] voitures = new Voiture[] { new Voiture { Vitesse = 100 }, new Voiture { Vitesse = 40 }, new Voiture { Vitesse = 10 }, new Voiture { Vitesse = 40 }, new Voiture { Vitesse = 50 } };
            Array.Sort(voitures);
            foreach (Voiture v in voitures)
            {
                Console.WriteLine(v.Vitesse);
            }


            Oiseau oiseau = new Oiseau { NombrePropulseurs = 2 };
            Avion avion = new Avion { NombrePropulseurs = 4, NomDuCommandant = "Nico" };

            List<IVolant> volants = new List<IVolant> { oiseau, avion };
            foreach (IVolant volant in volants)
            {
                volant.Voler();
                Avion a = volant as Avion;
                if (a != null)
                {
                    a.DemarrerLeMoteur();
                    a.Rouler();
                    Console.WriteLine(a.NomDuCommandant);
                }
            }
        }
    }
}
