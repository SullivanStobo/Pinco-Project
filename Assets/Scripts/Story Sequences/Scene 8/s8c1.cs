using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s8c1 : MonoBehaviour {

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
        rowan.GetComponent<basicActions>().gameMode = 1;

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);
        rowan.GetComponent<basicActions>().anim.SetBool("run", false);
        rowan.GetComponent<basicActions>().anim.SetBool("fall", false);

        //Drone Stuff
        rowanSpeech.GetComponent<speech>().setName("Rowan");
        matildaSpeech.GetComponent<speech>().setName("Matilda");
        matildaSpeech.GetComponent<speech>().flip();

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setTarget(new Vector3(0, 0, -10));
        camScript.setSize(8f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rowanTy.typeWrite("I don't have anything to say you.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...Well I something to say to you.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...This is a pretty awful situation.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("We're living being created by some madman to help sell Piñatas!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...I say, instead of fighting eachother, why don't we do something about this?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("There's got to be some way out of all this! We can work together, and both get out!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...This is some sort of clever trick.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("I didn't think a sap like you could be clever. You impress me.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("However, it is now time for me to win and leave this terrible place.");
        MatildaTy.typeWrite("Wait, but it's not a trick, if we just could-");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("Die, sap!");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("");


        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;
        rowan.GetComponent<basicActions>().gameMode = 0;

        //Drone Stuff
        //droneScript.follow = false;

        //Camera Stuff
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
