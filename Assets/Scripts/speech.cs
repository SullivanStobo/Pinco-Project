using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speech : MonoBehaviour {

    public GameObject speechBoxTop;
    public GameObject speechBoxBody;
    public GameObject speechBoxBottom;
    public Canvas parentCanvas;
    public int flipped;
    public string labeledname;
    public bool showAdvance;

    private Text thisText;
    private Text nameLabel;
    private Text advanceNote;
    private GameObject bottom;
    private List<GameObject> body;
    private GameObject top;
    private GameObject temp;
    private int curRot;

    private int bodyCount;

    // Use this for initialization
    void Start()
    {
        bottom = Instantiate(speechBoxBottom, transform.parent.position, Quaternion.identity, transform.parent) as GameObject;
        top = Instantiate(speechBoxTop, transform.parent.position, Quaternion.identity, transform.parent) as GameObject;

        move(bottom, -1, 0.5f);
        move(top, -1, 0.75f);

        thisText = GetComponent<Text>();

        body = new List<GameObject>();
        bodyCount = 0;

        flipped = 1;

        thisText.text = "";

        nameLabel = top.transform.GetChild(0).GetComponentInChildren<Text>();
        advanceNote = bottom.transform.GetChild(0).GetComponentInChildren<Text>();

        labeledname = "";
        showAdvance = false;
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        if(transform.root.tag == "Player" || transform.root.tag == "ai")
            //Flipping
            if (transform.root.GetComponent<basicActions>().facingRight && curRot != 0 || !transform.root.GetComponent<basicActions>().facingRight && curRot != 180)
            {
                transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                nameLabel.transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                advanceNote.transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                if (transform.root.GetComponent<basicActions>().facingRight)
                    curRot = 0;
                else
                    curRot = 180;
                if (thisText.tag != "rustyText")
                {
                    if (flipped == 1)
                    {
                        flipped = -1;
                        thisText.transform.position = new Vector3(thisText.transform.parent.position.x + 1, thisText.transform.parent.position.y + 2.53f, thisText.transform.parent.position.z);
                    }
                    else
                    {
                        flipped = 1;
                        thisText.transform.position = new Vector3(thisText.transform.parent.position.x - 1, thisText.transform.parent.position.y + 2.53f, thisText.transform.parent.position.z);
                    }
                }
                else
                {
                    if (flipped == 1)
                    {
                        flipped = -1;
                        thisText.transform.position = new Vector3(thisText.transform.parent.position.x - 1, thisText.transform.parent.position.y + 2.53f, thisText.transform.parent.position.z);
                    }
                    else
                    {
                        flipped = 1;
                        thisText.transform.position = new Vector3(thisText.transform.parent.position.x + 1, thisText.transform.parent.position.y + 2.53f, thisText.transform.parent.position.z);
                    }
                }
            }

        if (thisText.text != "")
        {
            top.GetComponent<SpriteRenderer>().enabled = true;
            bottom.GetComponent<SpriteRenderer>().enabled = true;
            nameLabel.text = labeledname;

            if (bodyCount != getLines() - 1)
                if (bodyCount > getLines() - 1)
                {
                    Destroy(body[body.Count - 1]);
                    body.Remove(body[body.Count - 1]);
                    bodyCount--;
                }
                else
                {
                    while (bodyCount < getLines() - 1)
                    {
                        temp = Instantiate(speechBoxBody, transform.parent.position, Quaternion.identity, transform.parent) as GameObject;
                        move(temp, -1 * flipped, 0.75f + (bodyCount * 0.2f));
                        body.Add(temp);
                        bodyCount++;
                    }
                }
            move(top, -1 * flipped, 0.75f + (bodyCount * 0.2f));
            move(bottom , -1 * flipped, 0.5f);
        }
        else
        {
            while(bodyCount != 0)
            {
                Destroy(body[body.Count - 1]);
                body.Remove(body[body.Count - 1]);
                bodyCount--;
            }
            top.GetComponent<SpriteRenderer>().enabled = false;
            bottom.GetComponent<SpriteRenderer>().enabled = false;
            nameLabel.text = "";
            advanceNote.text = "";
            showAdvance = false;
        }
        if (showAdvance)
            advanceNote.text = "Press SPACE to advance text";
    }


    private int getLines()
    {
        return thisText.cachedTextGenerator.lines.Count;
    }

    private void move(GameObject obj, float x, float y)
    {
        obj.transform.position = new Vector3(transform.parent.position.x + x, transform.parent.position.y + y, transform.parent.position.z);
    }

    public void flip()
    {
        if (flipped == 1)
        {
            flipped = -1;
            thisText.transform.position = new Vector3(thisText.transform.parent.position.x + 1, thisText.transform.parent.position.y + 2.53f, thisText.transform.parent.position.z);
        }
        else
        {
            flipped = 1;
            thisText.transform.position = new Vector3(thisText.transform.parent.position.x - 1, thisText.transform.parent.position.y + 2.53f, thisText.transform.parent.position.z);
        }
        bottom.transform.Rotate(new Vector3(0, 180, 0));
        advanceNote.transform.Rotate(new Vector3(0, 180, 0));

    }

    public void setName(string newName)
    {
        labeledname = newName;
    }

}
