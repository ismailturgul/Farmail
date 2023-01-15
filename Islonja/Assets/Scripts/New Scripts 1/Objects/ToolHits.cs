using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHits : MonoBehaviour
{

    public virtual void Hit()
    {
        Destroy(gameObject);
    }

    public virtual bool CanBeHit(List<ResourceNodeType> canBeHit)
    {
        return true;
    }
}
