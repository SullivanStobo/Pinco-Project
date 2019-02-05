using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class cutsceneParser : MonoBehaviour {

    private string path;

	// Use this for initialization
	void Start ()
    {
        path = "Assets/Resources/" + this.gameObject.name + ".txt";
        StreamReader read = new StreamReader(path);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
