using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contactJump : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ai")
            if (other.GetComponent<matchAI>().takeJumps)
                other.GetComponent<basicActions>().jump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ai")
            collision.GetComponent<basicActions>().jump = false;
    }
}
