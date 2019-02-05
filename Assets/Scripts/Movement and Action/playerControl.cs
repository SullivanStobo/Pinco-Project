using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moving
        if (Input.GetAxis("Horizontal") > 0)
            GetComponent<basicActions>().move = 1;
        else if (Input.GetAxis("Horizontal") < 0)
            GetComponent<basicActions>().move = -1;
        else
            GetComponent<basicActions>().move = 0;

        //Jumping
        if (Input.GetAxis("Vertical") > 0)
            GetComponent<basicActions>().jump = true;
        else
            GetComponent<basicActions>().jump = false;

        //Attacking
        if (Input.GetButton("Fire1"))
            GetComponent<basicActions>().HAttack = true;
        else
            GetComponent<basicActions>().HAttack = false;

        if (Input.GetButton("Fire2"))
            GetComponent<basicActions>().Kick = true;
        else
            GetComponent<basicActions>().Kick = false;

        if (Input.GetButton("Fire3"))
            GetComponent<basicActions>().LAttack = true;
        else
            GetComponent<basicActions>().LAttack = false;

        //Collecting
        if (Input.GetButton("Fire4"))
            GetComponent<basicActions>().isCollecting = true;
        else
            GetComponent<basicActions>().isCollecting = false;


    }
}
