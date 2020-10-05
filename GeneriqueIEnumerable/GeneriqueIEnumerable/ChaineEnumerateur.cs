using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeneriqueIEnumerable
{
    public class ChaineEnumerateur : IEnumerator<char>
    {
        private string chaine;
        private int indice;

        public ChaineEnumerateur(string valeur)
        {
            indice = -1;
            chaine = valeur;
        }

        public char Current
        {
            get { return chaine[indice]; }
        }

        public void Dispose()
        {
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            indice++;
            return indice < chaine.Length;
        }

        public void Reset()
        {
            indice = -1;
        }
    }
}
