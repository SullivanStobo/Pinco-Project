using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour {

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        rb.AddTorque(transform.rotation.z * 100);
    }

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "lightAttack" || hit.gameObject.tag == "heavyAttack" || hit.gameObject.tag == "kick")
        {
            print("Hit!");
            if (hit.gameObject.transform.position.x > this.gameObject.transform.position.x)
                rb.AddTorque(-100);
            else
                rb.AddTorque(100);
        }

    }
}
