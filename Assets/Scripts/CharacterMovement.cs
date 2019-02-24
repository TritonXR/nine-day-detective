using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRSimpleJSON;
using OVRTouchSample;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 10.0F;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        //float translation = Input.GetAxis("Vertical") * speed;
        //float straffe = Input.GetAxis("Horizontal") * speed;
        //translation *= Time.deltaTime;
        //straffe *= Time.deltaTime;

        //transform.Translate(straffe, 0, translation);

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("PressedOne");
        }

        


        Vector2 translation = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) * speed;
        translation *= Time.deltaTime;

        transform.position += new Vector3(translation.x, 0, translation.y);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
