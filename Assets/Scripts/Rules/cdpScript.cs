using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cdpScript : MonoBehaviour {

    public GameObject actor;
    public int acceptedAmount;
    public Text cdpText;
    private Animator anim;
    private bool locked;

    public Vector3 playerResetPosition;
    public Vector3 aiResetPosition;


    // Use this for initialization
    void Start ()
    {
        actor = null;
        anim = GetComponent<Animator>();
        cdpText.text = acceptedAmount.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (actor != null)
        {
            if (actor.GetComponent<candyCollection>().candy >= acceptedAmount)
            {
                locked = true;
                actor.GetComponent<basicActions>().gameMode = 2;
                actor.GetComponent<basicActions>().rb.velocity = new Vector3(0, 0);
                anim.SetTrigger("swing");
                score();
            }
        }
	}

    private void score()
    {
        actor.GetComponent<candyCollection>().candy = 0;
        actor.GetComponent<basicActions>().points++;
        Invoke("resetPos", 0.6f);
    }

    private void resetPos()
    {
        if(actor.tag == "Player")
            actor.transform.position = playerResetPosition;
        else if(actor.tag == "ai")
            actor.transform.position = aiResetPosition;
        actor.GetComponent<basicActions>().anim.SetBool("respawn", true);
        if(actor.tag == "ai")
        {
            actor.GetComponent<matchAI>().reset();
        }
        Invoke("release", 3.25f);
    }

    private void release()
    {
        print("bop");
        actor.GetComponent<basicActions>().gameMode = 0;
        actor = null;
        locked = false;

    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (!locked)
        {
            if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "ai")
            {
                actor = hit.gameObject;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(!locked)
            actor = null;
    }
}
