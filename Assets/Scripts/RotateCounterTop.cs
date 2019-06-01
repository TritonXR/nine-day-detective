using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCounterTop : MonoBehaviour
{
    public Highlightable trigger;
    public string counterName;
    public float angSpeed = 10.0f;
    private float maxOpen = 82.0f;
    private float maxClose = 0.0f;
    private float currentOpenAmt = 0f;
    private bool opening = false;
    private bool closing = false;
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
        OVRInput.Update();
        OVRInput.FixedUpdate();

        RaycastHit CounterHit;
        Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(cursorRay, out CounterHit, rayLength))
        {
            if (CounterHit.collider.gameObject.name == counterName && CounterHit.collider.isTrigger)
            {
                if (OVRInput.Get(OVRInput.Button.One))
                //if (Input.GetKeyDown(Constants.interactionKey))
                {
                    if (open == false)
                    {
                        opening = true;
                    }
                    else
                    {
                        closing = true;
                    }
                }
            }
        }

        float updateamt = angSpeed; //* Time.deltaTime;
        if (opening)
        {
            if (currentOpenAmt < maxOpen)
            {
                transform.Rotate(updateamt, 0, 0, Space.Self);
                currentOpenAmt += updateamt;
            }
            else
            {
                opening = false;
                open = true;
            }
        }

        if (closing)
        {
            if (currentOpenAmt > maxClose)
            {
                transform.Rotate(-updateamt, 0, 0, Space.Self);
                currentOpenAmt -= updateamt;
            }
            else
            {
                closing = false;
                open = false;
            }
        }
    }

    public void Open()
    {
        opening = true;
    }

    public void Close()
    {
        opening = false;
    }
}
