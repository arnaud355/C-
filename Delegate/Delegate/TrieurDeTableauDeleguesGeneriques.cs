using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public class TrieurDeTableauDeleguesGeneriques
    {
        /* Le délégué Action est un délégué qui permet de pointer vers une méthode qui ne renvoie 
           rien et qui peut accepter jusqu’à 16 types différents.*/

        /* Notez que la différence se situe au niveau du paramètre de la méthode TrierEtAfficher qui 
         * prend un Action<int[]>. En fait, cela est équivalent à créer un délégué qui ne renvoie rien 
         * et qui prend un tableau d’entier en paramètre.
            Si notre méthode avait deux paramètres, il aurait suffi d’utiliser la forme de Action 
            avec plusieurs paramètres génériques, par exemple Action<int[], string> pour avoir une
            méthode qui ne renvoie rien et qui prend un tableau d’entier et une chaine de 
            caractères en paramètres.
        
         */
        private void TrierEtAfficher(int[] tableau, Action<int[]> methodeDeTri)
        {
            methodeDeTri(tableau);
            foreach (int i in tableau)
            {
                Console.WriteLine(i);
            }
        }

        public void DemoTri(int[] tableau)
        {
            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
            });

            Console.WriteLine();

            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                Array.Reverse(leTableau);
            });
        }
    }
}
