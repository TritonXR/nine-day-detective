using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        //Input.GetKeyDown(Constants.interactionKey
        if ( OVRInput.Get(OVRInput.Button.One) )
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
