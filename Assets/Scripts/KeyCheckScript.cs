using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheckScript : MonoBehaviour
{
    public Renderer rend;
    public string colliderName;
    private bool keyClicked = false;
    float rayLength = 10.0f;
    public Camera camera;

    void Start()
    {
        Debug.Log("In KeyCheckScript");
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        RaycastHit hit;
        //Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        Ray cursorRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//for VR use

        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            if (hit.collider.gameObject.name == colliderName && hit.collider.isTrigger)
            {
                if (Input.GetKeyDown(Constants.interactionKey) || OVRInut.GetDown(Constants.interactionButton))
                {
                    Debug.Log("Box has been clicked");
                    if (!rend.enabled)
                    {
                        Debug.Log("Box has been opened because you have the key");
                    }
                    else
                    {
                        Debug.Log("Box cannot be opened because you don't have the key yet");
                    }
                }

            }
        }
        // Find out whether current second is odd or even


        
    }
}
