using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class drone : MonoBehaviour {

    public Text droneSpeech;
    public Text matildaSpeech;
    public GameObject cam;
    public GameObject player;
    public int gameMode;

    private Vector3 vel;
    public Vector3 target;
    public float damping;

    public bool follow;
    public bool facePlayer;

    private int step;

    private int curRot;
    private bool facingRight;

    //private bool[] steps;

	// Use this for initialization
	void Start ()
    {
        droneSpeech.text = "";
        matildaSpeech.text = "";
        curRot = 180;
        facingRight = false;
        //steps = new bool[8];
        gameMode = 0;
        target = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        /*
        step = cam.GetComponent<sceneOneCamera>().step;
        
        if(step == 0 && !steps[0])
        {
            StartCoroutine("conv1");
            steps[0] = true;
        }
        else if(step == 2 && !steps[1])
        {
            StartCoroutine("conv2");
            steps[1] = true;
        }
        else if(step == 4 && !steps[2])
        {
            StartCoroutine("conv3");
            steps[2] = true;
        }
        else if(step == 6 && !steps[3])
        {
            StartCoroutine("conv4");
            steps[3] = true;
        }
        else if (step == 8 && !steps[4])
        {
            StartCoroutine("conv5");
            steps[4] = true;
        }
        else if (step == 9 && !steps[5])
        {
            StartCoroutine("conv6");
            steps[5] = true;
        }
        else if (step == 10 && !steps[6])
        {
            StartCoroutine("conv7");
            steps[6] = true;
        }
        else if (step == 11 && !steps[7])
        {
            StartCoroutine("conv8");
            steps[7] = true;
        }
        */

        //Drone is moving around
        if(gameMode == 0)
        {
            //Following player (and facing them)
            if (follow)
            {
                if (player.transform.position.x > transform.position.x)
                {
                    facingRight = true;
                    target = new Vector3(player.transform.position.x - 1f, player.transform.position.y + 0.75f, player.transform.position.z);
                }
                else
                {
                    facingRight = false;
                    target = new Vector3(player.transform.position.x + 1f, player.transform.position.y + 0.75f, player.transform.position.z);
                }

            }

            //Not following but still facing
            if(facePlayer)
            {
                if (player.transform.position.x > transform.position.x)
                {
                    facingRight = true;
                }
                else
                {
                    facingRight = false;
                }
            }
            //Not facing
            else
            {
                if (player.transform.position.x > transform.position.x)
                {
                    facingRight = false;
                }
                else
                {
                    facingRight = true;
                }
            }

            //Update direction
            if (facingRight && curRot != 0 || !facingRight && curRot != 180)
            {
                transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                if (facingRight)
                    curRot = 0;
                else
                    curRot = 180;
            }

            //Update position
            moveTo(target);
        }

        /*
        if (follow)
        {

            if (player.transform.position.x > transform.position.x)
            {
                facingRight = true;
                moveTo(new Vector3(player.transform.position.x - 1f, player.transform.position.y + 0.75f, player.transform.position.z));
            }
            else
            {
                facingRight = false;
                moveTo(new Vector3(player.transform.position.x + 1f, player.transform.position.y + 0.75f, player.transform.position.z));
            }

            if (facingRight && curRot != 0 || !facingRight && curRot != 180)
            {
                transform.Rotate(new Vector3(transform.rotation.x, 180, transform.rotation.z));
                if (facingRight)
                    curRot = 0;
                else
                    curRot = 180;
            }
            if (step == 2 && !steps[1] || step == 4 && !steps[2])
                follow = false;
        }
        */
    }

    private IEnumerator conv1()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        follow = false;
        droneSpeech.text = "-Press space to advance text-";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Unbelieveable";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "His machine actually worked.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "Wow.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "That's great!";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "...";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...I have no idea what you're talking about.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "I assumed.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "You are a Piñata made by Piñco™.  You were brought to life in order to compete in a tournament to see which Piñco™ design is the best.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...Sounds like fun?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "That is the spirit.  Please proceed to the right.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private IEnumerator conv2()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        int count = 0;
        while (count < 1000)
        {
            if(count % 10 == 0)
                moveTo(new Vector3(-10, 1, 0));
            count++;
        }
        count = 0;
        while(count > 10000)
        { count++; }
        droneSpeech.text = "";
        matildaSpeech.text = "Quite the drop.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "This area of the Piñco™ factory is currently under construction.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Please use the platforms above you to climb over the gap.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "How am I supposed to get up there?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "...Jump.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...Can Piñatas jump?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Quite well, in fact.  To jump press the 'up' key.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "Alright.  I'll give it a try.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private IEnumerator conv3()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        droneSpeech.text = "";
        matildaSpeech.text = "What's that big machine there?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "That's a Candy Collection Point™, or CCP.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Candy comes down that large pipe and collects in the box in the middle.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "What's it for?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "It is part of the tournament I mentioned earlier.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Try pressing 'X' while near it.  Let me know when you have 50 candy.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "Ok!";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private IEnumerator conv4()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        droneSpeech.text = "";
        matildaSpeech.text = "Alright, I have 50 candy.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "Now what?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Well, in order to score a point in the tournament, you need to bring a certain amount of candy to the Candy Delivery Point™, like the one up there.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "It looks like that one need 100 candy.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "But I only have 50!";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "See if you can beat another 50 candy out of that dummy down there.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...Beat candy out of a dummy?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "...";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Just try it.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private IEnumerator conv5()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        droneSpeech.text = "";
        matildaSpeech.text = "...Do I really have to hit it?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "It's just a dummy.  It doesn't feel anything.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...I guess.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Press 'Z' to swing the bat you've been carrying around.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "You'll automatically collect any candy that comes out of the dummy.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private IEnumerator conv6()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        droneSpeech.text = "";
        matildaSpeech.text = "...Alright.  I got 50 more candy.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Perfect.  Now deliver it to the Candy Delivery Point™, or CDP, above us.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
            yield return null;
        yield return new WaitForFixedUpdate();
    }

    private IEnumerator conv7()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        player.GetComponent<basicActions>().anim.SetBool("jump", false);
        player.GetComponent<basicActions>().anim.SetBool("fall", false);
        droneSpeech.text = "";
        matildaSpeech.text = "Thats a pretty spooky looking machine.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "Whats the giant bat for?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "For destorying Piñatas who have managed to collect enough candy.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "What!?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Being destroyed is the point of Piñatas.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "This is also how you score points in the tournament.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "But what good are points if I'm in a thousand pieces!?";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Oh, do not worry about that.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "The same machine that brought you to life will do so with another Piñata that is the same model as you.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "You'll keep all your memories.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "I'm also told it's completely painless.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...This is nuts.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "...";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "...";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "...Fine, fine.  I'm going.";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Have fun!";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private IEnumerator conv8()
    {
        player.GetComponent<basicActions>().gameMode = 1;
        player.GetComponent<basicActions>().anim.SetBool("run", false);
        droneSpeech.text = "";
        matildaSpeech.text = "That was...";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "...";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "AWESOME!";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "Glad to hear it.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "When you are ready, we can continue down the elevator to the right.";
        matildaSpeech.text = "";
        yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
        droneSpeech.text = "";
        matildaSpeech.text = "";
        player.GetComponent<basicActions>().gameMode = 0;
        follow = true;
    }

    private void moveTo(Vector3 target)
    {
        transform.parent.position = Vector3.SmoothDamp(transform.parent.position, target, ref vel, damping);
    }
}
