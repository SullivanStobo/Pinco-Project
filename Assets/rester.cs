using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rester : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(-13, 1, 0);
    }
}
