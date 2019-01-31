using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    public RawImage popup;
    public GameObject target;
    float threshold = 10;
    public bool lookingAtBook = false;
    public bool bookOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Door
        if((target.transform.position - transform.position).magnitude < threshold) {
            popup.gameObject.SetActive(true);
        } else {
            popup.gameObject.SetActive(false);
        }
        // Book
        if ((GetComponentInParent<ReticleSelector>().KeyBook.transform.position - transform.position).magnitude < threshold)
        {
            if (lookingAtBook)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    bookOpen = !bookOpen;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    bookOpen = false;
                }
            }
            popup.gameObject.SetActive(bookOpen);
        }
	}

}
