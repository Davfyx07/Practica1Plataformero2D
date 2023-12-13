using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [Header("Motion")]
    public float moveSpeed;

    [Header("Jump")]
    private bool canDoubleJump;
    public float jumpForce;

    [Header("Components")]
    public Rigidbody2D theRB;

    [Header("Grounded")]
    private bool isGrouded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGroud;


    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer theSR;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jumps();

      
    }

    void Jumps()
    {
        isGrouded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGroud); //validar si esta en el suelo

        if (isGrouded)
        {
            canDoubleJump = true;

        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrouded)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }
            else if (canDoubleJump)
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                canDoubleJump = false;
            }

        }
        anim.SetBool("isGrounded", isGrouded); //animatino

    }
    void Move()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y); //move
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x)); //animation
        if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;

        } else if(theRB.velocity.x > 0) { 
            theSR.flipX = false;
        }
    }


}
