using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRenderer : MonoBehaviour
{
    public Renderer rend;
    public string keyColliderName;
    private bool keyClicked = false;
    float rayLength = 10.0f;
    public Camera camera;

    void Start()
    {
        rend.enabled = true;
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        RaycastHit hit;
        //Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        Ray cursorRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//for VR use

        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            if (hit.collider.gameObject.name == keyColliderName && hit.collider.isTrigger)
            {
                Debug.Log("you have hit the key");
                if (Input.GetKeyDown(Constants.interactionKey) || OVRInput.Get(Constants.interactionButton))
                {
                    Debug.Log("You have obtained the key");
                    keyClicked = true; 
                }
            }
        }
        // Find out whether current second is odd or even


        // Enable renderer accordingly
        rend.enabled = !keyClicked;
    }
}