
using UnityEngine;

namespace Assets.WBTree.Test
{
    class BTDieAction : BTAction
    {
        private int DelDely;
        private float CD;
        public BTDieAction(BTPrecondition precondition = null) : base(precondition)
        {
        }

        public BTDieAction(int DelDely)
        {
            this.DelDely = DelDely;
        }

        protected override void Enter()
        {
            base.Enter();
            vo.NV.isStopped = true;
            vo.NV.velocity=Vector3.zero;
            CD = 0;
        }

        protected override BTResult Excute()
        {
            CD += Time.deltaTime;
            if (CD>=DelDely)
            {
                vo.gameObject.SetActive(false);
                return BTResult.Ended;
            }
            return BTResult.Running;
        }

        protected override void Exit()
        {
            base.Exit();

            CD = 0;
        }
    }
}
