using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard
{
    
    private Dictionary<string, object> Data;
    private static BlackBoard ins;

    public static BlackBoard Ins
    {
        get
        {
            if (ins==null)
            {
                Ins=new BlackBoard();
            }
            return ins;
        }

        set
        {
            ins = value;
        }
    }

    public BlackBoard()
    {
        Data=new Dictionary<string, object>();
    }

    public T GetValue<T>(string ValueKey)
    {
        object Value;
        if (Data.TryGetValue(ValueKey,out Value))
        {
            return (T) Value;
        }
        return default(T);
    }

    public void SetValue(string ValueKey, object Value)
    {
        if (Data.ContainsKey(ValueKey))
        {
            Data[ValueKey] = Value;
        }
        else
        {
            Data.Add(ValueKey,Value);
        }
    }
}
