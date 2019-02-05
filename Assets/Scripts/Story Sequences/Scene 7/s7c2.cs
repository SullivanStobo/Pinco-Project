using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s7c2 : MonoBehaviour {

    public bool viewed;
    public Text rowanSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject rowan;

    private typeWirter rowanTy;
    private typeWirter MatildaTy;
    //private drone droneScript;
    private cameraControl camScript;

    // Use this for initialization
    void Start()
    {
        rowanTy = rowanSpeech.GetComponent<typeWirter>();
        MatildaTy = matildaSpeech.GetComponent<typeWirter>();
        // droneScript = rowan.GetComponent<drone>();
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
        rowanSpeech.GetComponent<speech>().setName("Rowan");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3.5f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...I hear you beat that pony thing.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("He'd been gunning for me from the beginning. I guess I should thank you.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("But I won't.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("This is a competition where losing means death.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("There's no room for feelings here.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("I've only exsisted for a few hours and only seen the inside of this dreary factory.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("Life has so much more to offer me, and I'm not letting some sap like take that from me.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("I'll see you in the arena.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("");


        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;

        //Drone Stuff
        //droneScript.follow = false;

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
