using System;
using System.Collections.Generic;
using System.Text;

namespace GeneriqueIEnumerable
{
   
        //[…Code identique au TP précédent…]

        public class ListeChainee<T> : IEnumerable<T>
        {
            public Chainage<T> Premier { get; private set; }

            public Chainage<T> Dernier
            {
                get
                {
                    if (Premier == null)
                        return null;
                    Chainage<T> dernier = Premier;
                    while (dernier.Suivant != null)
                    {
                        dernier = dernier.Suivant;
                    }
                    return dernier;
                }
            }

            public void Ajouter(T element)
            {
                if (Premier == null)
                {
                    Premier = new Chainage<T> { Valeur = element };
                }
                else
                {
                    Chainage<T> dernier = Dernier;
                    dernier.Suivant = new Chainage<T> { Valeur = element, Precedent = dernier };
                }
            }

            public Chainage<T> ObtenirElement(int indice)
            {
                Chainage<T> temp = Premier;
                for (int i = 1; i <= indice; i++)
                {
                    if (temp == null)
                        return null;
                    temp = temp.Suivant;
                }
                return temp;
            }

            public void Inserer(T element, int indice)
            {
                if (indice == 0)
                {
                    if (Premier == null)
                        Premier = new Chainage<T> { Valeur = element };
                    else
                    {
                        Chainage<T> temp = Premier;
                        Premier = new Chainage<T> { Suivant = temp, Valeur = element };
                        temp.Precedent = Premier;
                    }
                }
                else
                {
                    Chainage<T> elementAIndice = ObtenirElement(indice);
                    if (elementAIndice == null)
                        Ajouter(element);
                    else
                    {
                        Chainage<T> precedent = elementAIndice.Precedent;
                        Chainage<T> temp = precedent.Suivant;
                        precedent.Suivant = new Chainage<T> { Valeur = element, Precedent = precedent, Suivant = temp };
                        temp.Precedent = precedent.Suivant;
                    }
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                Chainage<T> courant = Premier;
                while (courant != null)
                {
                    yield return courant.Valeur;
                    courant = courant.Suivant;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
}
