using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionSimulateurMeteo
{
    public enum Temps
    {
        Soleil,
        Nuage,
        Pluie,
        Orage
    }
    public class SimulateurMeteo
    {
        private Temps? ancienTemps;
        private int nombreDeRepetitions;
        private Random random;
        //public delegate void IlFaitBeauDelegate(Temps temps);
        //public event IlFaitBeauDelegate QuandLeTempsChange;
        /*Enfin, nous pouvons simplifier notre code en ne créant pas notre délégué. Effectivement, 
         * dans la mesure où celui-ci possède un seul paramètre, il est possible de le remplacer par 
         * le délégué Action<T>*/
        public event Action<Temps> QuandLeTempsChange;

        public SimulateurMeteo()
        {

        }
        public SimulateurMeteo(int nombre)
        {
            random = new Random();
            ancienTemps = null;
            nombreDeRepetitions = nombre;
        }

        public void Demarrer()
        {
            for (int i = 0; i < nombreDeRepetitions; i++)
            {
                int valeur = random.Next(0, 100);
                if (valeur < 5)
                    GererTemps(Temps.Soleil);
                else
                {
                    if (valeur < 50)
                        GererTemps(Temps.Nuage);
                    else
                    {
                        if (valeur < 90)
                            GererTemps(Temps.Pluie);
                        else
                            GererTemps(Temps.Orage);
                    }
                }
            }
        }
        private void GererTemps(Temps temps)
        {
            if (ancienTemps.HasValue && ancienTemps.Value != temps && QuandLeTempsChange != null)
                QuandLeTempsChange(temps);
            ancienTemps = temps;
        }
    }
}
