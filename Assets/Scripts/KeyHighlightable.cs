using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHighlightable : MonoBehaviour
{
	// Variables for game logic
	const string CORRECT = "4190"; 
	// The current combination
	string current;  

	// Communicates when the correct code is inputted 
	public bool CodeSolved; 

	public Highlightable[] triggers;

	void Start() 
	{
		current = "";
		CodeSolved = false;
	}

	void Update() 
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("button pressed");
            // Get buttons pressed
            if (triggers[0].highlighted == true)
            {
                current += "1";
            }
            if (triggers[1].highlighted == true)
            {
                current += "2";
            }
            if (triggers[2].highlighted == true)
            {
                current += "3";
            }
            if (triggers[3].highlighted == true)
            {
                current += "4";
            }
            if (triggers[4].highlighted == true)
            {
                current += "5";
            }
            if (triggers[5].highlighted == true)
            {
                current += "6";
            }
            if (triggers[6].highlighted == true)
            {
                current += "7";
            }
            if (triggers[7].highlighted == true)
            {
                current += "8";
            }
            if (triggers[8].highlighted == true)
            {
                current += "9";
            }
            if (triggers[9].highlighted == true)
            {
                current += "0";
            }
        }

        // Compare current
        if (current.Length == 4) {
			if (current.Equals(CORRECT)) {
				CodeSolved = true;
			} else {
				// Reset current
				current = "";
			}
		}
		
		// For testing
		Debug.Log("inputted code is: " + current);
		if (CodeSolved) {
			Debug.Log("CodeSolved!");
		}
	}

   




}
