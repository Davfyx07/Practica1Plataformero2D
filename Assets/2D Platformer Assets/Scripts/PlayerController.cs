using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this; 
    }


    [Header("Motion")]
    public float moveSpeed;

    [Header("Jump")]
    private bool canDoubleJump;
    public float jumpForce;
    public float bounceForce;

    [Header("Components")]
    public Rigidbody2D theRB;

    [Header("Grounded")]
    private bool isGrouded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGroud;


    [Header("Animator")]
    public Animator anim;
    private SpriteRenderer theSR;


    public float KnockBackLeght, KnockBackForce;
    private float KnockBackCouter;
    public bool stopInput;
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

    }

   
    void Move()
    {
        if (!PauseMenu.instance.isPaused && !stopInput) 
        {
            if (KnockBackCouter <= 0)
            {

                theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y); //move

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
                        AudioManager.instance.PlaySFX(10);

                    }
                    else if (canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(10);

                        canDoubleJump = false;
                    }
                }

                if (theRB.velocity.x < 0)
                {
                    theSR.flipX = true;

                }
                else if (theRB.velocity.x > 0)
                {
                    theSR.flipX = false;
                }

            }
            else
            {
                KnockBackCouter -= Time.deltaTime;
                if (!theSR.flipX)
                {
                    theRB.velocity = new Vector2(-KnockBackForce, theRB.velocity.y);
                }
                else
                {
                    theRB.velocity = new Vector2(KnockBackForce, theRB.velocity.y);

                }
            }

        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x)); //animation
        anim.SetBool("isGrounded", isGrouded); //animatino

    }
        

    public void KnockBack()
    {
        KnockBackCouter = KnockBackLeght;
        theRB.velocity = new Vector2(0f, KnockBackForce);
    }

    public void Bounce()
    {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }

}
