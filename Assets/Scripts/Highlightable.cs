﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlightable : MonoBehaviour {
    public bool highlighted;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void OnVREnter() {
        GetComponent<Renderer>().enabled = true;
        //Debug.Log(GetComponent<Renderer>());
        highlighted = true;
    }

    public void OnVRExit() {
        GetComponent<Renderer>().enabled = false;
        highlighted = false;
    }

    public void Highlight()
    {
        GetComponent<Renderer>().enabled = true;
        //Debug.Log(GetComponent<Renderer>());
        highlighted = true;
    }

    public void Deselect()
    {
        GetComponent<Renderer>().enabled = false;
        highlighted = false;
    }
}
