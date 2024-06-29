using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter2D : MonoBehaviour
{
    public int speed = 5;
    public SpriteRenderer sr;
    public Animator animator;
    public float jumpForce;
    public RigidBody2D rigidBody2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(Input.getKeyDown(KeyCode.Space))
        {

        }


        if(Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            sr.flipX = true;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
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
}
