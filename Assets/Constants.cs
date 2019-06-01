using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {
    
    //public static OVRInput interactionKey = OVRInput.Button.One;
    //Debug.Log(OVRInput.Button.One.GetType());
    public static bool interactionKey = OVRInput.Get(OVRInput.Button.One);

    public void Start()
    {
    }

    public void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        interactionKey = OVRInput.Get(OVRInput.Button.One);
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("Button pressed");
        }
    }
}
