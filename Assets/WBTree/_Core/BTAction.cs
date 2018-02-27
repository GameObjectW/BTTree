

public abstract class BTAction : BTNode {
    protected enum BTActionStatus
    {
        Ready = 1,
        Running = 2,
    }

    protected BTActionStatus _currentStatus = BTActionStatus.Ready;
    public BTAction(BTPrecondition precondition = null) : base(precondition) { }

    protected virtual void Enter()
    {
    }

    protected virtual BTResult Excute()
    {
        return BTResult.Running;
    }

    protected virtual void Exit()
    {

    }

    public override BTResult Tick()
    {
        BTResult result = BTResult.Ended;
        if (_currentStatus== BTActionStatus.Ready)
        {
            Enter();
            _currentStatus = BTActionStatus.Running;
        }
        else if (_currentStatus==BTActionStatus.Running)
        {
            result = Excute();
            if (result==BTResult.Ended)
            {
                Exit();
                _currentStatus = BTActionStatus.Ready;
            }
        }
        return result;
    }
}
