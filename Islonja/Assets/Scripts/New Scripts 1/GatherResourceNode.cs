using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public enum ResourceNodeType  
{
    Undefined,
    Tree,
    Stone
}

[CreateAssetMenu(menuName ="Data/Tool action/Gather Resource Node")]
public class GatherResourceNode : ToolAction 
{
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] List<ResourceNodeType> canHitNodesOfType;
    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHits hit = c.GetComponent<ToolHits>();
            if (hit != null)
            {
                if(hit.CanBeHit(canHitNodesOfType) == true)
                {
                    hit.Hit();
                    return true;
                }
            }
        }
        return false;
    }

}
