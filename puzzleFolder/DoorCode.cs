public class DoorCode
{

    //The code in string format
    const string CORRECT_COMBINATION = "4190";

    //The current combination
    string currentCombination;

    //Whether the door is open or not
    bool isOpen;


    /**
	 * Constructor for the DoorCode object; initiates the combinatiion (string) and a boolean.
	 *
	 */
    public DoorCode()
    {
        this.currentCombination = "";
        this.isOpen = false;
    }


    /**
	 * Adds a number to the current combination and checks for the correct code 
	 *
	 * @param number: the string that holds a number representing the button pressed
	 */
    public void ButtonPressed(string number)
    {
        this.currentCombination += number;

        //Once all four numbers are inputted
        if (this.currentCombination.Length == CORRECT_COMBINATION.Length)
        {
            if (CombinationCheck())
            {
                //door unlocks, victory popup	
            }
            else
            {
                ResetCode();
                //wrong code popup
            }
        }
    }


    /**
	 * Checks the combination once all four numbers are inputted.
	 */
    public bool CombinationCheck()
    {
        //Verifies the code 
        if (string.Equals(CORRECT_COMBINATION, this.currentCombination))
        {
            return true;
        }
        return false;
    }


    /**
	 * Resets the current combination
	 *
	 */
    public void ResetCode()
    {
        this.currentCombination = "";
    }

    /**
	 * Gets the current combination
	 *
	 */
    public string getCurrentCode()
    {
        return this.currentCombination;
    }



    // array of numbers pressed

    // display 

    // code check
}
