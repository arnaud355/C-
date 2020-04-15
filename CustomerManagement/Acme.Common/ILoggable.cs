using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public interface ILoggable
    {
        /*Cette methode est héritée par plusieurs classes, mais les implementations
        peuvent être différentes d'une classe à l'autre*/
        /*Une interface permet un typage fort, des parties communes à de classes sans rapport
         * aide à construise des methods d'utilités générales.
         * Elle définie le rôle qu'un objet peut jouer.
         * chaque classes peut avoir une implémentation differente de la methode héritée
         */
        string Log();
    }
}
