using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 300f;
    public GameManager manager;
    private int jumpCount = 0;
    private bool isWalking = false;
    private bool isJumping = false;
    public GameObject scanObject;

    private Vector3 dirVec;


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
            animator.SetBool("Walking", true);
            dirVec = Vector3.right;
        }

        else if (h < 0)
        {
            playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);
            transform.localScale = new Vector3(-5, 5, 5);
            animator.SetBool("Walking", true);
            dirVec = Vector3.left;

        }
        else animator.SetBool("Walking", false);


        if (Input.GetMouseButtonDown(0) && jumpCount < 1)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        if (playerRigidbody.velocity.x == 0)
        {
            animator.SetBool("Walking", false);
        }
        else
            animator.SetBool("Walking", true);

    }

    void FixedUpdate()
    {

        Debug.DrawRay(playerRigidbody.position, new Vector3(1,0,0), new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(playerRigidbody.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }

        else
            scanObject = null;

        /*float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);

        if (h > 0) playerRigidbody.velocity = new Vector2(speed, playerRigidbody.velocity.y);
        if (h < 0) playerRigidbody.velocity = new Vector2(-speed, playerRigidbody.velocity.y);
        */
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("플레이어 피격");
            OnDamaged(collision.transform.position);
        }



        jumpCount = 0;

    }

    void OnTriggerEnter2D(Collider2D I)
    {
        if (I.gameObject.tag == "Item")
        {
            Debug.Log("아이템 획득");
            Destroy(I.gameObject);
        }

    }

    void OnDamaged(Vector2 targetPos)
    {
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        playerRigidbody.AddForce(new Vector2(dirc, 1) * 3, ForceMode2D.Impulse);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //isWalking = false;
        //isJumping=true;
    }
}
