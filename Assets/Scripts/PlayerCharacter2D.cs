using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter2D : MonoBehaviour
{
    public int speed = 5;
    public SpriteRenderer sr;
    public Animator animator;
    public float jumpForce;
    public Rigidbody2D rigidBody2D;
    bool isGrounded = true;

    bool isShootTimerInProgress = false;
    float shootTimer = 0.2f;
    public Transform positionRight; 
    public Transform positionLeft;
    public GameObject bullet; 

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        isShootTimerInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShootTimerInProgress)
        {
            shootTimer -= Time.deltaTime;
        }
        if(shootTimer <= 0)
        {
            isShootTimerInProgress = false;
            animator.SetBool("isShooting", false);
            shootTimer = 0.2f;
        }

        Movement();
        if(isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        // This is added so that the character can fall much faster which looks better in the game. 
        if(rigidBody2D.velocity.y < 0)
        {
            rigidBody2D.velocity += Vector2.up * Physics2D.gravity.y * 2 * Time.deltaTime; 
        }
    }

    void Movement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(!isShootTimerInProgress)
            {
                animator.SetBool("isShooting", true);
                isShootTimerInProgress = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidBody2D.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            animator.SetBool("isShooting", false);
        }

        if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            animator.SetBool("isShooting", false);
            sr.flipX = true;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
            animator.SetBool("isShooting", false);
             sr.flipX = false;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            // animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(0, speed*Time.deltaTime, 0));
        }
        else if(Input.GetKey(KeyCode.S))
        {
            // animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime, 0));
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }
}
