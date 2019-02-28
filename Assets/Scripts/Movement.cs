using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour
{
    public float maxSpeed = 10f;
    bool facingright = true;
    private Rigidbody2D rb2d;

    Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isLocalPlayer)
        {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            anim.SetBool("Ground", grounded);
            Debug.Log(grounded);
            anim.SetFloat("vSpeed", rb2d.velocity.y);

            float move = Input.GetAxis("Horizontal");

            anim.SetFloat("Speed", Mathf.Abs(move));

            rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);

            if (move > 0 && !facingright)
                flip();
            else if (move < 0 && facingright)
                flip();
        }
    }

    void flip()
    {
        facingright = !facingright;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Update()
    {
        if (this.isLocalPlayer)
        {
            if (grounded && Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Ground", false);
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}