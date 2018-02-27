using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.WBTree.Test
{
    class BTChaseAction:BTAction
    {
        protected override void Enter()
        {
            base.Enter();
            vo.NV.isStopped = false;

        }

        protected override BTResult Excute()
        {
            vo.NV.destination = vo.Target.position;
            return BTResult.Ended;
        }

        protected override void Exit()
        {
            base.Exit();

        }
    }
}
