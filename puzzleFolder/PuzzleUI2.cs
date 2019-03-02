using UnityEngine;
using System.Collections;
using System.Linq;

public class PuzzleUI : MonoBehaviour
{
    public string input;
    public bool onTrigger;
    public bool doorOpen;
    public bool keypadScreen;
    public bool display = false;
    public Transform doorHinge;

    // Tracks which button is currently the button that is empty
    public int emptyButton = 1;

    public bool puzzleNotAlreadySolved = true;

    // ArrayList which needs to be ordered
    public ArrayList buttonList = new ArrayList(){1,2,3,4,5,6,7,8,9};
    // Final ArrayList which the player needs to get
    public ArrayList orderedList = new ArrayList(){2,1,3,4,5,6,7,8,9};


    void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        keypadScreen = false;
        input = "";
    }

    void Update()
    {
        if (buttonList.ToArray().SequenceEqual(orderedList.ToArray()) && puzzleNotAlreadySolved)
        {
            Debug.Log("Puzzle Solved");
            puzzleNotAlreadySolved = false;
        }

    }

    void OnGUI()
    {
        if (!doorOpen)
        {
            if (onTrigger)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    keypadScreen = !keypadScreen;
                    onTrigger = false;
                }
            }

            if (keypadScreen)
            {
                GUI.Box(new Rect(0, 0, 320, 455), "");
                GUI.Box(new Rect(5, 5, 310, 25), input);
                GUI.color = Color.blue;
                if (GUI.Button(new Rect(5, 35, 100, 100), "1"))
                {
                    if (emptyButton == 2)
                    {
                        emptyButton = 1;
                        swap(2, 1);
                        GUI.contentColor = Color.red;
                    }
                    if (emptyButton == 3)
                    {
                        emptyButton = 1;
                        swap(3, 1);
                    }
                }
                GUI.color = Color.green;
                if (GUI.Button(new Rect(110, 35, 100, 100), "2"))
                {
                    if (emptyButton == 1)
                    {
                        emptyButton = 2;
                        swap(1, 2);
                    }
                    if (emptyButton == 3)
                    {
                        emptyButton = 2;
                        swap(3, 2);
                    }
                    if (emptyButton == 5)
                    {
                        emptyButton = 2;
                        swap(5, 2);
                    }
                }
                if (GUI.Button(new Rect(215, 35, 100, 100), "3"))
                {
                    if (emptyButton == 2)
                    {
                        emptyButton = 3;
                        swap(2, 3);
                    }
                    if (emptyButton == 6)
                    {
                        emptyButton = 3;
                        swap(6, 3);
                    }
                }
                if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
                {
                    if (emptyButton == 1)
                    {
                        emptyButton = 4;
                        swap(1, 4);
                    }
                    if (emptyButton == 5)
                    {
                        emptyButton = 4;
                        swap(5, 4);
                    }
                    if (emptyButton == 7)
                    {
                        emptyButton = 4;
                        swap(7, 4);
                    }
                }
                if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
                {
                    if (emptyButton == 2)
                    {
                        emptyButton = 5;
                        swap(2, 5);
                    }
                    if (emptyButton == 4)
                    {
                        emptyButton = 5;
                        swap(4, 5);
                    }
                    if (emptyButton == 6)
                    {
                        emptyButton = 5;
                        swap(6, 5);
                    }
                    if (emptyButton == 8)
                    {
                        emptyButton = 5;
                        swap(8, 5);
                    }
                }
                if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
                {
                    if (emptyButton == 3)
                    {
                        emptyButton = 6;
                        swap(3, 6);
                    }
                    if (emptyButton == 5)
                    {
                        emptyButton = 6;
                        swap(5, 6);
                    }
                    if (emptyButton == 9)
                    {
                        emptyButton = 6;
                        swap(9, 6);
                    }
                }
                if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
                {
                    if (emptyButton == 4)
                    {
                        emptyButton = 7;
                        swap(4, 7);
                    }
                    if (emptyButton == 8)
                    {
                        emptyButton = 7;
                        swap(8, 7);
                    }
                }
                if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
                {
                    if (emptyButton == 5)
                    {
                        emptyButton = 8;
                        swap(5, 8);
                    }
                    if (emptyButton == 7)
                    {
                        emptyButton = 8;
                        swap(7, 8);
                    }
                    if (emptyButton == 9)
                    {
                        emptyButton = 8;
                        swap(9, 8);
                    }
                }
                if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
                {
                    if (emptyButton == 6)
                    {
                        emptyButton = 9;
                        swap(6, 9);
                    }
                    if (emptyButton == 8)
                    {
                        emptyButton = 9;
                        swap(8, 9);
                    }
                }
            }
        }
    }


    // Swaps two different buttons in buttonList 
    void swap(int button1, int button2) 
    {
	    // Look for the buttons in the ArrayList
	    int button1Index = buttonList.IndexOf(button1);
	    int button2Index = buttonList.IndexOf(button2);

	    // First swap 
	    buttonList.RemoveAt(button1Index);
	    buttonList.Insert(button1Index, button2);

	    // Second swap
	    buttonList.RemoveAt(button2Index);
	    buttonList.Insert(button2Index, button1);

        /**
         Debug.Log("swapped " + button1 + "and " + button2);

        string buttonListPrint = "";
        string orderedListPrint = "";

        foreach (int obj in buttonList)
        {
            buttonListPrint += "" + obj;
        }
        foreach (int obj in orderedList)
        {
            orderedListPrint += "" + obj;
        }

        Debug.Log(buttonListPrint);
        Debug.Log(orderedListPrint);
        **/

    }
}
