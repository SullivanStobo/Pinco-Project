using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour {

    public float parallaxDistance;

    GameObject cam;
    Vector2 playerStart;
    Vector2 objectStart;
    Vector2 playerPos;
    Vector2 objectPos;

    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        playerStart = new Vector2(cam.transform.position.x, cam.transform.position.y);
        objectStart = new Vector2(transform.position.x, transform.position.y);

        playerPos = new Vector2();
        objectPos = new Vector2();

    }

    // Update is called once per frame
    void Update ()
    {
        playerPos.x = cam.transform.position.x;
        playerPos.y = cam.transform.position.y;

        objectPos.x = transform.position.x;
        objectPos.y = transform.position.y;

        transform.position = new Vector3(((playerPos.x - playerStart.x) + objectStart.x) * 1/parallaxDistance, ((playerPos.y - playerStart.y) + objectStart.y) * 1/parallaxDistance, 0);
		
	}
}
