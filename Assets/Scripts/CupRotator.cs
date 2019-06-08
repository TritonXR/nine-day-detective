using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupRotator : MonoBehaviour
{
    public string colliderName;
    private bool cursorHits = false;
    private bool cupFlipped = false;
    float speed = -0.01f;

    public Camera camera;

    //variables for casting the ray
    float rayLength = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();

        if (OVRInut.GetDown(Constants.interactionButton))
        {
            Debug.Log("Getting Feedback");
        }
        RaycastHit hit;
        //Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        Ray cursorRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//for VR use
        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            //Debug.Log("in cup flip");
            if (hit.collider.gameObject.name == colliderName && hit.collider.isTrigger)
            {
                Debug.Log("middle if reached");
                if (Input.GetKeyDown(Constants.interactionKey) || OVRInut.GetDown(Constants.interactionButton))
                {
                    Debug.Log("cup pressed");
                    cursorHits = true;
                }
            }
        }

        if (cursorHits && !cupFlipped)
        {
            transform.Rotate(new Vector3(transform.localPosition.x, 0), 180f);
            cupFlipped = true;
            cursorHits = false;
        }
        
        if (cursorHits && cupFlipped)
        {
            transform.Rotate(new Vector3(transform.localPosition.x, 0), -180f);
            cupFlipped = false;
            cursorHits = false;
        }
    }
}
