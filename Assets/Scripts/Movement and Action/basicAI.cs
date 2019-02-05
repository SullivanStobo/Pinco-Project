using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAI : MonoBehaviour {

    public GameObject CCP;
    public GameObject CDP;
    public GameObject player;

    private Vector3 CCPpos;
    private Vector3 CDPpos;
    private Vector3 playerpos;

    public float groundForce;
    public float airForce;
    public float jumpForce;

    //Rigid body for moving
    private Rigidbody2D rb;
    public Animator anim;

    private SpriteRenderer SpR;

    private float xForce;
    private float yForce;

    private float LinearDrag;
    private int maxSpeed;

    public bool facingRight;
    private float curRot;

    public bool grounded;
    public int gameMode;

    private bool moveRight;
    private bool moveLeft;
    private bool jump;
    public bool attack;
    public bool isCollecting;
    public int points;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        SpR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        xForce = 0;
        yForce = 0;
        facingRight = true;
        LinearDrag = rb.drag * 10;
        maxSpeed = 5;
        curRot = 0;

        moveRight = false;
        moveLeft = false;
        jump = false;
        attack = false;
        isCollecting = false;

        CCPpos = CCP.transform.position;
        CDPpos = CDP.transform.position;
        playerpos = player.transform.position;

        anim.Play("idle");
    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "ground" && rb.velocity.y < 0.1)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "ground")
            grounded = false;
    }

    private void FixedUpdate()
    {
        //Decision making

        playerpos = player.transform.position;

        if (Mathf.Abs(playerpos.x - transform.position.x) < 2 && Mathf.Abs(playerpos.y - transform.position.y) < 0.5)
        {
            //ATTACK
            if (curRot == player.GetComponent<control>().curRot)
            {
                if (facingRight)
                    facingRight = false;
                else
                    facingRight = true;
            }
            attack = true;
            jump = false;
            moveLeft = false;
            moveRight = false;

        }
        //Doesnt have enough candy to score
        else if (GetComponent<candyCollection>().candy < CDP.GetComponent<cdpScript>().acceptedAmount)
        {
            attack = false;

            if (Mathf.Abs(CCPpos.x - transform.position.x) > 0.1 && Mathf.Abs(CCPpos.y - transform.position.y) > 0.5)
            {
                jump = false;
                isCollecting = false;
                if (CCPpos.x > transform.position.x)
                {
                    moveRight = true;
                    moveLeft = false;
                }
                else
                {
                    moveRight = false;
                    moveLeft = true;
                }
            }
            else
            {
                moveRight = false;
                moveLeft = false;
                isCollecting = true;
            }
        }
        //Has enough
        else
        {
            attack = false;
            if (Mathf.Abs(CDPpos.y - transform.position.y) > 2)
            {
                moveRight = true;
                moveLeft = false;
                jump = true;
            }
            else if (Mathf.Abs(CDPpos.x - transform.position.x) > 0.2 && Mathf.Abs(CDPpos.y - transform.position.y) > 0.5)
            {
                isCollecting = false;
                if (CCPpos.x > transform.position.x)
                {
                    moveRight = true;
                    moveLeft = false;
                }
                else
                {
                    moveRight = false;
                    moveLeft = true;
                }
            }
        }

        //Actions
        if (gameMode == 0)
        {
            if (!anim.GetBool("NHeavy"))
            {
                if (moveRight)
                {
                    if (grounded)
                    {
                        xForce = groundForce;
                        anim.SetBool("run", true);
                    }
                    else
                    {
                        xForce = airForce;
                    }
                    facingRight = true;
                }
                else if (moveLeft)
                {
                    if (grounded)
                    {
                        xForce = -groundForce;
                        anim.SetBool("run", true);
                    }
                    else
                    {
                        xForce = -airForce;
                    }
                    facingRight = false;
                }
                //Not moving
                else
                {
                    xForce = 0;
                    anim.SetBool("run", false);
                }
            }

            if (jump && grounded && rb.velocity.y < 0.1)
            {
                yForce = jumpForce;
            }
            else
                yForce = 0.0f;

            if (rb.velocity.y > 0.1)
            {
                anim.SetBool("jump", true);
                anim.SetBool("run", false);
            }
            else if (anim.GetBool("jump") && rb.velocity.y < 0.1)
            {
                anim.SetBool("fall", true);
                anim.SetBool("jump", false);
            }

            if (grounded)
                anim.SetBool("fall", false);

            if (attack && grounded)
            {
                xForce = 0;
                anim.SetBool("run", false);
                anim.SetBool("NHeavy", true);
            }


            //Flipping
            if (facingRight && curRot != 0 || !facingRight && curRot != 180)
            {
                transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                if (facingRight)
                    curRot = 0;
                else
                    curRot = 180;
            }

            rb.AddForce(new Vector2(xForce, yForce));

            if (System.Math.Abs(rb.velocity.x) > maxSpeed)
                rb.AddForce(new Vector2(-xForce, 0));
        }
    }
}
