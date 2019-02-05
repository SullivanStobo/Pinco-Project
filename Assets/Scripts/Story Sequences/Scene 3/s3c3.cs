using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s3c3 : MonoBehaviour {

    public bool viewed;
    public Text rustySpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject rusty;

    private typeWirter rustyTy;
    private typeWirter MatildaTy;
    //private drone droneScript;
    private cameraControl camScript;

    // Use this for initialization
    void Start()
    {
        rustyTy = rustySpeech.GetComponent<typeWirter>();
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
        rustySpeech.GetComponent<speech>().setName("???");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3.5f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Hello there!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Hello yourself! And who might you be?");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("I'm Matilda. And you?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustySpeech.GetComponent<speech>().setName("Rusty");
        rustyTy.typeWrite("Well, uhh... You can call me Rusty.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Technically this Piñatas model name is 'Rainbow Starshine', but I think Rusty suites me a little better.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Rainbow Starshine? I can definitely see why you went with Rusty.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("...Yeah.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("...Well, it was good meeting you Rusty!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("You too Matilda. Hopefully I'll see you around.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
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
