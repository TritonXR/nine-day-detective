using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {
    Vector3 origPos;
    Transform player;

	// Use this for initialization
	void Start () {
        origPos = transform.position;
        player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void attach() {
        transform.parent = player;
        transform.localPosition = new Vector3(0, 0, .5f);
        //GetComponentInChildren<BoxCollider>().enabled = false;
    }

    public void detach()
    {
        transform.parent = null;
        transform.localPosition = origPos;
        //GetComponentInChildren<BoxCollider>().enabled = true;
    }
}
