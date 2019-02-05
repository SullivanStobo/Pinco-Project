using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyCollection : MonoBehaviour {

    public int candy;

    public bool onCpp;

    public GameObject ccp;

	// Use this for initialization
	void Start ()
    {
        onCpp = false;
        ccp = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ccp != null)
        {
            /*
            if (tag == "Player")
            {
                if (onCpp && Input.GetButton("Fire2") && ccp.GetComponent<ccpScript>().candy > 1)
                {
                    candy++;
                    ccp.GetComponent<ccpScript>().candy--;
                }
            }
            else if(tag == "ai")
            {
                if (GetComponent<basicAI>().isCollecting && ccp.GetComponent<ccpScript>().candy > 1)
                {
                    candy++;
                    ccp.GetComponent<ccpScript>().candy--;
                }
            }
            */

            if (GetComponent<basicActions>().isCollecting && ccp.GetComponent<ccpScript>().candy > 1)
            {
                candy++;
                ccp.GetComponent<ccpScript>().candy--;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "ccp")
        {
            ccp = hit.gameObject;
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ccp")
            ccp = null;
    }

}
