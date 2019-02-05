using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s5c2 : MonoBehaviour {

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
        rowanSpeech.GetComponent<speech>().setName("???");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3.5f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rowanTy.typeWrite("");
        MatildaTy.typeWrite("Hey again.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("Ugh, not you again.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("Go away.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("Look I'm just trying to be friendly!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("Anyone of these fights could be our last right?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("I'd like to at least have the pleausre of getting to know a few people in my potenitally tragically shoft lifespan!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanSpeech.GetComponent<speech>().setName("Rowan");
        rowanTy.typeWrite("I'm Rowan.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...There, now you know me. Happy?");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("No leave me alone.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...Nice meeting you Rowan.");
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
