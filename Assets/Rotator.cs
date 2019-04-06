﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Highlightable trigger;
    public float openang = .8f;
    public float closeang = 0f;
    private float openlength = .4f;
    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.highlighted)
        {
            Open();
        } else
        {
            Close();
        }
        float updateamt = (openang - closeang) / openlength * Time.deltaTime;
        if (open)
        {
            if (transform.rotation.y < openang)
            {
                transform.Rotate(0, updateamt, 0);
            }
            if (transform.rotation.y >= openang)
            {
                transform.rotation = new Quaternion(0, openang, 0, 0);
            }
        }
        else
        {
            if (transform.rotation.y > closeang)
            {
                transform.Rotate(0, -1*updateamt, 0);
            }
            if (transform.rotation.y <= closeang)
            {
                transform.rotation = new Quaternion(0, closeang, 0, 0);
            }
        }
    }

    public void Open()
    {
        open = true;
    }

    public void Close()
    {
        open = false;
    }
}
