using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s9c1 : MonoBehaviour {

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
        MatildaTy.typeWrite("Hey Oda. Looks like I managed to beat him.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Excellent work, Matilda. And excellent work to you as well, player.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("At this point in the game, there would usually be a cool twist where it would turn out The Mastermind was lying the whole time, and then I would fight him and it would be really cool-");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("But, unfortunately, it's currently 6AM and the programmer has been up all night working on this.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("In the future this game may get a proper ending.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("But for now, this is where it ends.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Thanks so much for getting me this far!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("We both hope to see you when the ending gets implemented.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Thanks for playing!");
        MatildaTy.typeWrite("Thanks for playing!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("");

        Application.Quit();

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
