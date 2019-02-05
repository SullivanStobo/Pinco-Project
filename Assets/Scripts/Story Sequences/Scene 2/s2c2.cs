using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s2c2 : MonoBehaviour {

    public bool viewed;
    public Text roboSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject roboMatilda;
    public bool go;

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
        camScript.setSize(8);

        //Cutscene
        roboTy.typeWrite("Crap...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("It wasn't supposed to go like this...");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("I'm.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("So.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("Much.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        roboTy.typeWrite("BETTER!");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        Destroy(roboMatilda);
        MatildaTy.typeWrite("Hey wait-");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("Darn.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("As mean as she was, I did want this to happen!");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("..Well, I guess the elevator will take me where ever I need to go next.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("I wonder where Oda got to...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        MatildaTy.typeWrite("");
        Application.LoadLevel("hub");

        //Game Modes
        player.GetComponent<basicActions>().gameMode = 0;

        //Drone Stuff
        //roboMatilda.GetComponent<basicActions>().gameMode = 0;

        //Camera Stuff
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
