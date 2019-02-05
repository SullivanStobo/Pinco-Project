using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s2c1 : MonoBehaviour {

    public bool viewed;
    public Text roboSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject roboMatilda;

    private typeWirter roboTy;
    private typeWirter MatildaTy;
    private cameraControl camScript;

    // Use this for initialization
    void Start()
    {
        roboTy = roboSpeech.GetComponent<typeWirter>();
        MatildaTy = matildaSpeech.GetComponent<typeWirter>();
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
        matildaSpeech.GetComponent<speech>().flip();

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);
        roboMatilda.GetComponent<basicActions>().anim.SetBool("run", false);
        roboMatilda.GetComponent<basicActions>().anim.SetBool("fall", false);

        //RoboMatilda Stuff
        roboMatilda.GetComponent<basicActions>().gameMode = 1;
        roboMatilda.GetComponent<basicActions>().facingRight = false;
        roboSpeech.GetComponent<speech>().flip();

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setTarget(new Vector3(0, 0, -10));
        camScript.setSize(8f);

        //Cutscene
        roboTy.typeWrite("");
        MatildaTy.typeWrite("Hey! You look just like me!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("Na, I think YOU look like me.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("My O.D.A. told me that they accidentally made two AIs for the Matilda model.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("We're fighting to determine which of us is the better Matilda.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("...And just from looking at you, I can already tell that's me.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        player.GetComponent<Animator>().SetBool("shrug", true);
        roboTy.typeWrite("");
        MatildaTy.typeWrite("Fighting? I thought these match were just about collecting candy!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        player.GetComponent<Animator>().SetBool("shrug", false);
        roboTy.typeWrite("What, you thought we were just going to let eachother peacefully collect candy in a contest where the loser dies?");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("You're even dumber than you look.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("I hope your O.D.A. at least showed you how to fight. Wouldn't want this to be too easy.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("");
        MatildaTy.typeWrite("");

        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;

        //Drone Stuff
        roboMatilda.GetComponent<basicActions>().gameMode = 0;

        //Camera Stuff
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
