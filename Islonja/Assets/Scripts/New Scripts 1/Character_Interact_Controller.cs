using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Interact_Controller : MonoBehaviour
{
    CharacterController2D character_Controller;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1.0f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;

    private void Awake()
    {
        character_Controller = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Interactable");
            Interact();
        }
    }

    private void Interact()
    {
        Vector2 position = rgbd2d.position + character_Controller.lastDirection * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders)
        {
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null)
            {
                hit.Interact(character);  // check for the character to interact, instead of Tools 
                break;
            }
        }
    }
}
