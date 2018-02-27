using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPrioritySelector : BTNode
{

    private BTNode _activeBtNode;
    public BTPrioritySelector(BTPrecondition preCondition) : base(preCondition)
    {
    }

    public override BTResult Tick()
    {
        BTResult isResult = _activeBtNode.Tick();
        if (isResult== BTResult.Ended)
        {
            return BTResult.Ended;
        }
        return BTResult.Running;
    }

    public override bool OnEvaluate()
    {
        if (ChildNode!=null&&ChildNode.Count!=0)
        {
            foreach (BTNode btNode in ChildNode)
            {
                if (btNode.Evaluate())
                {
                    _activeBtNode = btNode;
                    return true;
                }
            }
        }
        
        return false;
    }
}
