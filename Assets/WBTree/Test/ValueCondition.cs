using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.WBTree.Test
{
    class ValueCondition:BTPrecondition
    {
        private int a ;
        private bool isBigger;
        public ValueCondition(int a,bool isBigger)
        {
            this.a = a;
            this.isBigger = isBigger;
        }

        public override bool Check()
        {
            if (isBigger)
            {
                return a > vo.value;
            }
            return a < vo.value ;
        }
    }
}
