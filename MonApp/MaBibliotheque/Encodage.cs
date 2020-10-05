using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaBibliotheque
{
    /* C’est avec les assemblys que le mot-clé internal prend tout son sens. Il permet d’indiquer qu’une
     * classe, méthode ou propriété ne sera accessible qu’à l’intérieur d’une assembly.
       Cela permet par exemple qu’une classe soit utilisable par toutes les autres classes de cette 
       assembly mais qu’elle ne puisse pas être utilisée par une application référençant l’assembly.

        À noter qu’il existe enfin le mot-clé protected internal qui permet d’indiquer que des éléments 
        sont accessibles à un niveau internal pour les classes d’une même assembly mais protected pour
        les autres assemblys, ce qui permet d’appliquer les principes de substitutions ou d’héritage.
       */

    internal static class Encodage
    {
        internal static string Crypte(this string chaine)
        {
            return Convert.ToBase64String(Encoding.Default.GetBytes(chaine));
        }

        internal static string Decrypte(this string chaine)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(chaine));
        }
    }
}
