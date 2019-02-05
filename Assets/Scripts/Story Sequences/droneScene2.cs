using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class droneScene2 : MonoBehaviour {
    public Text droneSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public GameObject enemy;
    public Text winText;

    private Vector3 vel;
    public float damping;

    private bool follow;

    private int step;

    private int curRot;
    private bool facingRight;
    private bool leave;


    // Use this for initialization
    void Start()
    {
        droneSpeech.text = "";
        matildaSpeech.text = "";
        winText.text = "";
        curRot = 180;
        facingRight = false;
        StartCoroutine("conv");
    }

    // Update is called once per frame
    void Update ()
    {
        if (!facingRight)
        {
            StartCoroutine("conv");
            facingRight = true;
        }
        if(leave)
            moveTo(new Vector3(transform.position.x, 30, transform.position.z));

        if(player.GetComponent<control>().points == 3)
        {
            winText.text = "Player Wins!";
            player.GetComponent<control>().gameMode = 1;
            enemy.GetComponent<basicAI>().gameMode = 1;
            Invoke("endTheGame", 5.0f);
            //players wins
        }
        else if(enemy.GetComponent<basicAI>().points == 3)
        {
            winText.text = "You Lose!";
            player.GetComponent<control>().gameMode = 1;
            enemy.GetComponent<basicAI>().gameMode = 1;
            Invoke("endTheGame", 5.0f);
            //enemy wins
        }
    }

    private IEnumerator conv()
    {
        player.GetComponent<control>().gameMode = 1;
        enemy.GetComponent<basicAI>().gameMode = 1;
        //player.GetComponent<control>().anim.SetBool("run", false);
        droneSpeech.text = "";
        matildaSpeech.text = "What is this place?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "This is one of the arenas setup for the tournament.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "This is your first fight.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "Fight?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "You never said anything about fighting!";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "What better test of a Piñata is there?";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...I don't know about this.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "I'm afraid you don't get a choice.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "And you're opponent might not be feeling as remorseful.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Remember everything you learned upstairs.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Good luck!";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        leave = true;
        droneSpeech.text = "";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "..Well, here goes, I guess.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<control>().gameMode = 0;
        enemy.GetComponent<basicAI>().gameMode = 0;
        follow = true;
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }

    private void moveTo(Vector3 target)
    {
        transform.parent.position = Vector3.SmoothDamp(transform.parent.position, target, ref vel, damping);
    }

    private void endTheGame()
    {
        Application.Quit();
    }
}
