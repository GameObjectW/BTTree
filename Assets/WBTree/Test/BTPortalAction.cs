using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.WBTree.Test
{
    class BTPortalAction:BTAction
    {
        private int Index;
        protected override void Enter()
        {
            base.Enter();
            vo.NV.isStopped = false;
         //   Debug.Log("刚进入1");
        }

        protected override BTResult Excute()
        {
            vo.NV.SetDestination(vo.WayPointList[Index].position);

            if (vo.NV.remainingDistance <= vo.NV.stoppingDistance && !vo.NV.pathPending)
            {
                Index= (Index + 1) % vo.WayPointList.Count;

            }
            return BTResult.Ended;
        }

        protected override void Exit()
        {
            base.Exit();
         
        }
    }
}
