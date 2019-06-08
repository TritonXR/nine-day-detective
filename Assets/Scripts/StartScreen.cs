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
    float waittime = 100f;
    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        //Input.GetKeyDown(Constants.interactionKey
        if (Input.GetKeyDown(Constants.interactionKey) || OVRInput.Get(Constants.interactionButton)||waittime == 0)
        {
            SceneManager.LoadScene("SampleSceneVR");
        }
        waittime--;
    }
}
