using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PuzzleHighlightable : MonoBehaviour
{
    // Correct array - preset
    int[] correctArray = new int[9] { 1, 8, 2, 0, 4, 5, 3, 6, 7 };

    // Current array
    int[] currentArray = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

    // Empty tile - preset
    int emptyTile = 8;

    // Tiles  of the puzzle 
    public Highlightable[] tiles;
    bool finished = false;

    // Preset colors
    Color[] currColors = new Color[9] {Color.red, Color.yellow, Color.green, Color.cyan,
        Color.blue, Color.magenta, Color.black, Color.grey, Color.white };

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();
        if ((Input.GetKeyDown(KeyCode.E) || OVRInput.GetDown(OVRInput.Button.One)) && !finished)
        {

            // Check every button
            for (int i = 0; i < tiles.Length; i++)
            {

                if (tiles[i].highlighted)
                {
                    // Gets index of emptytile in currentArray
                    int emptyIndex = Array.IndexOf(currentArray, emptyTile);
                    Debug.Log(emptyIndex);

                    if ( (i < currentArray.Length) && ( (i == emptyIndex - 3) || (i == emptyIndex + 3) || (i == emptyIndex + 1 && emptyIndex % 3 != 2)
                        || (i == emptyIndex - 1 && emptyIndex % 3 != 0) ) )
                    {
                        // Swap colors in currColor
                        Color tempColor = currColors[emptyIndex];
                        currColors[emptyIndex] = currColors[i];
                        currColors[i] = tempColor;

                        Renderer rend = tiles[emptyIndex].transform.parent.GetComponentInParent<Renderer>();
                        rend.material.SetColor("_Color", currColors[emptyIndex]);
                        rend = tiles[i].transform.parent.GetComponentInParent<Renderer>();
                        rend.material.SetColor("_Color", currColors[i]);

                        // Swap values in currentArray
                        currentArray[emptyIndex] = currentArray[i];
                        currentArray[i] = emptyTile;
                    }
                    // Reset button
                    else if (i == 9)
                    {
                        Setup();
                    }
               
                    string str = "";
                    for (int j = 0; j < currentArray.Length; j++)
                    {
                        str += currentArray[j] + ",";
                    }
                    //Debug.Log("Array is " + str);
                    
                }
            }

            int sameNums = 0;
            // Check if currentArray is equal to correctArray
            for (int i = 0; i < currentArray.Length; i++)
            {
                if (currentArray[i] == correctArray[i])
                {
                    sameNums++;
                }
            }

            finished = sameNums == 9;

            // Print puzzle solved if finished
            if (finished)
            {
                Debug.Log("Puzzle solved!");
            }

        }


    }

    // Setup the puzzle
    void Setup()
    {
        currColors = new Color[9] {Color.red, Color.yellow, Color.green, Color.cyan,
                Color.blue, Color.magenta, Color.black, Color.grey, Color.white };

        currentArray = new int[9] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };

        // Set a color to each button
        for (int i = 0; i < currColors.Length; i++)
        {
            Renderer rend = tiles[i].transform.parent.GetComponentInParent<Renderer>();
            rend.material.SetColor("_Color", currColors[i]);
        }

    }


}