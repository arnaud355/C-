using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static FarCryPrimalPlateau.Arme;

namespace FarCryPrimalPlateau
{
    public class UpgradeRepos : IItem
    {

        private NomUpgrade m_upgrade { get; set; }

        private int m_id { get; set; }

        private Coords m_coords;

        public enum NomUpgrade
        {
            graal,
            litCamps,
            upgradeMasse,
            upgradeArc,
            upgradeSagaie,
            masse,
            arc,
            sagaie
        }

        public UpgradeRepos(int id,NomUpgrade nomUpgrade, Coords coords)
        {
            m_upgrade = nomUpgrade;
            m_coords = coords;

            if (Singleton.gamesId.Contains(id))
            {
                while (Singleton.gamesId.Contains(id))
                {
                    id = Singleton.GetRandomId();
                }
            }

            Singleton.gamesId.Add(id);
            m_id = id;
        }

        public int GetId()
        {
            return m_id;
        }

        public int GetReactivite()
        {
            return 0;
        }

        public void GetInfoOfItem()
        {
            
            Console.WriteLine("J'obtiens {0}", m_upgrade);
        }


        public int GetPosX()
        {
            return m_coords.X;
        }

        public int GetPosY()
        {
            return m_coords.Y;
        }
    }
}
