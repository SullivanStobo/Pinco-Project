using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s4c1 : MonoBehaviour {

    public bool viewed;
    public Text starSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject star;

    private typeWirter starTy;
    private typeWirter MatildaTy;
    //private drone droneScript;
    private cameraControl camScript;

    // Use this for initialization
    void Start()
    {
        starTy = starSpeech.GetComponent<typeWirter>();
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
        star.GetComponent<basicActions>().gameMode = 1;

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);

        //Drone Stuff
        starSpeech.GetComponent<speech>().setName("???");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setTarget(new Vector3(0, 0, -10));
        camScript.setSize(8f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        starTy.typeWrite("");
        MatildaTy.typeWrite("Oh look, it's... You.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("I think I saw you around the Hub.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("I think I saw you around the Hub.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("I don't think we've porperly met. I'm Matilda!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("...I don't care.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("...You will lose and then you will die.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("...Well, I suppose we'll see about that.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("Good luck!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("");

        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;
        star.GetComponent<basicActions>().gameMode = 0;

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
