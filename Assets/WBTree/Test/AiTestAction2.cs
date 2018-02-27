using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.WBTree.Test
{
    class AiTestAction2:BTAction
    {
        public AiTestAction2(BTPrecondition precondition = null) : base(precondition)
        {
        }

        protected override void Enter()
        {
            base.Enter();
            Debug.Log("刚进入2");
        }

        protected override BTResult Excute()
        {
            Debug.Log("执行2");
            return BTResult.Ended;
        }

        protected override void Exit()
        {
            base.Exit();
            Debug.Log("刚退出2");
        }
    }
}
