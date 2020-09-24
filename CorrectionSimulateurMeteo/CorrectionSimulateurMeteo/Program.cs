using System;

namespace CorrectionSimulateurMeteo
{
    class Program
    {
        static void Main(string[] args)
        {
            SimulateurMeteo simulateurMeteo = new SimulateurMeteo(1000);
            Statisticien statisticien = new Statisticien(simulateurMeteo);
            statisticien.DemarrerAnalyse();
            statisticien.AfficherRapport();

            statisticien.DemarrerAnalyse();
            statisticien.AfficherRapport();

            statisticien.DemarrerAnalyse();
            statisticien.AfficherRapport();
        }
    }
}
