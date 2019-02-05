using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s8c2 : MonoBehaviour
{

    public bool viewed;
    public bool go;
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
        rowanSpeech.GetComponent<speech>().setName("Rowan");
        matildaSpeech.GetComponent<speech>().setName("Matilda");

        //Camera Stuff
        camScript.folowPlayer(false);
        camScript.setTarget(new Vector3(0, 0, -10));
        camScript.setSize(7.25f);

        //Cutscene
        //rowanSpeech.GetComponent<speech>().flip();

        rowanTy.typeWrite("...How.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        rowanTy.typeWrite("...I took all the advice he gave me, but still...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        Destroy(rowan);
        MatildaTy.typeWrite("Ugh, why didn't he just listen!? We could have both got out of here!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("As unlikeable as he is...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("Well, I guess I at least get to live.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("Back to the Hub to meet Oda.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("");
        Application.LoadLevel("hub3");


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

    }
}
