using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Vector2 translation = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick) * speed;
        translation *= Time.deltaTime;

        transform.position += new Vector3(translation.x, translation.y, 0);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }
}
