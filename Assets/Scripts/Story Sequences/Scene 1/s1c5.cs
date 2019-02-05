using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s1c5 : MonoBehaviour {

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

        //Drone Stuff
        droneScript.follow = false;
        droneScript.target = new Vector3(23.5f, -2.25f);

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setSize(3.5f);

        //Cutscene
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...Do I really have to hit it?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("It's just a dummy.  It does not feel anything.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...I guess.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You have a variety of options when it comes to attacks.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Press 'z' to preform an overhead swing with your bat.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Press 'x' to quickly swing your other arm.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You can also press 'c' to kick.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You will automatically collect any candy you knock out of the dummy.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Let me know when you have 100 candy.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...");
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
