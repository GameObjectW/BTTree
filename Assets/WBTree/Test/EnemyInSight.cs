using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.WBTree.Test
{
    class EnemyInSight:BTPrecondition

    {
        public override bool Check()
        {

            RaycastHit hit;

            Debug.DrawRay(vo.eyes.position, vo.eyes.forward * vo.lookRange, Color.red);
            if (vo.Target!=null&&vo.Target.gameObject.activeSelf)
            {
                return false;
            }

            if (Physics.SphereCast(vo.eyes.position, vo.LookSphereCastRadius, vo.eyes.forward, out hit, vo.lookRange) && hit.collider.CompareTag("Player"))
            {
                vo.Target = hit.transform;
                return false;
            }
            return true;
        }
    }
}
