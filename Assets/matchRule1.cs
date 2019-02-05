using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchRule1 : MonoBehaviour
{

    public GameObject player;
    public GameObject ai;
    public int scoreToWin;
    public s4c2 conv;

    private basicActions playerActions;
    private basicActions aiActions;
    private candyCollection playerCandy;
    private candyCollection aiCandy;

    // Use this for initialization
    void Start()
    {
        playerActions = player.GetComponent<basicActions>();
        aiActions = ai.GetComponent<basicActions>();

        playerCandy = player.GetComponent<candyCollection>();
        aiCandy = ai.GetComponent<candyCollection>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            player.GetComponent<basicActions>().points = 3;
        }
        if (playerActions.points == scoreToWin)
        {
            playerActions.gameMode = 1;
            aiActions.gameMode = 1;
            playerWin();
        }
        else if (aiActions.points == scoreToWin)
        {
            playerActions.gameMode = 1;
            aiActions.gameMode = 1;
            playerLose();
        }
    }

    private void playerWin()
    {
        conv.go = true;
    }

    private void playerLose()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
