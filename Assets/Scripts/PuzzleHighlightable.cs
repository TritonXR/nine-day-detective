using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PuzzleHighlightable : MonoBehaviour
{
	// Correct array - preset
	int[] correctArray = new int[9] { 0, 1, 2, 3, 4, 5, 6, 8, 7 };

	// Current array
	int[] currentArray = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
	// Empty tile - preset
	int emptyTile = 8;

	// Tiles  of the puzzle 
	public Highlightable[] tiles;
	bool finished = false;

    // Preset colors
    Color[] colors = new Color[9] {Color.red, Color.yellow, Color.green, Color.cyan,
        Color.blue, Color.magenta, Color.black, Color.grey, Color.white };

	// Start is called before the first frame update
	void Start()
	{
		// Set a color to each button
		for (int i = 0; i < tiles.Length; i++)
		{
			Renderer rend = tiles[i].transform.parent.GetComponentInParent<Renderer>();
			rend.material.SetColor("_Color", colors[i]);
		}
	}

	// Update is called once per frame
	void Update()
	{ 
		OVRInput.Update();
		OVRInput.FixedUpdate();
		if ((Input.GetKeyDown(KeyCode.Space) || OVRInput.GetDown(OVRInput.Button.One)) && !finished) { 

			// Check every button
			for (int i = 0; i < tiles.Length; i++)
			{

				if (tiles[i].highlighted)
				{
					// Gets index of emptytile in currentArray
					int emptyIndex = Array.IndexOf(currentArray, emptyTile);
                    
					if ((i == emptyIndex - 3) || (i == emptyIndex + 3) || (i == emptyIndex + 1 && emptyIndex % 3 != 2) 
						|| (i == emptyIndex - 1 && emptyIndex % 3 != 0))
					{
                        // Swap values in currentArray
                        currentArray[emptyIndex] = currentArray[i];
						currentArray[i] = emptyTile;

                        // Swap colors 
                        Renderer rend = tiles[i].transform.parent.GetComponentInParent<Renderer>();
                        rend.material.SetColor("_Color", colors[emptyIndex]); 
                        Renderer rend2 = tiles[emptyIndex].transform.parent.GetComponentInParent<Renderer>();
                        rend.material.SetColor("_Color", colors[i]);

                        // TODO Print arrays
                        Debug.Log(currentArray);
                    }

				}
			}

            int sameNums = 0;
            // Check if currentArray is equal to correctArray
            for(int i = 0; i < tiles.Length; i++)
            {
                if (currentArray[i] == correctArray[i])
                {
                    sameNums++;
                }
            }

            finished = sameNums == 9;

            // Print puzzle solved if finished
            if (finished) {
					Debug.Log("Puzzle solved!");
			}

		}


	}

    

}
