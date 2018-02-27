

namespace Assets.WBTree.Test
{
    class DieCondition:BTPrecondition

    {
        public override bool Check()
        {
            return vo.CurrentHp == 0;

        }
    }
}
