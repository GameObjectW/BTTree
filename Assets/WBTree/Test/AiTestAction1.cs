using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Debug = UnityEngine.Debug;

namespace Assets.WBTree.Test
{
    class AiTestAction1:BTAction
    {

        public AiTestAction1(BTPrecondition precondition = null) : base(precondition)
        {
        }

        protected override void Enter()
        {
            base.Enter();
            Debug.Log("刚进入1");
        }

        protected override BTResult Excute()
        {
            Debug.Log("执行1");
            return BTResult.Ended;
        }

        protected override void Exit()
        {
            base.Exit();
            Debug.Log("刚退出1");
        }
    }
}
