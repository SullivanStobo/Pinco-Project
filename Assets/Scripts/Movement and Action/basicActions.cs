using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicActions : MonoBehaviour {

    public float groundForce;
    public float airForce;
    public float jumpForce;

    //Rigid body for moving
    public Rigidbody2D rb;
    public Animator anim;


    private float xForce;
    private float yForce;

    private int maxSpeed;
    public int points;

    public bool facingRight;
    public float curRot;

    public bool grounded;
    public int gameMode;

    public int move;
    public bool jump;
    public bool HAttack;
    public bool LAttack;
    public bool Kick;
    public bool isCollecting;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        xForce = 0;
        yForce = 0;
        facingRight = true;
        maxSpeed = 5;
        curRot = 0;

        move = 0;
        jump = false;
        LAttack = false;
        HAttack = false;
        Kick = false;
        isCollecting = false;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Actions
        if (gameMode == 0)
        {
            rb.gravityScale = 2;
            if (!anim.GetBool("NHeavy") && !anim.GetBool("Nlight") && !anim.GetBool("NKick"))
            {
                if (move == 1)
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
                else if (move == -1)
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

            if (rb.velocity.y > 0.1 && !grounded)
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
            else if (!anim.GetBool("jump"))
                anim.SetBool("fall", true);
            

            if (HAttack && grounded)
            {
                xForce = 0;
                anim.SetBool("run", false);
                anim.SetBool("NHeavy", true);
            }

            if(LAttack && grounded)
            {
                xForce = 0;
                anim.SetBool("run", false);
                anim.SetBool("Nlight", true);
            }

            if (Kick && grounded)
            {
                xForce = 0;
                anim.SetBool("run", false);
                anim.SetBool("NKick", true);
            }

            rb.AddForce(new Vector2(xForce, yForce));

            if (System.Math.Abs(rb.velocity.x) > maxSpeed)
                rb.AddForce(new Vector2(-xForce, 0));
        }
        else if(gameMode == 1)
        {
            //Used for text cutscenes (with physics)
            rb.gravityScale = 2;
        }
        else if(gameMode == 2)
        {
            //Used for cutscenes when we dont want physics
            rb.gravityScale = 0;
        }

        //Flipping
        if (!anim.GetBool("NHeavy") && !anim.GetBool("Nlight") && !anim.GetBool("NKick"))
        {
            if (facingRight && curRot != 0 || !facingRight && curRot != 180)
            {
                transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                if (facingRight)
                    curRot = 0;
                else
                    curRot = 180;
            }
        }

    }

    private void OnCollisionStay2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "ground" && rb.velocity.y < 0.1)
        {
            grounded = true;
            anim.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "ground")
            grounded = false;
    }
}
