using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._NewBTTree.Core
{
    class W_PrioritySelector : W_BTNode
    {
        private W_BTNode _activeChildNode;
        public W_PrioritySelector(W_Precondition pre) : base(pre)
        {
        }

        public override bool OnEvaluate()
        {
            if (ChildNode!=null&&ChildNode.Count!=0)
            {
                foreach (W_BTNode wBtNode in ChildNode)
                {
                    if (wBtNode.Evaluate())
                    {
                        _activeChildNode = wBtNode;
                        return true;
                    }
                }
            }
            return false;
        }

        public override NodeTickResult Tick()
        {
            NodeTickResult _result = _activeChildNode.Tick();
            if (_result== NodeTickResult.End)
            {
                _activeChildNode = null;
                return NodeTickResult.End;
            }
            return NodeTickResult.Running;
        }

    }
}
