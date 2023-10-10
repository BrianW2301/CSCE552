using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed = 15.0f;
    public float jumpForce = 500.0f;
    Vector2 moveVector = Vector2.zero;
    public bool isTouchingGround = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.AddForce(jumpForce * Vector2.up);
        }
        
        // Allows for variation in jumps based on how long jump is held
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector = moveVector.normalized * moveSpeed;
        moveVector.y = rb.velocity.y;
        rb.velocity = moveVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchingGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isTouchingGround = false;
        }
    }
}
