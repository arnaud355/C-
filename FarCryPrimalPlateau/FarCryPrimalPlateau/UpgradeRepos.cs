using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public class UpgradeRepos
    {
        string litCamps { get; set; }
        string upgradeMasse { get; set; }
        string upgradeArc { get; set; }
        string upgradeSagaie { get; set; }

        string masse { get; set; }
        string arc { get; set; }
        string sagaie { get; set; }
        string graal { get; set; }

        public UpgradeRepos(string litCamps = "non", string upgradeMasse = "non", string upgradeArc = "non", string upgradeSagaie = "non", string masse = "non", string arc = "non", string sagaie = "non", string graal = "non")
        {
            this.litCamps = litCamps;
            this.upgradeMasse = upgradeMasse;
            this.upgradeArc = upgradeArc;
            this.upgradeSagaie = upgradeSagaie;
            this.masse = masse;
            this.arc = arc;
            this.sagaie = sagaie;
            this.graal = graal;
        }
    }
}
