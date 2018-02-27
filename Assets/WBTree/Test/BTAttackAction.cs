using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.WBTree.Test
{
    class BTAttackAction:BTAction
    {
        private int AttackCD;
        private float CD;

        public BTAttackAction(int attackCd)
        {
            AttackCD = attackCd;
        }

        protected override void Enter()
        {
            base.Enter();
            vo.NV.isStopped = true;
            Debug.Log("刚进入攻击");
        }

        protected override BTResult Excute()
        {
            CD += Time.deltaTime;
            if (CD>=AttackCD)
            {
                return BTResult.Ended;
            }
          //  vo.transform.LookAt(vo.Target);
           // Debug.Log("执行攻击");
            return BTResult.Running;
        }

        protected override void Exit()
        {
            CD = 0;
            base.Exit();
            Debug.Log("刚退出攻击");
        }
    }
}
