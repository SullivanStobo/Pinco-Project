using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matchAI : MonoBehaviour {

    public navNode start;
    public GameObject player;
    public GameObject CDP;
    public bool takeJumps;

    private basicActions actions;
    private Vector3 playerpos;
    private int candy;
    public bool routeFound;
    private navNode currentNode;
    private navNode nextNode;
    private navNode temp;
    private Queue<navNode> route;
    private Vector3 myPos;
    private bool goingToScore;

	// Use this for initialization
	void Start ()
    {
        actions = GetComponent<basicActions>();
        routeFound = false;
        currentNode = start;
        route = new Queue<navNode>();
        candy = 0;
        goingToScore = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Decision making

        playerpos = player.transform.position;
        myPos = transform.position;
        candy = GetComponent<candyCollection>().candy;

        if (actions.gameMode == 0)
        {

            if (Mathf.Abs(playerpos.x - transform.position.x) < 2 && Mathf.Abs(playerpos.y - transform.position.y) < 0.5)
            {
                print("Raaaa!");
                //ATTACK
                if (actions.curRot == player.GetComponent<basicActions>().curRot)
                {
                    if (actions.facingRight)
                        actions.facingRight = false;
                    else
                        actions.facingRight = true;
                }
                actions.HAttack = true;
                actions.jump = false;
                actions.move = 0;
            }
            //Not enough candy, look for ccp
            else if (candy < CDP.GetComponent<cdpScript>().acceptedAmount)
            {
                if(goingToScore)
                {
                    reset();
                    goingToScore = false;
                    currentNode = GameObject.FindGameObjectWithTag("node").GetComponent<navNode>();
                }
                actions.HAttack = false;
                if (currentNode.tag == "ccpNode")
                {
                    if (currentNode.transform.position.x - 1 < myPos.x && myPos.x < currentNode.transform.position.x + 1)
                    {
                        actions.isCollecting = true;
                        actions.move = 0;
                    }
                    else if (myPos.x < currentNode.transform.position.x)
                        actions.move = 1;
                    else if (myPos.x > currentNode.transform.position.x)
                        actions.move = -1;
                    routeFound = false;
                }
                else
                {
                    temp = currentNode;
                    while (!routeFound)
                    {
                        if (temp.next.gameObject.tag == "ccpNode")
                        {
                            routeFound = true;
                            route.Enqueue(temp.next);
                        }
                        else if (temp.previous.gameObject.tag == "ccpNode")
                        {
                            routeFound = true;
                            route.Enqueue(temp.previous);
                        }
                        else
                        {
                            route.Enqueue(temp);
                            temp = temp.next;
                        }
                    }
                }
            }
            //Have enough candy to score
            else
            {
                goingToScore = true;
                actions.HAttack = false;
                temp = currentNode;
                actions.isCollecting = false;
                if (!routeFound)
                {
                    while (!routeFound)
                    {
                        if (temp.next.gameObject.tag == "cdpNode")
                        {
                            routeFound = true;
                            route.Enqueue(temp.next);
                        }
                        else if (temp.previous.gameObject.tag == "cdpNode")
                        {
                            routeFound = true;
                            route.Enqueue(temp.previous);
                        }
                        else
                        {
                            route.Enqueue(temp.next);
                            temp = temp.next;
                        }
                    }
                }
            }
        }

        //Execute route
        if(route.Count != 0)
            moveToNode(route.Peek(), currentNode);


        /*
        if (Mathf.Abs(playerpos.x - transform.position.x) < 2 && Mathf.Abs(playerpos.y - transform.position.y) < 0.5)
        {
            //ATTACK
            if (curRot == player.GetComponent<basicActions>().curRot)
            {
                if (facingRight)
                    facingRight = false;
                else
                    facingRight = true;
            }
            attack = true;
            jump = false;
            moveLeft = false;
            moveRight = false;

        }
        
        
        //Doesnt have enough candy to score
        if (GetComponent<candyCollection>().candy < CDP.GetComponent<cdpScript>().acceptedAmount)
        {
            attack = false;

            if (Mathf.Abs(CCPpos.x - transform.position.x) > 0.1 && Mathf.Abs(CCPpos.y - transform.position.y) > 0.5)
            {
                jump = false;
                isCollecting = false;
                if (CCPpos.x > transform.position.x)
                {
                    moveRight = true;
                    moveLeft = false;
                }
                else
                {
                    moveRight = false;
                    moveLeft = true;
                }
            }
            else
            {
                moveRight = false;
                moveLeft = false;
                isCollecting = true;
            }
        }
        //Has enough
        else
        {
            attack = false;
            if (Mathf.Abs(CDPpos.y - transform.position.y) > 2)
            {
                moveRight = true;
                moveLeft = false;
                jump = true;
            }
            else if (Mathf.Abs(CDPpos.x - transform.position.x) > 0.2 && Mathf.Abs(CDPpos.y - transform.position.y) > 0.5)
            {
                isCollecting = false;
                if (CCPpos.x > transform.position.x)
                {
                    moveRight = true;
                    moveLeft = false;
                }
                else
                {
                    moveRight = false;
                    moveLeft = true;
                }
                
            }
        }
        */
    }

    private void moveToNode(navNode node, navNode previous)
    {
        string action = "";

        if(previous.next == node)
            action = previous.transitionToNext;
        else if(previous.previous == node)
            action = previous.transitionPrevious;

        //print(node.name + previous.name + action);

        if (action == "jump")
            takeJumps = true;
        else if (action == "run")
            takeJumps = false;

        if (node.transform.position.x - 1 < myPos.x && myPos.x < node.transform.position.x + 1 && node.transform.position.y - 1 < myPos.y && myPos.y < node.transform.position.y + 1)
        {
            print("bop");
            actions.move = 0;
            currentNode = route.Dequeue();
        }
        else if (myPos.x < node.transform.position.x)
            actions.move = 1;
        else if (myPos.x > node.transform.position.x)
            actions.move = -1;
        
    }

    public void reset()
    {
        routeFound = false;
        currentNode = start;
        route = new Queue<navNode>();
        candy = 0;
    }
}
