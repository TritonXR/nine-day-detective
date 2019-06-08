using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecticleVR : MonoBehaviour
{
    public Camera camera;
    public GameObject KeyBook;
    public UIController controller;
    float rayLength = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        controller = GetComponentInChildren<UIController>();
    }

    Highlightable highlighted;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Debug.DrawLine(ray.origin, hit.point);
        }


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
            if (target != null)
            {
                target.Highlight();
                highlighted = target;

            }
            // Do something with the object that was hit by the raycast.
        }
        else if (highlighted != null)
        {
            highlighted.Deselect();
        }
    }
}
