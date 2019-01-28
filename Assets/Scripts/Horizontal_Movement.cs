using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horizontal_Movement : MonoBehaviour {

    public float xPosition;
    public float yPosition;
    public float zPosition;
    float speed = 0.01f;

    public Camera camera;

    //variables for casting the ray
    float rayLength = 3.0f;

	// Use this for initialization
	void Start () {

        camera = GetComponent<Camera>();
		
    }
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Ray cursorRay = camera.ScreenPointToRay(new Vector3(Screen.width / 2f,
                                                 Screen.height / 2f, 0));
        if (Physics.Raycast(cursorRay, out hit, rayLength))
        {
            if (hit.collider.tag == "Drawer3Handle")
            {
                OpenDrawer();
            }
        }

	}

    private void OpenDrawer ()
    {
        if (xPosition > -5.0f)
        {
            transform.Translate(-speed, 0, 0);
            xPosition -= speed;
        }
    }
}
