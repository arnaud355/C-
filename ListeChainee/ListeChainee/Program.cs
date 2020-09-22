using System;
using System.Collections;

namespace ListeChainee
{
    class Program
    {
        static void Main(string[] args)
        {
            ListeGenerique<int> maListe = new ListeGenerique<int>();
            maListe.Ajouter(24);
            maListe.Ajouter(25);
            maListe.Ajouter(21);

            Console.WriteLine(maListe.ObtenirElement(0));
            Console.WriteLine(maListe.ObtenirElement(1));
            Console.WriteLine(maListe.ObtenirElement(2));

            Console.WriteLine("Element precedent: {0}", maListe.GetPrecedent(0));
            Console.WriteLine("Element precedent: {0}", maListe.GetPrecedent(2));
            Console.WriteLine("Element suivant: {0}", maListe.GetSuivant(1));
            Console.WriteLine("Element suivant: {0}", maListe.GetSuivant(257));


            maListe.AjoutElementFin(5);
            maListe.AjoutElementFin(10);
            maListe.AjoutElementFin(4);

            Console.WriteLine("liste d'elements:");
            for (int i = 0; i < maListe.GetnbElements(); i++)
            {
                maListe.GetSuivant(i);
            }
            for (int i = maListe.GetnbElements() - 1; i >= 0; i--)
            {
                maListe.GetPrecedent(i);
            }
            Console.WriteLine("premier element: {0}", maListe.GetpremierElement());
            Console.WriteLine("dernier element: {0}", maListe.GetdernierElement());

            maListe.InsertEleToIndice(99, 0);
            maListe.InsertEleToIndice(33, 2);
            maListe.InsertEleToIndice(30, 2);

            maListe.GetAllElements();

            Console.WriteLine("***********");
            int eleToSupp = 21;
            maListe.DelEleToIndice(eleToSupp);
            Console.WriteLine("{0} a été supprimé:", eleToSupp);
            maListe.GetAllElements();

            Console.WriteLine("***********");        
            eleToSupp = 33;
            maListe.DelEleToIndice(eleToSupp);
            Console.WriteLine("{0} a été supprimé:", eleToSupp);
            maListe.GetAllElements();
            Console.WriteLine("***********");
            maListe.SuppListe();
            Console.WriteLine("La liste entière a été suprimé:");
            maListe.GetAllElements();

            /*
            for (int i = 0; i < 30; i++)
            {
                maListe.Ajouter(i);
            } */
        }
    }
}

