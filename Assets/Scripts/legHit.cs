using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legHit : MonoBehaviour {


    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "leg")
        {
            collision.transform.root.GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
            collision.transform.root.GetComponent<AudioSource>().Play();
        }
    }
}
