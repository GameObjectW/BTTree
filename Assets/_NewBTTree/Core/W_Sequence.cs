using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._NewBTTree.Core
{
    public class W_Sequence : W_BTNode
    {
        private int _activeChildNodeIndex;
        private W_BTNode _activeChildNode;
        public W_Sequence(W_Precondition pre) : base(pre)
        {
        }

        public override bool OnEvaluate()
        {
            if (ChildNode!=null&&ChildNode.Count!=0)
            {
                if (_activeChildNode == null)
                {
                    _activeChildNodeIndex = 0;
                    _activeChildNode = ChildNode[0];
                }
                return _activeChildNode.Evaluate();
            }
            return false;
        }

        public override NodeTickResult Tick()
        {
            NodeTickResult _result= _activeChildNode.Tick();
            if (_result== NodeTickResult.End)
            {
                _activeChildNodeIndex++;
                if (_activeChildNodeIndex == ChildNode.Count)
                {
                    _activeChildNode = null;
                    return NodeTickResult.End;
                }

                _activeChildNode = ChildNode[_activeChildNodeIndex];
            }
            return NodeTickResult.Running;
        }
    }
}
