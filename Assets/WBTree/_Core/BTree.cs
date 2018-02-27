
using UnityEngine;
public enum BTResult
{
    Ended = 1,
    Running = 2,
}
public abstract class BTree : MonoBehaviour
{
    protected BTNode _rootNode;
    protected AIVO vo;
    void Start()
    {
        vo = GetComponent<AIVO>();
        Init();
        _rootNode.Activate(vo);
    }

    void Update(){
        if (_rootNode.Evaluate())
        {
            _rootNode.Tick();
        }
    }

    public abstract void Init();
}
