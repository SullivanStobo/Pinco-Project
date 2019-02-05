using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
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
    public float curRot;

    public bool grounded;
    public int gameMode;

    public int points;

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

        anim.Play("idle");
    }
	
    //Nobody likes this update
	void Update ()
    {
        //animator.Play(state);
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
        if (gameMode == 0)
        {
            if (!anim.GetBool("NHeavy"))
            {
                //Moving
                if (Input.GetAxis("Horizontal") > 0)
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
                else if (Input.GetAxis("Horizontal") < 0)
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

            if (Input.GetAxis("Vertical") > 0 && grounded && rb.velocity.y < 0.1)
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

            if (Input.GetButton("Fire1") && grounded)
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
