using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public class Arme
    {
        private NomArme m_nomArme { get; set; }
        private LevelArme m_LevelArme { get; set; }

        // Masse: niv 1 : -10, niv 2 : -20, niv3 : -30
        // Arc: niv 1 : -20, niv 2 : -30, niv3 : -40
        // Sagaie: niv 1 : -30, niv 2 : -40, niv3 : -50
        public enum NomArme
        {
            Masse,
            Arc,
            Sagaie
        }

        public enum LevelArme
        {
            Low,
            Medium,
            High
        }

        public Arme(string nomArme, string levelArme) 
        {
            m_nomArme = (NomArme)Enum.Parse(typeof(NomArme), nomArme);
            m_LevelArme = (LevelArme)Enum.Parse(typeof(LevelArme), levelArme);
        }

        public string GetNomArme()
        {
            string name = m_nomArme.ToString();
            return name;
        }

        public string GetLevelArme()
        {
            string name = m_LevelArme.ToString();
            return name;
        }
    }
}
