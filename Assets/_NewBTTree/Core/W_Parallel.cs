using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._NewBTTree.Core
{
    class W_Parallel : W_BTNode
    {
        private ParamalNodeType _type;
        private List<NodeTickResult> _results;
        public W_Parallel(W_Precondition pre, ParamalNodeType type) : base(pre)
        {
            _type = type;
            _results=new List<NodeTickResult>();
        }

        public override bool OnEvaluate()
        {
            if (ChildNode != null && ChildNode.Count != 0)
            {
                foreach (W_BTNode wBtNode in ChildNode)
                {
                    if (_type== ParamalNodeType.AND)
                    {
                        if (!wBtNode.Evaluate())
                        {
                            return false;
                        } 
                    }
                    else if(_type==ParamalNodeType.OR)
                    {
                        if (wBtNode.Evaluate())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public override NodeTickResult Tick()
        {
            int finishCount = 0;
            if (_type == ParamalNodeType.AND)
            {
                for (int i = 0; i < ChildNode.Count; i++)
                {
                    if (_results[i] == NodeTickResult.Running)
                    {
                        _results[i] = ChildNode[i].Tick();
                    }
                    else
                    {
                        finishCount++;
                    }
                }
                if (finishCount == ChildNode.Count)
                {
                    ResetResults();
                    return NodeTickResult.End;
                }
                return NodeTickResult.Running;
            }
            else
            {
                for (int i = 0; i < ChildNode.Count; i++)
                {
                    if (_results[i] == NodeTickResult.Running)
                    {
                        _results[i] = ChildNode[i].Tick();
                    }
                    else
                    {
                        ResetResults();
                        return NodeTickResult.End;
                    }
                }

                return NodeTickResult.Running;
            }
        }
        private void ResetResults()
        {
            for (int i = 0; i < _results.Count; i++)
            {
                _results[i] = NodeTickResult.Running;
            }
        }
        public override W_BTNode AddChild(W_BTNode aNode)
        {
           
            _results.Add(NodeTickResult.Running);
            base.AddChild(aNode);
            return this;
        }

        public override W_BTNode RemoveChild(W_BTNode aNode)
        {
            int index = ChildNode.IndexOf(aNode);
            _results.RemoveAt(index);
            base.RemoveChild(aNode);
            return this;
        }
    }

}
