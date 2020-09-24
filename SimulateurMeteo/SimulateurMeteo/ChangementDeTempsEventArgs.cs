using System;
using System.Collections.Generic;
using System.Text;

namespace SimulateurMeteo
{
    public class ChangementDeTempsEventArgs : EventArgs
    {
        public int Temps { get; set; }
    
    }
}
