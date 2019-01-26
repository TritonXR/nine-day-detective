using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    float position = 0;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    Vector3 horizontalMovement;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-position, 0, 0);
        if (position < 0.01f)
        {
            position += 0.001f;
        }
    }
}
