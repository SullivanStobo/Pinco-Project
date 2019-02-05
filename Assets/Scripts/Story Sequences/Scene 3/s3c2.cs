using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s3c2 : MonoBehaviour {

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
        MatildaTy.typeWrite("Hi!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("Hello?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("Umm...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...Ugh. Can you not take a hint?");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("I got way more important things to do than talk to inferior Piñatas like you.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...Important thing like mope by this window?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("Exactly.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("");
        MatildaTy.typeWrite("...Well, you have fun with that. I'll see you later!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("Hm.");
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
