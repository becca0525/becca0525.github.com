using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerAction : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 300f;
    private int jumpCount = 0;
    private bool iswalking = false;
    private bool Jumping = false;
    private bool Grounded = true;
    Vector3 dirVec;

    private Animator anim;
    private Rigidbody2D rd;


    void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(h, 0, 0) * Time.deltaTime);

        if (h > 0)
        {
            rd.velocity = new Vector2(speed, rd.velocity.y);
            transform.localScale = new Vector3(5, 5, 5);
            anim.SetBool("iswalking", true);
            dirVec = Vector3.right;
        }

        else if (h < 0)
        {
            rd.velocity = new Vector2(-speed, rd.velocity.y);
            transform.localScale = new Vector3(-5, 5, 5);
            anim.SetBool("iswalking", true);
            dirVec = Vector3.left;
        }

        else anim.SetBool("iswalking", false);

        if (Input.GetMouseButtonDown(0) && jumpCount < 1)
        {
            jumpCount++;
            rd.velocity = Vector2.zero;
            rd.AddForce(new Vector2(0, jumpForce));
            anim.SetBool("Jumping", true);
            anim.SetBool("Grounded", false);

        }
        /*else
         {
             anim.SetBool("Jumping", false);
         }*/




        /*
        if (rd.velocity.x == 0)
        {
            anim.SetBool("iswalking", false);
        }
        else
            anim.SetBool("iswalking", true);
        */
    }

    void FixedUpdate()
    {

        Debug.DrawRay(rd.position, new Vector3(10, 0, 0), new Color(0, 1, 0));
        //RaycastHit2D rayHit = Physics2D.Raycast(rd.position, new Vector3(6, 0, 0), LayerMask.GetMask("Item"));
        /*
        if (rayHit.collider != null)
        {
            Debug.Log(rayHit.collider.name);*/
            //scanObject = rayHit.collider.gameObject;
    }
        /*
        else
            scanObject = null;*/

    
    void OnCollisionEnter2D(Collision2D collision)
    {
            jumpCount = 0;
            anim.SetBool("Jumping", false);
            anim.SetBool("Grounded", true);

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("플레이어 피격");
            OnDamaged(collision.transform.position);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Item")
        {
            Debug.Log("아이템 획득");
            AudioSource Sound = GetComponent<AudioSource>();
            Sound.Play();
            Destroy(other.gameObject);

        }

        else if (other.tag == "home"){
            Debug.Log("게임클리어");
            SceneManager.LoadScene("Home");

        }

    }

    void OnDamaged(Vector2 targetPos)
    {
        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rd.AddForce(new Vector2(dirc, 1) * 3, ForceMode2D.Impulse);
    }
}


    /*
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rd.AddForce(Vector2.right * h, ForceMode2D.Impulse);
    }*/


