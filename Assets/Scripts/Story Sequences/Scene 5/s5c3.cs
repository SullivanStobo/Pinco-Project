using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s5c3 : MonoBehaviour {

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
        rustySpeech.GetComponent<speech>().setName("Rusty");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3.5f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Hey again Rusty, or should I say Rainbow Sunshine?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("I really perfer if you didn't bring up that name.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("It's bad enough being a Piñata without being reminded I have the least manly name in exsistance.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Not to mention I the fact that non of my limbs actually move.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("You and that fox over there don't know how lucky you are.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Yeah, but you get to float around and cool stuff like that. Who needs working limbs?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("And...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("Rainbow Starshine is an absolutely ADORABLE name! How could you not love it!?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("Huh. You really are an interesting person, Matilda.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("If you can call what we are people, that is.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("When faced with impending death, you can managed to be so cheery.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("I wish there were a way I could get the chance to know you better.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rustyTy.typeWrite("");
        MatildaTy.typeWrite("...Thanks Rusty. I wish there was too.");
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
