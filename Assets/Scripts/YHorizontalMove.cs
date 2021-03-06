﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YHorizontalMove : MonoBehaviour
{

    public float yPosition;
    public string handleName;
    private bool cursorHits = false;
    private bool drawerIsOpen = false;
    public float stop = 2.1f;
    float speed = -0.065f;

    public Camera camera;

    //variables for casting the ray
    float rayLength = 10.0f;

    // Use this for initialization
    void Start()
    {

        //Debug.Log("It is starting");
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();

        RaycastHit hit;
        //Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
        Ray cursorRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));//for VR use

        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            //Debug.Log("moving code is running");
            if (hit.collider.gameObject.name == handleName && hit.collider.isTrigger)
            {
                if (Input.GetKeyDown(Constants.interactionKey) || OVRInput.Get(Constants.interactionButton))
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

            if (yPosition > -2.0f)
            {

  
                transform.Translate(speed, 0, 0 );
                yPosition += speed;

            }
            else
            {

                cursorHits = false;
                drawerIsOpen = true;
            }
        }
    }

    private void CloseDrawer()
    {
        if (cursorHits == true)
        {

            if (yPosition < stop)
            {
                transform.Translate(-speed, 0, 0);
                yPosition -= speed;
            }
            else
            {
                drawerIsOpen = false;
                cursorHits = false;
            }
        }
    }
}