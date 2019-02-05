using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typeWirter : MonoBehaviour {

    //With help from https://answers.unity.com/questions/676760/scrolling-typewriter-effect.html

    public float charPerSecond;
    public Text thisText;
    public float puncuationPause;

    private AudioSource typeNoise;
    private string shownText;
    private float timeElapsed;
    private float puncuationTime;
    private string fullText;
    private bool wait;
    private int count;
    private int prevLength;
    private float commaPause;

	// Use this for initialization
	void Start ()
    {
        timeElapsed = 0;
        puncuationTime = 0;
        wait = false;
        count = 0;
        commaPause = puncuationPause / 2f;
        typeNoise = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (fullText != null)
        {
            if (thisText.text.Length < fullText.Length)
            {


                if (wait == true && puncuationTime < puncuationPause)
                {
                    puncuationTime += Time.deltaTime;
                }
                else
                {
                    wait = false;
                    puncuationTime = 0;
                    timeElapsed += Time.deltaTime;
                }
                prevLength = thisText.text.Length;

                thisText.text = getChars(fullText, (int)(timeElapsed * charPerSecond));
                if (prevLength != thisText.text.Length)
                {
                    typeNoise.pitch = Random.Range(0.8f, 1.2f);
                    typeNoise.Play();
                }

                if (thisText.text != "")
                    if (thisText.text[thisText.text.Length - 1] == '.' || thisText.text[thisText.text.Length - 1] == '!' || thisText.text[thisText.text.Length - 1] == '?')
                    {
                        wait = true;
                        puncuationPause = commaPause * 2;
                    }
                    else if (thisText.text[thisText.text.Length - 1] == ',' || thisText.text[thisText.text.Length - 1] == '-')
                    {
                        wait = true;
                        puncuationPause = commaPause;
                    }
                if (thisText.text == fullText)
                    GetComponent<speech>().showAdvance = true;
                else
                    GetComponent<speech>().showAdvance = false;
            }
        }
    }

    public string getChars(string text, int charCount)
    {
        string outString = "";

        for (int i = 0; i < charCount - 1; i++)
        {
            outString += text[i];
        }
        return outString;
    }

    public void typeWrite(string text)
    {
        fullText = text;
        thisText.text = "";
        timeElapsed = 0;
    }
}
