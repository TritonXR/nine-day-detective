using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleSelector : MonoBehaviour {
    public Camera camera;
    public GameObject KeyBook;
    public UIController controller;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        controller = GetComponentInChildren<UIController>();
	}

    Transform highlighted;
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.transform);
            if(hit.transform.GetComponent<Renderer>() != null) {
                if(hit.transform != highlighted) {
                    if(highlighted != null) {
                        if (highlighted.parent == KeyBook.transform)
                        {
                            foreach (Material m in KeyBook.GetComponent<Renderer>().materials)
                            {
                                m.color = Color.white;
                                controller.lookingAtBook = false;
                            }
                        }
                    }
                    if (hit.transform.parent == KeyBook.transform)
                    {
                        foreach (Material m in KeyBook.GetComponent<Renderer>().materials) {
                            m.color = Color.black; 
                            controller.lookingAtBook = true;
                            controller.bookOpen = false;
                        }
                    }
                    highlighted = hit.transform;
                } 
            }

            // Do something with the object that was hit by the raycast.
        }        
	}
}
