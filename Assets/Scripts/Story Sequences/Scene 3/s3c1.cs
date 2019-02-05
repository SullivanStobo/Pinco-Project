using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s3c1 : MonoBehaviour {

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
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Oda! You're back!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("That is correct. I'm glad to see that you won your first match.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("About earlier...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I should of mentioned that both our lives were on the line from the beginning.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I did not tell you in order to not seem selfish.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("What? Selfish?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You seemed very confused and upset. If I have immediately informed you that both yours and my life was dependant on your preformance, it may have been too much for you to handle.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I hope you can forgive me.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...Aww, Oda. You seem all robotish, but your really a big sap.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Of course I forgive you! After all the help you given me, how couldn't I.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("...You are very kind, Matilda.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Now then, where are we?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("This area is called the Hub. It was set up to allow Piñatas to rest inbetween matches.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("...You will find the other combantants in the area.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("It is up to you whether or not you want to interact with them.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You may find it difficult to compete against them if you get to know them.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("But I leave that you to you.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("When you are ready for your next fight, proceed down the elevator to the right.");
        MatildaTy.typeWrite("");
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
