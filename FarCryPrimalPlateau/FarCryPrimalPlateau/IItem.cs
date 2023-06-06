using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarCryPrimalPlateau
{
    public interface IItem
    {
        public void GetInfoOfItem();
        public int GetPosX();
        public int GetPosY();
        public int GetId();

        public int GetReactivite();
    }
}
