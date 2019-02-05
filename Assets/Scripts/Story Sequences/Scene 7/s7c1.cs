using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s7c1 : MonoBehaviour {

    public bool viewed;
    public Text droneSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject drone;

    private typeWirter DroneTy;
    private typeWirter MatildaTy;
    private drone droneScript;
    private cameraControl camScript;

    // Use this for initialization
    void Start()
    {
        DroneTy = droneSpeech.GetComponent<typeWirter>();
        MatildaTy = matildaSpeech.GetComponent<typeWirter>();
        droneScript = drone.GetComponent<drone>();
        camScript = cam.GetComponent<cameraControl>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !viewed)
        {
            StartCoroutine("conv");
            player.GetComponent<basicActions>().anim.SetBool("fall", false);
            viewed = true;
        }
    }

    private IEnumerator conv()
    {
        //Game Modes
        player.GetComponent<basicActions>().gameMode = 1;

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);

        //Drone Stuff
        droneScript.follow = true;
        droneSpeech.GetComponent<speech>().setName("Oda");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3.5f);

        //Cutscene
        DroneTy.typeWrite("Hello Marilda. I hear you were victorious against Rainbow Starshine.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...Yeah.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("...Thank you. I know that could not have been easy. He seemed like a good person.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("...Whenever you're ready, your last fight is againt Rowan the fox.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("If you win, we will both be free of this tournament.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I believe in you, Matilda.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("");

        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;

        //Drone Stuff
        droneScript.follow = false;

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3);
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
