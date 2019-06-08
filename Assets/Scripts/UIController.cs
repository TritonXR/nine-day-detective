using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RawImage popup;
    public RawImage album;
    public Highlightable target;
    float threshold = 10;
    public bool lookingAtBook = false;
    public bool bookOpen = false;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();

        // Door
        if ((target.transform.position - transform.position).magnitude < threshold)
        {
            // if ( OVRInut.GetDown(OVRInput.Button.One))
            if (target.highlighted && (Input.GetKeyDown(Constants.interactionKey) || OVRInut.GetDown(Constants.interactionButton)))
            {
                popup.gameObject.SetActive(!popup.gameObject.activeSelf);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                popup.gameObject.SetActive(false);
            }
        }
        else
        {
            popup.gameObject.SetActive(false);
        }
        // Book
        if ((GetComponentInParent<ReticleSelector>().KeyBook.transform.position - transform.position).magnitude < threshold)
        {
            if (lookingAtBook)
            {
                if (Input.GetKeyDown(Constants.interactionKey) || OVRInut.GetDown(Constants.interactionButton))
                {
                    bookOpen = !bookOpen;
                }
            }
            else
            {
                if (Input.GetKeyDown(Constants.interactionKey) || OVRInut.GetDown(Constants.interactionButton))
                {
                    bookOpen = false;
                }
            }
            album.gameObject.SetActive(bookOpen);
        }
        else
        {
            bookOpen = false;
            album.gameObject.SetActive(bookOpen);
        }
    

    }

}
