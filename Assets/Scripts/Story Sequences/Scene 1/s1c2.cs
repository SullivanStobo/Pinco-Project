using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s1c2 : MonoBehaviour {

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
            viewed = true;
        }
    }

    private IEnumerator conv()
    {
        //Game Modes
        player.GetComponent<basicActions>().gameMode = 1;

        //Stop anim
        player.GetComponent<basicActions>().anim.SetBool("run", false);

        //Drone Stuff
        droneScript.follow = false;
        droneScript.target = new Vector3(-10, 1, 0);

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setTarget(new Vector3(-9, 0, -10));
        camScript.setSize(3.5f);

        //Cutscene
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("That's quite a big drop.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Apologies. This area of the Piñco™ factory is currently undergoing routine construction.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Please use the platforms above you to climb over the gap.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("How am I supposed to get up there?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("...Jump.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...Can Piñatas jump?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Quite well, in fact.  To jump press the 'up' key.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Alright.  I'll give that a try.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("");

        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;

        //Drone Stuff
        droneScript.follow = true;

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
