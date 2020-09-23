using System;
using System.Collections.Generic;
using System.Text;

namespace Event
{
    public class Voiture
    {
        /* Dans la classe Voiture, nous définissons un délégué qui ne retourne rien et qui prend en 
         * paramètre un décimal.Nous définissons ensuite un événement basé sur ce délégué, avec comme 
         * nous l’avons vu, l’utilisation du mot-clé event. Enfin, dans la méthode de promotion, après un 
         * changement de prix (division par 2), nous notifions les éventuels objets qui se seraient abonnés
         * à cet événement en invoquant l’événement et en lui fournissant en paramètre le nouveau prix.
         * 

           À noter que nous testons d’abord s’il y a un abonné à l’événement (en testant s’il est différent
           de null) avant de le lever.*/
       // public delegate void DelegateDeChangementDePrix(decimal nouveauPrix);
        
        //Un événement est défini grâce au mot-clé event
       // public event DelegateDeChangementDePrix ChangementDePrix;

        public event EventHandler<ChangementDePrixEventArgs> ChangementDePrix;

        public decimal Prix { get; set; }

        public void PromoSurLePrix()
        {
            Prix = Prix / 2;
            if (ChangementDePrix != null)
                ChangementDePrix(this, new ChangementDePrixEventArgs { Prix = Prix });
        }
    }
}
