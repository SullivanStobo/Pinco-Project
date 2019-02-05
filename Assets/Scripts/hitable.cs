using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitable : MonoBehaviour {

    public GameObject actor;
    public int hitLoss;
    private int offset;
    private int usedOffset;
    private int dir;

    // Use this for initialization
    void Start ()
    {
        actor = null;
        offset = 1;
        dir = 1;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        /*
        if (tag == "Player")
        {
            if (!GetComponent<basicActions>().facingRight)
                usedOffset = offset * -1;
            else
                usedOffset = offset;
        }
        else if (tag == "ai")
        {
            if (!GetComponent<basicAI>().facingRight)
                usedOffset *= -offset * -1;
            else
                usedOffset = offset;
        }
        */

   
        if (hit.gameObject.tag == "lightAttack" || hit.gameObject.tag == "heavyAttack" || hit.gameObject.tag == "kick")
        {
            hit.GetComponent<AudioSource>().Play();
            actor = hit.transform.root.gameObject;
            if (GetComponent<candyCollection>().candy >= hitLoss)
            {
                GetComponent<candyCollection>().candy -= hitLoss;
                actor.GetComponent<candyCollection>().candy += hitLoss;
            }
            if (hit.gameObject.transform.root.position.x > transform.root.position.x - usedOffset)
            {
                dir = -1;
            }
            else
            {
                dir = 1;
            }

            GetComponent<basicActions>().anim.SetBool("NHeavy", false);
            GetComponent<basicActions>().anim.SetBool("Nlight", false);
            GetComponent<basicActions>().anim.SetBool("NKick", false);

            if (hit.gameObject.tag == "lightAttack")
                GetComponent<Rigidbody2D>().AddForce(new Vector3(50 * dir, 5, 0));
            else if (hit.gameObject.tag == "heavyAttack")
                GetComponent<Rigidbody2D>().AddForce(new Vector3(100 * dir, 10, 0));
            else if (hit.gameObject.tag == "kick")
                GetComponent<Rigidbody2D>().AddForce(new Vector3(75 * dir, 7.5f, 0));
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        actor = null;
    }
}
