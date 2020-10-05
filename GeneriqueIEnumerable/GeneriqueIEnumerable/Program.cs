using System;
using System.Collections.Generic;

namespace GeneriqueIEnumerable
{
    class Program
    {
        public static IEnumerable<string> ObtenirListeDePrenoms()
        {
            yield return "Nicolas";
            yield return "Jérémie";
            yield return "Delphine";
        }

        static void Main(string[] args)
        {
            IEnumerable<string> prenoms = ObtenirListeDePrenoms();
            Console.WriteLine("On fait des choses ...");
            foreach (string prenom in prenoms)
            {
                Console.WriteLine(prenom);
            }
        }
    }
}
