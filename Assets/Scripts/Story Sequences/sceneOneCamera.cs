using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneOneCamera : MonoBehaviour {

    public GameObject player;
    public int step;

    private Vector3 target;
    private Vector3 vel;
    public float damping;
	void Start ()
    {
        player = GameObject.FindWithTag("Player");
        target = new Vector3();
         vel = Vector3.zero;
        damping = 0.3f;
        Camera.main.orthographicSize = 3.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (player.transform.position.x < -24f)
            step = 0;
        else if (player.transform.position.x > -24f && player.transform.position.x < -15f)
            step = 1;
        else if (player.transform.position.x > -15f && player.transform.position.y < 2.0f && player.transform.position.x < 0.0f)
            step = 2;
        else if (player.transform.position.x > -14.5 && player.transform.position.y > 2.0f && player.GetComponent<candyCollection>().candy == 0)
            step = 3;
        else if (player.transform.position.x > 8.0f && player.transform.position.x < 9.0f)
            step = 4;
        else if (player.transform.position.x > 10.0f && player.transform.position.x < 11.0f)
            step = 5;
        else if (player.GetComponent<candyCollection>().candy == 50 && player.transform.position.x > 11.0f && player.transform.position.x < 14.0f)
            step = 6;
        else if (player.transform.position.x > 12.0f && player.transform.position.x < 22.0f && player.GetComponent<candyCollection>().candy == 0)
            step = 7;
        else if (player.transform.position.x > 12.0f && player.transform.position.y < -3.0f && player.GetComponent<candyCollection>().candy == 50)
            step = 8;
        else if (player.GetComponent<candyCollection>().candy == 100 && player.transform.position.y < -3.0f)
            step = 9;
        else if (player.GetComponent<candyCollection>().candy == 100 && player.transform.position.y > 2.0f && player.transform.position.x > 21.0f)
            step = 10;
        else if (player.transform.position.x > 30.0f && player.transform.position.y < 1.0f && player.GetComponent<candyCollection>().candy == 0)
            step = 11;

        if (step == 0)
            target = new Vector3(-28.5f, 2, -10);
        else if (step == 1 || step == 3 || step == 5 || step == 7 || step == 8 || step == 9 || step == 11)
        {
            target = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            Camera.main.orthographicSize = 3.5f;
        }
        else if (step == 2)
            target = new Vector3(-9, 0, -10);
        else if (step == 4)
            target = new Vector3(9.75f, 1, -10);
        else if (step == 6)
        {
            target = new Vector3(22, 1, -10);
            Camera.main.orthographicSize = 5.5f;
        }
        else if(step == 10)
        {
            target = new Vector3(24, 5, -10);
        }
        */



        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, damping);
		
	}
}
