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

    Highlightable highlighted;
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
            Highlightable target = hit.transform.GetComponent<Highlightable>();
            if (target != highlighted)
            {
                if (highlighted != null)
                {
                    highlighted.Deselect();
                    if (highlighted.transform.parent == KeyBook.transform)
                    {
                        controller.lookingAtBook = false;
                    }
                }
            }
            if (hit.transform.parent == KeyBook.transform)
            {
                controller.lookingAtBook = true;
            }
            if(target != null)
            {
                target.Highlight();
                highlighted = target;
          
            }
            // Do something with the object that was hit by the raycast.
        }
        else if (highlighted != null) {
            highlighted.Deselect();
        }
	}
}
