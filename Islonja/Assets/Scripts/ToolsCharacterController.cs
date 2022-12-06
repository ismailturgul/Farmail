using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake()
    {
        character= GetComponent<CharacterController>();
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
        throw new NotImplementedException();
    }
}
