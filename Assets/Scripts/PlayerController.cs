using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //static public MovingObject instance;
    public float speed = 3f;
    public float jumpForce = 500f;
    private int jumpCount = 0;
    private bool isGrounded = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);

        if (h > 0)
        {
            playerRigidbody.velocity = new Vector2(speed, playerRigidbody.velocity.y);
            transform.localScale = new Vector3(5, 5, 5);
            animator.SetBool("walk", true);
        }

        else if (h < 0)
        {
            playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);
            transform.localScale = new Vector3(-5, 5, 5);
            animator.SetBool("walk", true);

        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 1)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Grounded", false);
        }

        else animator.SetBool("walk", false);

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }

        animator.SetBool("Grounded", isGrounded);
    }

    /*void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);

        if (h > 0) playerRigidbody.velocity = new Vector2(speed, playerRigidbody.velocity.y);
        if (h < 0) playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);

    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
