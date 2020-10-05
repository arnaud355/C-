using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MaBibliotheque
{
    public class Bonjour
    {
        public void DireBonjour()
        {
            Console.WriteLine("Bonjour depuis la bibliothèque MaBibliotheque");
            for (int i = 0; i < 10000; i++)
            {
                if (AForge.Math.Tools.IsPowerOf2(i))
                    Console.WriteLine(i + " est une puissance de 2");
            }
        }
    }
}
