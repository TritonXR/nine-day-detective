using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: duplicate gameobjects (keypad) - 9 buttons

public class PuzzleHighlightable : MonoBehaviour
{
    // Variables for game logic
    int[] correctArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    // Current array - preset
    int[] currentArray = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

    // Pieces  of the puzzle 
    public Highlightable[] pieces;
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        // TODO set colors
    }

    // Update is called once per frame
    void Update()
    {
        // TODO for loop and logic at each index -  should i preset?

    }
}
