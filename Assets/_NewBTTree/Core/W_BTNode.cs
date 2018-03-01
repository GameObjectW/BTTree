
using System.Collections.Generic;
using Assets._NewBTTree.Core;
using UnityEngine;

public abstract class W_BTNode
{
    protected string Name;
    protected List<W_BTNode> ChildNode;
    protected W_Precondition PreCondition;              //外在执行判断条件

    public W_BTNode()
    {
        ChildNode=new List<W_BTNode>();
    }

    public W_BTNode(W_Precondition pre)
    {
        this.PreCondition = pre;
        ChildNode = new List<W_BTNode>();
    }


    public virtual W_BTNode AddChild(W_BTNode node)
    {
        if (!ChildNode.Contains(node))
        {
            ChildNode.Add(node);
            return this;
        }
       Debug.Log("子节点中已经存在相同的节点!~");
        return this;
    }
    public virtual W_BTNode RemoveChild(W_BTNode node)
    {
        if (ChildNode.Contains(node))
        {
            ChildNode.Remove(node);
            return this;
        }
        Debug.Log("子节点中没有匹配对象供删除："+node.Name);
        return this;
    }
    /// <summary>
    /// 同时判断内外条件，来决定该节点是否可以被执行
    /// </summary>
    /// <returns></returns>
    public bool Evaluate()
    {
        return (PreCondition == null || PreCondition.Check()) && OnEvaluate();
    }


    //子类可重写函数


    /// <summary>
    /// 内在执行判断添加
    /// </summary>
    /// <returns></returns>
    public virtual bool OnEvaluate()                    
    {
        return true;
    }
    /// <summary>
    /// 节点运行循环
    /// </summary>
    /// <returns></returns>
    public virtual NodeTickResult Tick()
    {
        return NodeTickResult.End;
    }
    /// <summary>
    /// 当该节点需要转换为另一个节点时调用的函数，用来做一些初始化等工作
    /// </summary>
    public virtual void NodeTransition()
    {

    }
}
