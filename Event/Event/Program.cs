using System;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            //Une classe pour gestion event se creer et se gère de cette façon:
            new DemoEvenement().Demo();

            //Gestion des erreurs
            try
            {
                string chaine = "dix";
                int valeur = Convert.ToInt32(chaine);
                Console.WriteLine("Ce code ne sera jamais affiché");
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Erreur de format : " + ex);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Erreur de référence nulle : " + ex);
            }
            catch (SystemException ex)
            {
                Console.WriteLine("Erreur système autres que FormatException et NullReferenceException : " + ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Toutes les autres exceptions : " + ex);
            }

            try
            {
                string saisie = Console.ReadLine();
                int valeur = Convert.ToInt32(saisie);
                Console.WriteLine("Vous avez saisi un entier");
            }
            catch (FormatException)
            {
                Console.WriteLine("Vous avez saisi autre chose qu'un entier");
            }
            //finally, après block try et catch, execute instructions quoi qu'il arrive
            finally
            {
                Console.WriteLine("Merci d'avoir saisi quelque chose");
            }

            //***************
            /*Il est possible de déclencher soi-même la levée d’une exception. C’est utile si nous considérons
             * que notre code a atteint un cas limite, qu’il soit fonctionnel ou technique.
                Pour lever une exception, nous utilisons le mot-clé throw, suivi d’une instance d’une exception.
                Imaginons par exemple une méthode permettant de calculer la racine carrée d’un double. Nous pouvons 
                obtenir un cas limite lorsque nous tentons de passer un double négatif.

            Ici, nous instancions une ArgumentOutOfRangeException en utilisant un constructeur à deux
            paramètres. Ceux-ci permettent d’indiquer le nom du paramètre ainsi que le message d’erreur.
            Cette exception est une exception du framework .NET utilisée pour indiquer qu’un paramètre
            est en dehors des plages de valeurs autorisées. C’est exactement ce qu’il nous faut ici.
            Puis nous levons l’exception avec le mot-clé throw.
                */
            static double RacineCarree(double valeur)
            {
                if (valeur <= 0)
                    throw new ArgumentOutOfRangeException("valeur", "Le paramètre doit être positif");
                return Math.Sqrt(valeur);
            }

            try
            {
                double racine = RacineCarree(-5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Impossible d'effectuer le calcul : " + ex.Message);
            }

            //**************************
            try
            {
                Methode1();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("On intercepte l'exception de la méthode 3");
            }

            static void Methode1()
            {
                Methode2();
            }

            static void Methode2()
            {
                Methode3();
            }

            static void Methode3()
            {
                throw new NotImplementedException();
            }

            //***********************
            try
            {
                ProduitNonEnStockException.ChargerProduit("TV HD");
            }
            catch (ProduitNonEnStockException ex)
            {
                Console.WriteLine("Erreur : " + ex.Message);
            }
        }
    }
}
