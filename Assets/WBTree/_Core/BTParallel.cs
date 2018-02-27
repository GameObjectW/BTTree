
using System.Collections.Generic;

public enum ParallelFunction
{
    And = 1,    // returns Ended when all results are not running
    Or = 2,     // returns Ended when any result is not running
}
public class BTParallel : BTNode {
    protected ParallelFunction _func;
    private List<BTResult> _results;

    public BTParallel(BTPrecondition preCondition) : base(preCondition)
    {
        _results = new List<BTResult>();
    }
    public BTParallel(ParallelFunction func, BTPrecondition preCondition) : base(preCondition)
    {
        _results = new List<BTResult>();
        this._func = func;
    }

    public override BTResult Tick()
    {
        int finishCount=0;
        if (_func== ParallelFunction.And)
        {
            for (int i = 0; i < ChildNode.Count; i++)
            {
                if (_results[i]==BTResult.Running)
                {
                    _results[i] = ChildNode[i].Tick();
                }
                else
                {
                    finishCount++;
                }
            }
            if (finishCount==ChildNode.Count)
            {
                ResetResults();
                return BTResult.Ended;
            }
            return BTResult.Running;
        }
        else
        {
            for (int i = 0; i < ChildNode.Count; i++)
            {
                if (_results[i] == BTResult.Running)
                {
                    _results[i] = ChildNode[i].Tick();
                }
                else
                {
                    ResetResults();
                    return BTResult.Ended;
                }
            }
            
            return BTResult.Running;
        }
    }

    public override bool OnEvaluate()
    {
            foreach (BTNode btNode in ChildNode)
            {
                if (btNode.Evaluate()==false)
                {
                    return false;
                }
            }
            return true;
    }
    private void ResetResults()
    {
        for (int i = 0; i < _results.Count; i++)
        {
            _results[i] = BTResult.Running;
        }
    }
    public override void AddChild(BTNode aNode)
    {
        base.AddChild(aNode);
        _results.Add(BTResult.Running);
    }

    public override void RemoveChild(BTNode aNode)
    {
        int index = ChildNode.IndexOf(aNode);
        _results.RemoveAt(index);
        base.RemoveChild(aNode);
    }
}
