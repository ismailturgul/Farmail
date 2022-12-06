using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHits : MonoBehaviour
{

    public virtual void Hit()
    {
        Destroy(gameObject);
    }
}
