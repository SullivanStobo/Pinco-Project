using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s6c1 : MonoBehaviour {

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
        rusty.GetComponent<basicActions>().gameMode = 1;

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);

        //Drone Stuff
        rustySpeech.GetComponent<speech>().setName("Rusty");
        matildaSpeech.GetComponent<speech>().setName("Matilda");
        rustySpeech.GetComponent<speech>().flip();

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setTarget(new Vector3(0, 0, -10));
        camScript.setSize(8f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Rusty? Oh no, why couldn't it be that grumpy fox!?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Yeah, this is pretty unlucky isn't it?");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("I suppose either way we won't get that chance to know each better.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("...I guess not.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Well then, I suppose this fight is all we have.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Lets both give it our best. It's been good knowing you, Matilda.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Right back at you, Starshine.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("");


        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;
        rusty.GetComponent<basicActions>().gameMode = 0;

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
