using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Movement : MonoBehaviour
{
    Rigidbody2D rigidbody2D;

    [SerializeField] float speed;
    public Animator animator;
    public Vector2 direction;
    Vector2 lastDirection;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, vertical);
        AnimateMovement(direction);

        if(horizontal != 0 || vertical != 0)
        {
            lastDirection = new Vector2(
                horizontal,
                vertical).normalized;
        }
    }


    void FixedUpdate()
    {
        Move();
    }
    
    void Move()
    {
        rigidbody2D.velocity = direction * speed;
    }

    public void AnimateMovement(Vector2 direction)
    {
        if(animator != null)
        {
            if(direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);
                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}

