using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    bool finished = false;
    float timer = 0;
    float DELAY = .5f;

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
        if (Input.GetKeyDown(KeyCode.Space))
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

            for (int i = 0; i < triggers.Length; i++)
            {
                int num = current.IndexOf(i.ToString());
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
            }

            // Compare current
            if (current.Length == 4)
            {
                finished = true;
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

            // For testing
            Debug.Log("inputted code is: " + current);
            if (CodeSolved)
            {
                Debug.Log("CodeSolved!");
            }
        }
    }

    void Clear()
    {
        if (current.Equals(CORRECT))
        {
            CodeSolved = true;
        }
        else
        {
            // Reset current
            current = "";
        }
    }

}
