using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Highlightable trigger;
    public float openang = .8f;
    public float closeang = 0f;
    private float openlength = .1f;
    private bool open = false;

    public Camera camera;

    //variables for casting the ray
    float rayLength = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(trigger.highlighted)
        {
            Open();
        } else
        {
            Close();
        }
        */

        RaycastHit DrawerHit;
        Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(cursorRay, out DrawerHit, rayLength))
        {
            Debug.Log("hitting Drawer2");
            if (DrawerHit.collider.gameObject.name == "Drawer2Handle" && DrawerHit.collider.isTrigger)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Debug.Log("Handle was clicked");
                    open = true;
                }
            }
        }

        float updateamt = (openang - closeang) / openlength * Time.deltaTime;
        if (open)
        {
            if (transform.rotation.y < openang)
            {
                transform.Rotate(0, updateamt, 0, Space.Self);
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
