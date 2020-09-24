using System;
using System.Collections.Generic;
using System.Text;

namespace SimulateurMeteo
{
    public class MeteoEnCours
    {
        public event EventHandler<ChangementDeTempsEventArgs> ChangementDeTemps;

        public int Temps { get; set; }
        public int Soleil { get; set; }

        public void TempsChangeant(int indice,ref double tempsChangeant)
        {
            Temps = indice;
            if (ChangementDeTemps != null)
            {
                tempsChangeant++;
                ChangementDeTemps(this, new ChangementDeTempsEventArgs { Temps = Temps });
            }
                
        }
        public void TempsSoleil(int indice,ref double tempsSoleil)
        {
            if(indice < 10)
            {
                tempsSoleil++;
            }
        }
    }
}
