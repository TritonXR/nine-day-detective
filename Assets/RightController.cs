using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : MonoBehaviour
{
    LineRenderer laser;
    GameObject go = new GameObject();
    GameObject prev;
    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        laser.SetPosition(0, transform.position);
        laser.SetPosition(1, transform.position + transform.forward * 100);
        
        RaycastHit hit;
       // Debug.Log(go);
        if(prev != null)
        {
            prev.SendMessage("OnVRExit");
        }
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
       
            if (hit.collider != null)
            {
                
                //Debug.Log(hit.collider.gameObject);
                hit.collider.gameObject.SendMessage("OnVREnter");
                prev = hit.collider.gameObject;
                if (go != hit.collider.gameObject)
                {
                    go.transform.SendMessage("OnVRExit");
                    go = hit.transform.gameObject;
                    go.transform.SendMessage("OnVREnter");
                    Debug.Log("Enter");
                }
            }
        }
        else
        {
            Debug.Log("Hey");
            if (go != null)
            {
                go.transform.SendMessage("OnVRExit");
                go = new GameObject();
            }
        }
        //end of new stuff

    }
}
