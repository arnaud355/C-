using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GeneriqueIEnumerable
{
    public class ChaineEnumerable : IEnumerable<char>
    {
        private string chaine;
        public ChaineEnumerable(string valeur)
        {
            chaine = valeur;
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < chaine.Length; i++)
            {
                yield return chaine[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
