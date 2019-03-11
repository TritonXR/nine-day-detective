using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public GameObject num4;
    public GameObject num5;
    public GameObject num6;
    public GameObject num7;
    public GameObject num8;
    public GameObject num9;
    public GameObject num0;
    public RaycastHit hit;
    public Ray ray;
    public string CorrectPass = "12345";
    public string input;
    public bool onTrigger;
    public bool doorOpen;
    public bool keypadScreen;
    public bool display = false;
    public Transform doorHinge;

    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name);
        }
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == num1)
            {
                input = input + "1";
            }
            if (hit.collider.gameObject == num2)
            {
                input = input + "2";
            }
            if (hit.collider.gameObject == num3)
            {
                input = input + "3";
            }
            if (hit.collider.gameObject == num4)
            {
                input = input + "4";
            }
            if (hit.collider.gameObject == num5)
            {
                input = input + "5";
            }
            if (hit.collider.gameObject == num6)
            {
                input = input + "6";
            }
            if (hit.collider.gameObject == num7)
            {
                input = input + "7";
            }
            if (hit.collider.gameObject == num8)
            {
                input = input + "8";
            }
            if (hit.collider.gameObject == num9)
            {
                input = input + "9";
            }
            if (hit.collider.gameObject == num0)
            {
                input = input + "0";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (input == CorrectPass)
        {
            doorOpen = true;
        }

        if (doorOpen)
        {
            var newRot = Quaternion.RotateTowards(doorHinge.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 250);
            doorHinge.rotation = newRot;
        }
        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name);
        }
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == num1)
            {
                input = input + "1";
                print(input);
            }
            if (hit.collider.gameObject == num2)
            {
                input = input + "2";
            }
            if (hit.collider.gameObject == num3)
            {
                input = input + "3";
            }
            if (hit.collider.gameObject == num4)
            {
                input = input + "4";
            }
            if (hit.collider.gameObject == num5)
            {
                input = input + "5";
            }
            if (hit.collider.gameObject == num6)
            {
                input = input + "6";
            }
            if (hit.collider.gameObject == num7)
            {
                input = input + "7";
            }
            if (hit.collider.gameObject == num8)
            {
                input = input + "8";
            }
            if (hit.collider.gameObject == num9)
            {
                input = input + "9";
            }
            if (hit.collider.gameObject == num0)
            {
                input = input + "0";
            }
        }
    }
}
