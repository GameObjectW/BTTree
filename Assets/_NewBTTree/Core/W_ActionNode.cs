

namespace Assets._NewBTTree.Core
{
    public abstract class W_ActionNode:W_BTNode
    {
        private ActionNodeTickState _state;
        public virtual void Enter()
        {
        }

        public virtual NodeTickResult Excute()
        {
            return NodeTickResult.End;
        }

        public virtual void Exit()
        {
        }

        public override NodeTickResult Tick()
        {
            if (_state==ActionNodeTickState.Ready)
            {
                Enter();
                _state = ActionNodeTickState.Running;
            }
            if (_state==ActionNodeTickState.Running)
            {
                NodeTickResult result =Excute();
                if (result==NodeTickResult.End)
                {
                    Exit();
                    _state = ActionNodeTickState.Running;
                    return NodeTickResult.End;
                }
                return NodeTickResult.Running;
            }
            return NodeTickResult.End;
        }
    }
}
