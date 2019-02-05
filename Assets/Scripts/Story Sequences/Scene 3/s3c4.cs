using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s3c4 : MonoBehaviour {

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

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);

        //Drone Stuff
        starSpeech.GetComponent<speech>().setName("???");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(true);
        camScript.setSize(3.5f);

        //Cutscene
        starSpeech.GetComponent<speech>().flip();

        starTy.typeWrite("...Go...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("...Away...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
        MatildaTy.typeWrite("...Alright then.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        starTy.typeWrite("");
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
