using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVRSimpleJSON;
using OVRTouchSample;

public class KeyHighlightable : MonoBehaviour
{
	// Variables for game logic
	const string CORRECT = "4190"; 
	// The current combination
	string current;
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
        histcolor[1] = Color.yellow;
        histcolor[2] = Color.blue;
        histcolor[3] = Color.magenta;
    }

    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        if ((Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.One)) && !finished)
        {
            Debug.Log("button pressed");
            // Get buttons pressed 
            for (int i = 0; i < triggers.Length; i++)
            {
                if (triggers[i].highlighted)
                {
                    current += i;
                }

            }
            Debug.Log("Current");
            // Compare current
            if (current.Length == 4)
            {
                finished = true;
            }

            if (CodeSolved)
            {
                Debug.Log("CodeSolved!");
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
            Debug.Log(this.histcolor[0]);
            Renderer rend = triggers[i].transform.parent.GetComponentInParent<Renderer>();
            if (num != -1)
            {
                rend.material.SetColor("_Color", histcolor[num]);
            }
            else
            {
                rend.material.SetColor("_Color", Color.white);
            }
            if(finished)
            {
                if((int)(timer / BLINK) % 2 == 0)
                {
                    rend.material.SetColor("_Color", Color.white);
                } else
                {
                    if (current.Equals(CORRECT))
                    {
                        rend.material.SetColor("_Color", Color.green);
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
