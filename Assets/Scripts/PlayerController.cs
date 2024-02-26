using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 lastMoveDir;
    
    public Animator anim;

    private void Update()
    {
        //inputs
        ProcessInputs();
        animate();
    }

    private void FixedUpdate()
    {
        //physics calcs
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDir = moveDirection;
        }

        // must account for diag movement as diag is faster
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void animate()
    {
        anim.SetFloat("moveX", moveDirection.x);
        anim.SetFloat("moveY", moveDirection.y);
        anim.SetFloat("moveMag", moveDirection.magnitude);
        anim.SetFloat("lastMoveX", lastMoveDir.x);
        anim.SetFloat("lastMoveY", lastMoveDir.y);
    }
}
