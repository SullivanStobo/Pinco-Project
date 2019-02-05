using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour {

    public Text candyUI;
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        candyUI.text = "Candy: ";
	}
	
	// Update is called once per frame
	void Update ()
    {
        candyUI.text = "Candy: " + player.GetComponent<candyCollection>().candy;
	}
}
