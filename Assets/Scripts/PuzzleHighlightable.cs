using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: duplicate gameobjects (keypad) - 9 buttons

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

    // Start is called before the first frame update
    void Start()
    {
        // TODO set colors
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
                    if((i == emptyTile - 3) || (i == emptyTile + 3) || (i == emptyTile + 1 && emptyTile % 3 != 2) || (i == emptyTile - 1 && emptyTile % 3 != 0))
                    {
                        // TODO: implement swap in correct array and emptytile change
                    }

                }
            }
	    }
    }

}
