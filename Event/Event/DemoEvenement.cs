using System;
using System.Collections.Generic;
using System.Text;

namespace Event
{
    public class DemoEvenement
    {
        public void Demo()
        {
            Voiture voiture = new Voiture { Prix = 10000 };

            //Voiture.DelegateDeChangementDePrix delegateChangementDePrix = voiture_ChangementDePrix;
            //voiture.ChangementDePrix += delegateChangementDePrix;

            voiture.ChangementDePrix += voiture_ChangementDePrix;

            voiture.PromoSurLePrix();
        }

        private void voiture_ChangementDePrix(object sender, ChangementDePrixEventArgs e)
        {
            Console.WriteLine("Le nouveau prix est de : " + e.Prix);
        }
        /*Nous créons une voiture, et nous créons un délégué du même type que l’événement.Nous le 
         * faisons pointer vers une méthode qui respecte la signature du délégué.Ainsi, à chaque 
         * changement de prix, la méthode voiture_ChangementDePrix va être appelée et le paramètre 
         * nouveauPrix possèdera le nouveau prix qui vient d’être calculé.
           Appelons la promotion en invoquant la méthode ChangementDePrix(), nous pouvons nous rentre
           compte que l’application nous affiche le nouveau prix qui est l’ancien divisé par 2.

           L’utilisation du « += » permet d’ajouter un nouveau délégué à l’événement. Il sera éventuellement
           possible d’ajouter un autre délégué avec le même opérateur, ainsi deux méthodes seront désormais 
           notifiées en cas de changement de prix. Inversement, il est possible de se désabonner
           d’un événement en utilisant l’opérateur « -= ».
           */

    }
}
