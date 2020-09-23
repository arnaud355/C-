using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public class Operations
    {
        public void DemoOperations()
        {
            double division = Calcul(delegate (int a, int b)
            {
                return (double)a / (double)b;
            }, 4, 5);

            double puissance = Calcul(delegate (int a, int b)
            {
                return Math.Pow((double)a, (double)b);
            }, 4, 5);

            Console.WriteLine("Division : " + division);
            Console.WriteLine("Puissance : " + puissance);
        }
        /*
         * Avec les expressions lambdas (raccourcis), calcul peut se simplifier:
        double division = Calcul((a, b) =>
        {
            return (double)a / (double)b;
        }, 4, 5);

        //Lorsque l’instruction possède une unique ligne, on peut encore simplifier l’écriture, ce qui donne :
        double division = Calcul((a, b) => (double)a / (double)b, 4, 5);
         */

        /* Lorsque la méthode renvoie quelque chose, on peut utiliser le délégué Func<T>, sachant qu’ici, 
         * c’est le dernier paramètre générique qui sera du type de retour du délégué. Par exemple :
         * Ici, dans la méthode Calcul, on utilise le délégué Func pour indiquer que la méthode
         * prend deux entiers en paramètres et renvoie un double.
         * */
        private double Calcul(Func<int, int, double> methodeDeCalcul, int a, int b)
        {
            return methodeDeCalcul(a, b);
        }
    }
}
