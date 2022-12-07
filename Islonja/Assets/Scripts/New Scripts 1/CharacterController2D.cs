using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rgbd2D;

    [SerializeField] float speed;
    public Animator animator;
    public Vector2 direction;
    public Vector2 lastDirection;
    public bool moving;

    private void Awake()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);

        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("isMoving", moving);

        if (horizontal != 0 || vertical != 0)
        {
            lastDirection = new Vector2(
                horizontal,
                vertical).normalized;
            animator.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("vertical", Input.GetAxisRaw("Vertical"));
        }
    }


    void FixedUpdate()
    {
        Move();
    }
    
    void Move()
    {
        rgbd2D.velocity = direction * speed;
    }

    public void AnimateMovement(Vector2 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}

