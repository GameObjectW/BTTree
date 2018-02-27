using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.WBTree.Test
{
    class PlayAnimatorAction:BTAction

    {
        public string AniName;

        public PlayAnimatorAction(string AniName)
        {
            this.AniName = AniName;
        }

        protected override void Enter()
        {
            base.Enter();
            
            if (!vo.Ani.GetCurrentAnimatorStateInfo(0).IsName(AniName))
            {
                vo.Ani.SetTrigger(AniName);
            }


        }

        protected override BTResult Excute()
        {
            return BTResult.Ended;

        }
    }
}
