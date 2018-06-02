using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Transform player;
    public float jumpHeight = 4.0f;
    public float maxSpeed = 2.0f;

    private Animator animator;
    private bool grounded;
    private Rigidbody2D rb;

    private Vector3 jumpDirection;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        grounded = true;

        jumpDirection = new Vector3(0, jumpHeight, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        /* JUMP when player is on ground */
        if(Input.GetKey(KeyCode.Space))
        {
            if(grounded) animator.SetBool("Jump", true);
            else animator.SetBool("Jump", false);
            player.transform.Translate(jumpDirection * Time.deltaTime);
            grounded = false;
        }

        /* MOVEMENT */
        float move = Input.GetAxis("Horizontal");
        float move_vert = Input.GetAxis("Vertical");

        // Move forward/backward
        if (Input.GetKey(KeyCode.LeftShift)) rb.velocity = new Vector2(move * maxSpeed * 1.8f, rb.velocity.y);
        else rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        // Look up/down
        if (move_vert > 0) animator.SetBool("Up", true);
        else if (move_vert < 0) animator.SetBool("Down", true);
        else
        {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
        }
    }

    // Collision enter event
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    // Collision exit event
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

}
