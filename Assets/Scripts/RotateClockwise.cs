using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateClockwise : MonoBehaviour
{
    public Highlightable trigger;
    public string colliderName;
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
        Debug.Log("in drawer2 script");
    }

    // Update is called once per frame
    void Update()
    {


        RaycastHit Drawer2Hit;
        Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(cursorRay, out Drawer2Hit, rayLength))
        {
            if (Drawer2Hit.collider.gameObject.name == "Drawer2Handle" && Drawer2Hit.collider.isTrigger)
            {
                Debug.Log("hitting Drawer2");
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    Debug.Log("Handle 2 was clicked");
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
                transform.Rotate(0, updateamt, 0, Space.Self);
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
                transform.Rotate(0, -updateamt, 0, Space.Self);
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
