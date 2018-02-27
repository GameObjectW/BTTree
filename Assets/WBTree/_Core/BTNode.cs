
using System.Collections.Generic;
using Assets.WBTree._Core;


public abstract class BTNode
{
    private string _nodeName;
    private bool _isActive=true;
    private BTPrecondition _preCondition;
    protected List<BTNode> ChildNode;

    protected AIVO vo;

    protected BTNode(BTPrecondition preCondition)
    {
        _preCondition = preCondition;
    }

    public virtual void Activate(AIVO vo)
    {
        this.vo = vo;
        if (!_isActive)
        {
            return;
        }
        if (_preCondition != null)
        {
            _preCondition.Activate(vo);
        }
        if (ChildNode!=null&&ChildNode.Count!=0)
        {
            foreach (var btNode in ChildNode)
            {
                btNode.Activate(vo);
            }
            //for (int i = 0; i < ChildNode.Count; i++)
            //{
            //    ChildNode[i].Activate(vo);
            //}
        }
    }

    public bool Evaluate()
    {
        return _isActive && (_preCondition == null || _preCondition.Check())&&OnEvaluate();
    }

    public virtual BTResult Tick()
    {
        return BTResult.Ended;
    }

    public virtual bool OnEvaluate()
    {
        return true;
    }

    public virtual void AddChild(BTNode Node)
    {
        if (ChildNode==null)
        {
            ChildNode=new List<BTNode>();
        }
        if (Node!=null)
        {
            ChildNode.Add(Node);
        }
    }

    public virtual void RemoveChild(BTNode Node)
    {
        if (ChildNode!=null&&Node!=null&&ChildNode.Contains(Node))
        {
            ChildNode.Remove(Node);
        }
    }
}
