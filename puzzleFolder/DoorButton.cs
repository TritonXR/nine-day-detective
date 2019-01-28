// To use this example, attach this script to an empty GameObject.
// Create three buttons (Create>UI>Button). Next, select your
// empty GameObject in the Hierarchy and click and drag each of your
// Buttons from the Hierarchy to the Your First Button, Your Second Button
// and Your Third Button fields in the Inspector.
// Click each Button in Play Mode to output their message to the console.
// Note that click means press down and then release.

using UnityEngine;
using UnityEngine.UI;

public class DoorButton : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button button1, button2, button3, button4, button5, button6, button7,
       button8, button9;

    void Start()
    {
        //Calls the TaskwithParameters/TaskWithParameters/ButtonClicked method when you click the Button
        button1.onClick.AddListener(delegate { TaskwithParameters(0); });
        button2.onClick.AddListener(delegate { TaskwithParameters(1); });
        button3.onClick.AddListener(delegate { TaskwithParameters(2); });
        button4.onClick.AddListener(delegate { TaskwithParameters(3); });
        button5.onClick.AddListener(delegate { TaskwithParameters(4); });
        button6.onClick.AddListener(delegate { TaskwithParameters(5); });
        button7.onClick.AddListener(delegate { TaskwithParameters(6); });
        button8.onClick.AddListener(delegate { TaskwithParameters(7); });
        button9.onClick.AddListener(delegate { TaskwithParameters(8); });
    }

    void TaskwithParameters(int number)
    {
        //Output this to console when a button is clicked
        Debug.Log("You have clicked the button: " + number);

        //ButtonPressed(number);	
    }

}