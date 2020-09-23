using System;

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tableau = new int[] { 4, 1, 6, 10, 8, 5 };
            new TrieurDeTableau().DemoTri(tableau);

            Console.WriteLine();
            Console.WriteLine("*******************");

            int[] tableau2 = new int[] { 98, 96, 46, 20, 12, 42 };
            new TrieurDeTableauDeleguesGeneriques().DemoTri(tableau);

            new Operations().DemoOperations();
        }
    }
}
