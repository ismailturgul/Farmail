using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[CreateAssetMenu(menuName ="Data/Tool action/Gather Resource Node")]
public class GatherResourceNode : ToolAction 
{
    [SerializeField] float sizeOfInteractableArea = 1f;
    public override bool OnApply(Vector2 worldPoint)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPoint, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            ToolHits hit = c.GetComponent<ToolHits>();
            if (hit != null)
            {
                hit.Hit();
                return true;
            }
        }
        return false;
    }

}
