using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ccpScript : MonoBehaviour {

    public int candy;
    public List<GameObject> actors;
    public Text ccpText;
    public int maxCandy;

    private int rate;
    public bool makeCandy;

	// Use this for initialization
	void Start ()
    {
        rate = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (makeCandy && candy < maxCandy)
        {
            rate++;
            if (rate == 10)
            {
                candy++;
                rate = 0;
            }
        }
        ccpText.text = candy.ToString();
	}

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player" || hit.gameObject.tag == "ai")
        {
            hit.GetComponent<candyCollection>().onCpp = true;
            if(!actors.Contains(hit.gameObject))
                actors.Add(hit.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        actors.Remove(collision.gameObject);
    }
}
