using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7;
    public float jump = 500;
    private bool isOnGround;
    private bool isFacingRight;

    Animator animator;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        bool ismoving = Move != 0.0;

        if (isOnGround) 
        {
            if (Input.GetButtonDown("Jump")) {
                rb.AddForce(new Vector2(rb.velocity.x, jump));
                animator.SetBool("isjumping", true);
                animator.SetBool("iswalking", false);
                animator.SetBool("isblobbing", false);
            } else {
                animator.SetBool("isjumping", false);
                animator.SetBool("iswalking", ismoving);
                animator.SetBool("isblobbing", !ismoving);
            }

            animator.SetBool("isfalling", false);

        } else {
            bool isfalling = rb.velocity.y < 0;
            animator.SetBool("isfalling", isfalling);
        }

        if ((Move > 0) && (!isFacingRight)) {
            Flip();
        } else if ((Move < 0) && (isFacingRight)) {
            Flip();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        isFacingRight = !isFacingRight;
    }

}
