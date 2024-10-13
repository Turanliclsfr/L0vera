using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 16f;
    private bool istouchingGrass = true;
    private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;
    
    
    

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundlayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");


        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }




        if(Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W) && coyoteTimeCounter > 0 ))
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            

        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f)
        {
            coyoteTimeCounter = 0f;
        }





        flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundlayer);
    }



    

    private void flip()
    {
        if(istouchingGrass && horizontal < 0f || !istouchingGrass && horizontal > 0f)
        {
            istouchingGrass = !istouchingGrass;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }



   








}
