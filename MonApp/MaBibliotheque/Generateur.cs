using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    public static class Generateur
    {
        public static string ObtenirIdentifiantUnique()
        {
            Random r = new Random();
            string chaine = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                chaine += r.Next(0, 100);
            }
            return chaine.Crypte();
        }
    }
}
