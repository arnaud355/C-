using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class LoggingService
    {
        /*On peut préciser le type avec l'interface ILoggable, quelques soit
        l'instance, sa classe a héritée d'une méthode de l'interface
         */
        public static void WriteToFile(List<ILoggable> itemsToLog)
        {
            foreach(var item in itemsToLog)
            {
                Console.WriteLine(item.Log());
            }
        }
    }
}
