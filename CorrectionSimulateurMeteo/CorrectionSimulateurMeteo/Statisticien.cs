using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionSimulateurMeteo
{
    public class Statisticien
    {
        private SimulateurMeteo simulateurMeteo;
        private int nombreDeFoisOuLeTempsAChange;
        private int nombreDeFoisOuIlAFaitSoleil;

        public Statisticien(SimulateurMeteo simulateur)
        {
            simulateurMeteo = simulateur;
            nombreDeFoisOuLeTempsAChange = 0;
            nombreDeFoisOuIlAFaitSoleil = 0;
        }

        public void DemarrerAnalyse()
        {
            nombreDeFoisOuLeTempsAChange = 0;
            nombreDeFoisOuIlAFaitSoleil = 0;
            simulateurMeteo.QuandLeTempsChange += simulateurMeteo_QuandLeTempsChange;
            simulateurMeteo.Demarrer();
            //On se désabonne de l évenement si on l'utilise plus
            simulateurMeteo.QuandLeTempsChange -= simulateurMeteo_QuandLeTempsChange;
        }

        public void AfficherRapport()
        {
            Console.WriteLine("Nombre de fois où le temps a changé : " + nombreDeFoisOuLeTempsAChange);
            Console.WriteLine("Nombre de fois où il a fait soleil : " + nombreDeFoisOuIlAFaitSoleil);
            Console.WriteLine("Pourcentage de beau temps : " + nombreDeFoisOuIlAFaitSoleil * 100 / nombreDeFoisOuLeTempsAChange + " %");
        }

        private void simulateurMeteo_QuandLeTempsChange(Temps temps)
        {
            if (temps == Temps.Soleil)
                nombreDeFoisOuIlAFaitSoleil++;
            nombreDeFoisOuLeTempsAChange++;
        }
    }
}
