using System;
using MaBibliotheque;
namespace MonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture voitureArn = new Voiture(); // vitesse vaut 5
            Voiture voitureRom = new Voiture(125,"bleue"); // vitesse vaut 20

            voitureArn.Rouler();
            voitureRom.Rouler();
            Console.WriteLine(voitureRom.Couleur);
            MaBibliotheque.Bonjour bonjour = new MaBibliotheque.Bonjour();
            bonjour.DireBonjour();

            Client client = new Client("Arno", "12345");
            Console.WriteLine(client.MotDePasse);

            Console.WriteLine(Generateur.ObtenirIdentifiantUnique());
            
        }
    }
}
