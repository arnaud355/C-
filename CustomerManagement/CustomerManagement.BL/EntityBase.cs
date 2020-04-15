using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BL
{
    public enum EntityStateOption
    {
        Active,
        Deleted
    }
    public abstract class EntityBase
    {
        public EntityStateOption EntityState { get; set; }
        public bool IsNew { get; private set; }
        public bool HasChanges { get; set; }
        public bool IsValid => Validate();

        /* Abstract: Method signature are place holder with no implemntation.
         * only use in abstract class, must be overriden by derived class
         * 
         * Virtual: Method with default implementation
         * use in abstract or concrete class, optionnaly be overriden by derived class
         */
        public abstract bool Validate();
        
        
    }
}
