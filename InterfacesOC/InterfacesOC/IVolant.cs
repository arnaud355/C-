using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesOC
{
    //C'est une interface que nous créons, dont vont hériter classe d'instances volantes
    public interface IVolant
    {
        int NombrePropulseurs { get; set; }
        void Voler();
    }
}
