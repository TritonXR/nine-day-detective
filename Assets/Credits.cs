using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public RawImage fadeImage;

    const float SCROLL_SPEED = 50; // Amount to scroll per second
    const float SCROLL_DIST = 1000; // Amount to scroll before stopping
    const float FADE_SPEED = .25f;

    float traveled = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(traveled < SCROLL_DIST) {
            traveled += SCROLL_SPEED * Time.deltaTime;
            transform.position = transform.position + new Vector3(0, SCROLL_SPEED * Time.deltaTime, 0);
        } else if(fadeImage.color.a < 1) {
            fadeImage.color = fadeImage.color + new Color(0f, 0f, 0f, FADE_SPEED * Time.deltaTime);
        } else
        {
            Application.Quit();
        }
    }
}
