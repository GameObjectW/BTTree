using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Assets.WBTree.Test;
using Debug = UnityEngine.Debug;

namespace Assets.WBTree._Core
{
    class AIFirst:BTree
    {
        public override void Init()
        {
            Debug.Log("S");
            _rootNode=new BTPrioritySelector(null);


            ValueCondition vc=new ValueCondition(10,true);
            ValueCondition vd = new ValueCondition(10, false);
            DieCondition die=new DieCondition();
            EnemyInSight sight=new EnemyInSight();
            CheckSelfToTargetDistance CTD=new CheckSelfToTargetDistance(vo.AttackDistance,false);
            CheckSelfToTargetDistance CTD2 = new CheckSelfToTargetDistance(vo.AttackDistance, true);

            AiTestAction1 first=new AiTestAction1(vc);
            AiTestAction2 second=new AiTestAction2(vd);

            BTDieAction dieAction=new BTDieAction(3);
            BTPortalAction portalAction=new BTPortalAction();
            BTAttackAction attackAction=new BTAttackAction(vo.AttackCD);
            BTChaseAction ChaseAction=new BTChaseAction();







            BTParallel p = new BTParallel(die);
            _rootNode.AddChild(p);
            p.AddChild(dieAction);
            p.AddChild(new PlayAnimatorAction("Die"));

            BTPrioritySelector Select = new BTPrioritySelector(null);
            BTPrioritySelector Select2 = new BTPrioritySelector(null);
            BTParallel p2 = new BTParallel(ParallelFunction.And,sight);
            _rootNode.AddChild(Select);
            Select.AddChild(p2);
            p2.AddChild(portalAction);
            p2.AddChild(new PlayAnimatorAction("Run"));

            Select.AddChild(Select2);
            BTParallel p3 = new BTParallel(ParallelFunction.And, CTD);
            p3.AddChild(attackAction);
            p3.AddChild(new PlayAnimatorAction("attack1"));

            BTParallel p4 = new BTParallel(ParallelFunction.Or, null);
            p4.AddChild(ChaseAction);
            p4.AddChild(new PlayAnimatorAction("Run"));

            Select2.AddChild(p3);
            Select2.AddChild(p4);
        }
    }
}
