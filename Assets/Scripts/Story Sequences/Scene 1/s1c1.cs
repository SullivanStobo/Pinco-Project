using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s1c1 : MonoBehaviour {

    public bool viewed;
    public Text droneSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject drone;
    public GameObject pupil;

    private typeWirter DroneTy;
    private typeWirter MatildaTy;
    private cameraControl cameraScript;

    // Use this for initialization
    void Start ()
    {
        DroneTy = droneSpeech.GetComponent<typeWirter>();
        MatildaTy = matildaSpeech.GetComponent<typeWirter>();
        cameraScript = cam.GetComponent<cameraControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !viewed)
        {
            StartCoroutine("conv");
            viewed = true;
        }
    }

    private IEnumerator conv()
    {
        //Game Modes
        player.GetComponent<basicActions>().gameMode = 2;
        drone.GetComponent<drone>().gameMode = 1;

        //Camera Stuff
        cameraScript.folowPlayer(true);
        cameraScript.setSize(1);

        //Drone Stuff
        drone.GetComponent<drone>().target = new Vector3(-28.5f, 1);
        drone.GetComponent<drone>().follow = false;

        //Speech Stuff
        matildaSpeech.GetComponent<speech>().flip();
        matildaSpeech.GetComponent<speech>().setName("???");
        droneSpeech.GetComponent<speech>().setName("???");

        //Cutscene
        player.GetComponent<Animator>().SetBool("respawn", true);
        yield return new WaitForSeconds(3.5f);
        player.GetComponent<basicActions>().gameMode = 1;
        cameraScript.folowPlayer(false);
        cameraScript.setTarget(new Vector3(-28.5f, 2, -10));
        cameraScript.setSize(2.5f);
        DroneTy.typeWrite("Unbelieveable");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("The Mastermind's machines are truly impressive.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("To give a once inanimate object life through technology is legitimately stupendous.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I have never comprehended something more marvelous.");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("This is truly a technological miracle-");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("-Sorry, but what are you talking about? Who are you and how did I get here?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Also, who- who am I? I don't remember...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I am most sorry. Forgive my manners.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("I am Operational Drone Assistant number 213. Please refer to me as Oda.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.GetComponent<speech>().setName("Oda");
        DroneTy.typeWrite("This is Piñco™ Mega Factory 1.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Piñco™?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Piñco™ is the worlds largest and greatest producer of quality Piñatas.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You are, in fact, currently inhabiting a 'Matilda' model Piñata made by Piñco™.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("I'm a Piñata!?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Not technically. You are a randomly generated, highly sofisticated AI contained in that bracelet on your arm.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("The bracelet allows you to manipulate the Piñata as if it were an actual body.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("An AI? But I don't remember being a computer-");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Unfortunately that is the truth. As real as you may feel, you are not.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You have been given human like emotions and thoughts in order to fulfill you purpose.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        player.GetComponent<Animator>().SetBool("shrug", true);
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("Purpose? ...Why would someone go to all this trouble? Creating people and putting them in Piñatas?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        player.GetComponent<Animator>().SetBool("shrug", false);
        DroneTy.typeWrite("In order to determine which Piñco™ design is superior, The Mastermind created this technology in order for his designs to compete against eachother in a tournament.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("The Mastermind?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("The current owner and chief designer of Piñco™. No one knows his actual name.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...What if I don't want to compete? Can I just leave?");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("No. This tournament is the reason you were created. You are required to compete.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("If you were to refuse, your bracelet would destory and a new AI would be created in your place.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("The Mastermind has also stated that the Piñata AI that wins the tournament will be allowed to continue to exsist.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("All others will be permanently destroyed.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("So if you wish your exsistance to continue, I suggest you fulfill your purpose.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("...");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("..I guess I'll do it.");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("Excellent. As I mentioned before, your are currently using a 'Matilda' Piñata model. This is the model you will be representing in the tournament.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("As such, I will refer to you as Matilda from now on.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        matildaSpeech.GetComponent<speech>().setName("Matilda");
        DroneTy.typeWrite("My purpose is to provide you with information and assistance to help you win the tournament.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("You can begin by proceeding to the right.");
        MatildaTy.typeWrite("");
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        DroneTy.typeWrite("");
        MatildaTy.typeWrite("");

        //Game modes
        player.GetComponent<basicActions>().gameMode = 0;
        drone.GetComponent<drone>().gameMode = 0;

        //Drone follow
        drone.GetComponent<drone>().follow = true;

        //Camera Stuff
        cameraScript.setSize(3);
        cameraScript.folowPlayer(true);
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }
}
