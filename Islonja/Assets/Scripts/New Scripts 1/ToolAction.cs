using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAction : ScriptableObject
{

    public virtual bool OnApply(Vector2 worldpoint)
    {
        Debug.LogWarning("OnApply is not implemented");
        return true;
    }
}
