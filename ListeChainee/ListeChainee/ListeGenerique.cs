using System;
using System.Collections.Generic;
using System.Text;

namespace ListeChainee
{
    public class ListeGenerique<T>
    {

        private int capacite;
        private int nbElements;
        private T[] tableau;

        public int suivant { get; }
        public int precedent { get; }

        private T premierElement;
        private T dernierElement;

        public ListeGenerique()
        {
            capacite = 10;
            nbElements = 0;
            tableau = new T[capacite];

        }
        public int GetnbElements()
        {
            return nbElements;
        }
        
        public T GetSuivant(int indice)
        {
            int indiceSuivant = indice + 1;
        
            if (indiceSuivant >= nbElements)
            {
                Console.WriteLine("Pas d'element suivant");
                return default(T);
            }
            else
            {
                return tableau[indiceSuivant];
            }
                       
        }

        public T GetPrecedent(int indice)
        {
            int indicePrecedent = indice - 1;

            if (indicePrecedent < 0)
            {
                Console.WriteLine("Pas d'element precedent");
                return default(T);
            }
            else
            {
                return tableau[indicePrecedent];
            }
                    
        }
        public T GetpremierElement()
        {
            premierElement = tableau[0];
            return premierElement;
        }
        public T GetdernierElement()
        {
            dernierElement = tableau[nbElements - 1];
            return dernierElement;
        }
       
        public void Ajouter(T element)
        {
            if (nbElements >= capacite)
            {
                capacite *= 2;
                T[] copieTableau = new T[capacite];
                for (int i = 0; i < tableau.Length; i++)
                {
                    copieTableau[i] = tableau[i];
                }
                tableau = copieTableau;
            }
            tableau[nbElements] = element;
            nbElements++;
        }

        public T ObtenirElement(int indice)
        {
            if (indice < 0 || indice >= nbElements)
            {
                Console.WriteLine("L'indice n'est pas bon");
                return default(T);
            }
            return tableau[indice];
        }

        public void AjoutElementFin(T ele)
        {
            nbElements++;
            T[] copieTableau = new T[nbElements];
            for (int i = 0; i < copieTableau.Length - 1; i++)
            {
                copieTableau[i] = tableau[i];
            }
            copieTableau[nbElements - 1] = ele;
            Console.WriteLine("ele:{0}", ele);
            tableau = copieTableau;

        }
        public void GetAllElements()
        {
            for (int i = 0; i < this.GetnbElements(); i++)
            {
                Console.WriteLine(tableau[i]);
            }
        }

        public void InsertEleToIndice(T ele, int indice)
         {
             T temp, suivant;
        

             if (indice < 0 || indice >= nbElements)
             {
                 Console.WriteLine("L'indice est inférieur à zéro ou sup au nombre d'elements");
             }

             if (indice > 0)
             {
                 indice -= 1;
             }

             nbElements++;
             //On copie le tableau, en lui donnant un indice de plus, qui sera à 0 par defaut
             T[] copieTableau = new T[nbElements];
             for (int j = 0; j < nbElements - 1; j++)
             {
                 copieTableau[j] = this.tableau[j];
             }

            for (int i = indice;i < nbElements; i++)
             {
                temp = ele;
                suivant = copieTableau[i];
                copieTableau[i] = temp;              
                ele = suivant;
             }

            this.tableau = copieTableau;
           
         }
    }
}
