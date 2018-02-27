

public abstract class BTPrecondition : BTNode
{

    protected BTPrecondition() : base(null)
    {
    }

    // Override to provide the condition check.
    public abstract bool Check();

    // Functions as a node
    public override BTResult Tick()
    {
        bool success = Check();
        if (success)
        {
            return BTResult.Ended;
        }
        else
        {
            return BTResult.Running;
        }
    }

    
}
