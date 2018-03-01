using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets._NewBTTree.Core
{
    public class Util
    {

    }

    public enum NodeTickResult
    {
        Running,
        End
    }
    public enum ActionNodeTickState
    {
        Ready,
        Running
    }

    public enum ParamalNodeType
    {
        AND,
        OR
    }
}
