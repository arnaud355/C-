using System;
using System.Collections.Generic;
using System.Text;

namespace Delegate
{
    public class TrieurDeTableau
    {
        /*delegate est une sorte de variable qui pointe sur l'adresse de toutes méthodes qui à la
        même signature (les mêmes type en paramètres), elle peut avoir plusieurs adresses de méthodes
        (multicast), à condition qu'on les affectent bien sûr*/
        private delegate void DelegateTri(int[] tableau);

        private void TriAscendant(int[] tableau)
        {
            //Array.Sort(tableau);
        }

        private void TriDescendant(int[] tableau)
        {
            //Array.Sort(tableau);
            //Array.Reverse(tableau);
        }

        public void DemoTri(int[] tableau)
        {
            /*Le fait de définir la méthode directement au niveau du paramètre d’appel est ce qu’on appelle 
              « utiliser une méthode anonyme ». Anonyme car la méthode n’a pas de nom. 
              Elle n’a de vie qu’à cet endroit - là. La syntaxe est un peu particulière, mais au lieu 
              d’utiliser une variable de type delegate qui pointe vers une méthode, 
              c’est comme si on écrivait directement la méthode.
              On utilise le mot-clé delegate suivi de la déclaration du paramètre. 
              Évidemment, le délégué anonyme doit respecter la signature de DelegateTri que nous avons
              définie plus haut.Enfin, nous faisons suivre avec un bloc de code qui correspond 
              au corps de la méthode anonyme */

            /*Le  fait d’utiliser le mot - clé delegate revient en fait à créer une classe qui dérive 
              de System.Delegate et qui implémente la logique de base d’un délégué.
              Le C# nous masque tout ceci afin d’être au maximum efficace. */

            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
            });

            //Expression Lambda: expressions raccourcis:
            /*
            DelegateTri tri = delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
            };

            //Le code au dessus, peut s'écrire aussi de cette manière:
            DelegateTri tri = (leTableau) =>
            {
                Array.Sort(leTableau);
            };
            
            //L’expression lambda « (leTableau) => » se lit : « leTableau conduit à ».


             */
            Console.WriteLine();

            TrierEtAfficher(tableau, delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                Array.Reverse(leTableau);
            });

        }

        //La même méthode DemoTri,(Mis avec un A à la fin) mais avec méthodes anonymes
        public void DemoTriA(int[] tableau)
        {
            DelegateTri tri = delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                foreach (int i in leTableau)
                {
                    Console.WriteLine(i);
                }
                Console.WriteLine();
            };
            tri += delegate (int[] leTableau)
            {
                Array.Sort(leTableau);
                Array.Reverse(leTableau);
                foreach (int i in leTableau)
                {
                    Console.WriteLine(i);
                }
            };
            tri(tableau);
        }

        //Les 2 méthodes, vont être affectées dans la variable methodeDeTri de type delegate
        private void TrierEtAfficher(int[] tableau, DelegateTri methodeDeTri)
        {
            methodeDeTri(tableau);
            foreach (int i in tableau)
            {
                Console.WriteLine(i);
            }
        }
    }
}
