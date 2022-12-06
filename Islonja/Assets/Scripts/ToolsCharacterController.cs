using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    Player_Movement character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        character = GetComponent<Player_Movement>();
        rgbd2d= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ( Input.GetMouseButton(0) )
        {
            UseTool();
        }
    }

    private void UseTool()
    {
       Vector2 position = rgbd2d.position + character.direction * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        
        foreach(Collider2D c in colliders)
        {
            ToolHits hit = c.GetComponent<ToolHits>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }
}
