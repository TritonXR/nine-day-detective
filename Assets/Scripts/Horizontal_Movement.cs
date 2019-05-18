using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Movement : MonoBehaviour
{

    public float xPosition;
    public string handleName;
    private bool cursorHits = false;
    private bool drawerIsOpen = false;
    float speed = -0.065f;

    public Camera camera;

    //variables for casting the ray
    float rayLength = 10.0f;

    // Use this for initialization
    void Start()
    {

        Debug.Log("It is starting");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            Debug.Log("moving code is running");
            if (hit.collider.gameObject.name == handleName && hit.collider.isTrigger)
            {
                if (Input.GetKeyDown(Constants.interactionKey))
                {
                    Debug.Log("Handle was clicked");
                    cursorHits = true;
                }
            }
        }

        if (drawerIsOpen)
        {
            CloseDrawer();
        }
        else
        {
            OpenDrawer();
        }
      


    }

    private void OpenDrawer()
    {
        if (cursorHits == true)
        {
            Debug.Log("in OpenDrawer");
            if (xPosition < 2.1f)
            {

                Debug.Log("opening");
                transform.Translate(speed, 0, 0);
                xPosition -= speed;

            }
            else
            {
                Debug.Log("stoops");
                cursorHits = false;
                drawerIsOpen = true;
            }
        }
    }

    private void CloseDrawer()
    {
        if (cursorHits == true)
        {
            Debug.Log("in CloseDrawer");
            if (xPosition > -0.915f)
            {
                Debug.Log("closing");
                transform.Translate(-speed, 0, 0);
                xPosition += speed;
            }
            else
            {
                drawerIsOpen = false;
                cursorHits = false;
            }
        }
    }
}