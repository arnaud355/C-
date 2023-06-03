using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FarCryPrimalPlateau
{
    public class UpgradeRepos : IItem
    {
        string m_litCamps { get; set; }
        string m_upgradeMasse { get; set; }
        string m_upgradeArc { get; set; }
        string m_upgradeSagaie { get; set; }

        string m_masse { get; set; }
        string m_arc { get; set; }
        string m_sagaie { get; set; }
        string m_graal { get; set; }

        public UpgradeRepos(string litCamps = "non", string upgradeMasse = "non", string upgradeArc = "non", string upgradeSagaie = "non", string masse = "non", string arc = "non", string sagaie = "non", string graal = "non")
        {
            this.m_litCamps = litCamps;
            this.m_upgradeMasse = upgradeMasse;
            this.m_upgradeArc = upgradeArc;
            this.m_upgradeSagaie = upgradeSagaie;
            this.m_masse = masse;
            this.m_arc = arc;
            this.m_sagaie = sagaie;
            this.m_graal = graal;
        }

        public void GetInfoOfItem()
        {
            Console.WriteLine("Je suis {0}, pts vie : {1},  pts vie : {2}", m_litCamps, m_graal);
        }
    }
}
