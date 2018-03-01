using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._NewBTTree.Core
{
    public abstract class W_Precondition
    {
        public virtual bool Check()
        {
            return true;
        }
    }
    
}
