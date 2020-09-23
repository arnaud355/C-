using System;
using System.Collections.Generic;
using System.Text;

namespace Event
{
    /*Ces événements utilisent en général une construction à base du délégué EventHandler ou 
     * sa version générique EventHandler<>. Ce délégué accepte deux paramètres. Le premier de 
     * type object qui représente la source de l'événement, c'est-à-dire l'objet qui a levé l'événement.
     * Le second est une classe qui dérive de la classe de base EventArgs.
     * */
    public class ChangementDePrixEventArgs : EventArgs
    {
        public decimal Prix { get; set; }
    }
}
