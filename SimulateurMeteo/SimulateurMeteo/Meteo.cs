using System;
using System.Collections.Generic;
using System.Text;

namespace SimulateurMeteo
{
    public class Meteo
    {
        public void Weather()
        {
            Random random = new Random();
            int indiceMeteo = random.Next(0, 101);
            double tempschangeant = 0;
            double tempsSoleil = 0;
            double pourcentageSoleil = 0;

            MeteoEnCours meteo = new MeteoEnCours { Temps = indiceMeteo };
            int compteurTemps = 72;

            for (int i = 0; i < compteurTemps; i++)
            {
                indiceMeteo = random.Next(0, 101);
                meteo.TempsChangeant(indiceMeteo,ref tempschangeant);
                meteo.TempsSoleil(indiceMeteo,ref tempsSoleil);
                meteo.ChangementDeTemps += meteo_ChangementDeTemps;
                //meteo.ChangementDeTemps += meteo_Ensolleile;
            }

            pourcentageSoleil = tempsSoleil / tempschangeant;
            pourcentageSoleil = pourcentageSoleil * 100;

            Console.WriteLine("Le temps a changé {0} fois", tempschangeant + 1);
            Console.WriteLine("Le temps a ete ensoleillé {0} fois", tempsSoleil + 1);
            Console.WriteLine("Le pourcentage d'ensoleillement est de {0}%", pourcentageSoleil);
        }
        private void meteo_ChangementDeTemps(object sender, ChangementDeTempsEventArgs e)
        {
            
            Console.WriteLine("Le nouveau temps a un indice de : " + e.Temps);
            if (e.Temps < 10)
            {
                Console.WriteLine("Il y a du soleil!");
            }
            else if (e.Temps >= 10 && e.Temps < 50)
            {
                Console.WriteLine("Le temps est nuageux");
            }
            else if (e.Temps >= 50 && e.Temps < 90)
            {
                Console.WriteLine("Le temps est pluvieux");
            }
            else
            {
                Console.WriteLine("L'orage gronde!");
            }
        }
       /* private void meteo_Ensolleile(object sender, ChangementDeTempsEventArgs e)
        {
            Console.WriteLine("Il y fait beau!");
        }*/
    }
}
