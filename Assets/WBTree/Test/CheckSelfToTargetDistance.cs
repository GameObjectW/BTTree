using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.WBTree.Test
{
    class CheckSelfToTargetDistance:BTPrecondition
    {
        private readonly float distance;
        private readonly bool isBigger;

        public CheckSelfToTargetDistance(float Distance,bool isBigger)
        {
            distance = Distance;
            this.isBigger = isBigger;
        }

        public override bool Check()
        {
            if (vo.Target==null)
            {
                return false;
            }
            if (isBigger)
            {
                return Vector3.Distance(vo.transform.position, vo.Target.transform.position)>distance;
            }
            return Vector3.Distance(vo.transform.position, vo.Target.transform.position) < distance;

        }
    }
}
