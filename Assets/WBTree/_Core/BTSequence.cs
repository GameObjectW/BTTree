

public class BTSequence : BTNode {


    private BTNode _activeBtNode;
    private int index;
    public BTSequence(BTPrecondition preCondition) : base(preCondition)
    {
    }

    public override BTResult Tick()
    {
        BTResult isResult = _activeBtNode.Tick();
        if (isResult== BTResult.Ended)
        {
            index++;
            if (index==(ChildNode.Count-1))
            {
                _activeBtNode = null;
                index = 0;
                return BTResult.Ended;
            }
            else
            {
                _activeBtNode = ChildNode[index];
                return BTResult.Running;
            }
        }
        return isResult;

    }

    public override bool OnEvaluate()
    {
        if (_activeBtNode==null)
        {
            _activeBtNode = ChildNode[0];
            index = 0;
        }
        return _activeBtNode.Evaluate();
    }
}
