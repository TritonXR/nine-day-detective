
public class PuzzleGame
{
    //Array of tiles
    Tile[] tileArray;
    //Array of ints to initiate Tiles in the wrong order
    int[] tileOrder = { }; //choose the order of numbers 0-8 <---
                           // 8th tile is the empty one


    /**
	 * Constructor for the PuzzleGame. Initiates tileArray and makes the Tiles in puzzle order.
	 */
    public PuzzleGame()
    {
        this.tileArray = new Tile[9];
        for (int i = 0; i < (this.tileArray.Length - 1); i++)
        {
            this.tileArray[i] = new Tile(false, tileOrder[i]);
        }
        this.tileArray[8] = new Tile(true, tileOrder[8]);
    }


    /**
	 * Checks whether the user has won. Call this method everytime a tile is moved.
	 */
    public bool CheckWin()
    {
        for (int i = 0; i < tileArray.Length; i++)
        {
            if (this.tileArray[i].tileNumber != i)
            {
                return false;
            }
        }
        return true;
    }

    /**
	 * Switches the empty Tile and the pressed Tile.
	 *
	 * @param tileNumber: The Number of the Tile pressed.
	 */
    public void TilePressed(int tileNumber)
    {
        Tile[] newTileArray = new Tile[9];
        for (int i = 0; i < this.tileArray.Length; i++)
        {
            //If it is the Tile pressed, make it empty
            if (tileArray[i].tileNumber == tileNumber)
            {
                newTileArray[i] = new Tile(true, 8);
            }
            //If it is the empty Tile, make it the Tile pressed
            else if (tileArray[i].tileNumber == 8)
            {
                newTileArray[i] = new Tile(false, tileNumber);
            }
            //If it isn't any of the above, copy the same tile over.
            else
            {
                newTileArray[i] = new Tile(false, tileArray[i].tileNumber);
            }
        }
        this.tileArray = newTileArray;
    }


}//End class PuzzleGame


public class Tile
{

    public bool isEmpty;
    public int tileNumber;

    public Tile(bool isEmpty, int tileNumber)
    {
        this.isEmpty = isEmpty;
        this.tileNumber = tileNumber;
    }


}

