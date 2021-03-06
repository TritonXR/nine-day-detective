using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRSimpleJSON;
using OVRTouchSample;
using UnityEngine.SceneManagement;

public class KeyHighlightable : MonoBehaviour
{
	// Variables for game logic
	const string CORRECT = "4190"; 
	// The current combination
	public string current;
    Color[] histcolor;

	// Communicates when the correct code is inputted 
	public bool CodeSolved; 

	public Highlightable[] triggers;
    public bool finished = false;
    public float timer = 0;
    float DELAY = 1.2f;
    float BLINK = .2f;

	void Start() 
	{
		current = "";
		CodeSolved = false;
        histcolor = new Color[4];
        histcolor[0] = Color.red;
        histcolor[1] = Color.green;
        histcolor[2] = Color.yellow;
        histcolor[3] = Color.blue;
    }

    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        if ((Input.GetKeyDown(Constants.interactionKey) || OVRInut.GetDown(Constants.interactionButton)) & !finished)
        {
            Debug.Log("button pressed");
            // Get buttons pressed 
            for (int i = 0; i < triggers.Length; i++)
            {
                if (triggers[i].highlighted)
                {
                    if (i < 10)
                    {
                        current += i;
                    }
                    else
                    {
                        current = current.Substring(0, current.Length - 1);
                    }
                }
            }

            //Debug.Log("Current");
            // Compare current
            if (current.Length == 4)
            {
                finished = true;
            }

            if (CodeSolved)
            {
                Debug.Log("CodeSolved!");
                SceneManager.LoadScene("EndScene");
            }
        }
        if (finished)
        {
            timer += Time.deltaTime;
        }
        if (timer >= DELAY)
        {
            finished = false;
            timer = 0;
            Clear();
        }

        for (int i = 0; i < triggers.Length; i++)
        {
            int num = current.LastIndexOf(i.ToString());
            //Debug.Log(this.histcolor[0]);
            Renderer rend = triggers[i].transform.parent.GetComponentInParent<Renderer>();
            if (num != -1)
            {
                rend.material.SetColor("_Color", histcolor[num]);
            }
            else
            {
                rend.material.SetColor("_Color", Color.white);
            }
            if(finished && timer > DELAY/2)
            {
                if((int)(timer / BLINK) % 2 == 0)
                {
                    rend.material.SetColor("_Color", Color.white);
                }
                else
                {
                    if (current.Equals(CORRECT))
                    {
                        rend.material.SetColor("_Color", Color.green);
                        SceneManager.LoadScene("End Scene");
                    } else
                    {
                        rend.material.SetColor("_Color", Color.red);
                    }
                }
            }
        }
    }

    void Clear()
    {
        current = "";
        if (current.Equals(CORRECT))
        {
            CodeSolved = true;
        }
    }

}
