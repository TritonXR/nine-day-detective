using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Highlight() {
        GetComponent<Renderer>().enabled = true;
        Debug.Log(GetComponent<Renderer>());
    }

    public void Deselect() {
        GetComponent<Renderer>().enabled = false;
    }
}
