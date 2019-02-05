using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s4c2 : MonoBehaviour {

    public bool viewed;
    public bool go;
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
        if (go && !viewed)
        {
            StartCoroutine("conv");
            player.GetComponent<basicActions>().anim.SetBool("fall", false);
            viewed = true;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !viewed)
        {
            StartCoroutine("conv");
            player.GetComponent<basicActions>().anim.SetBool("fall", false);
            viewed = true;
        }
    }
    */

    private IEnumerator conv()
    {
        //Game Modes
        player.GetComponent<basicActions>().gameMode = 1;

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

        starTy.typeWrite("...Impossible...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        Destroy(star);
        MatildaTy.typeWrite("Well... I do sort of still feel bad.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("..He was quite a downer though.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("Back to the hub!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("");
        Application.LoadLevel("hub1");



        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;

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
