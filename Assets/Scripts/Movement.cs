using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 10f;
    bool facingright = true;
    private Rigidbody2D rb2d;

bool grounded = false;
public Transform groundCheck;
float groundRadius = 0.2f;
public LayerMask whatIsGround;
public float jumpForce = 5f;

// Start is called before the first frame update
void Start()
{
    rb2d = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void FixedUpdate()
{
    grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


    float move = Input.GetAxis("Horizontal");

    rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
}

private void Update()
{
    if (grounded && Input.GetKeyDown(KeyCode.Space)) 
    {
        rb2d.AddForce(new Vector2(0, jumpForce));
    }
}
}