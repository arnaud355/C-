using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesOC
{
    /*
     interface Icomparable possède des méthodes comme CompareTo, Array.Sort fait
     appel à cette interface.

      Quand le type (classe...) n'est pas natif, il faut faire hériter la classe de cette
      interface.
     */
    public class Voiture : IComparable
    {
        public string Couleur { get; set; }
        public string Marque { get; set; }
        public int Vitesse { get; set; }

        public int CompareTo(object obj)
        {
            Voiture voiture = (Voiture)obj;
            if (this.Vitesse < voiture.Vitesse)
                return -1;
            if (this.Vitesse > voiture.Vitesse)
                return 1;
            return 0;
        }

    }
}
