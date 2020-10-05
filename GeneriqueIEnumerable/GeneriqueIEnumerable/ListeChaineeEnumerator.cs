using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeneriqueIEnumerable
{
    public class ListeChaineeEnumerator<T> : IEnumerator<T>
    {
        private Chainage<T> courant;
        private ListeChainee<T> listeChainee;

        public ListeChaineeEnumerator(ListeChainee<T> liste)
        {
            courant = null;
            listeChainee = liste;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (courant == null)
                courant = listeChainee.Premier;
            else
                courant = courant.Suivant;

            return courant != null;
        }

        public T Current
        {
            get
            {
                if (courant == null)
                    return default(T);
                return courant.Valeur;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Reset()
        {
            courant = null;
        }
    }
}
