using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool movingRinght;
    private Rigidbody2D theRB;
    private Animator anim;
    public SpriteRenderer theSR;
    public float moveTime, waitTime;
    private float moveCount, waitCount;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightPoint.parent = null;
        anim = GetComponent<Animator>();
        movingRinght = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveCount > 0 )
        {
            moveCount -= Time.deltaTime;
            if (movingRinght)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                theSR.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRinght = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                theSR.flipX = false;
                if (transform.position.x < leftPoint.position.x)
                {
                    movingRinght = true;
                }

            }

            if (moveCount < 0) 
            { 
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        }else if (waitCount > 0)
        {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if (waitCount < 0)
            {
                moveCount =  Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", false);
        }

    }
}
