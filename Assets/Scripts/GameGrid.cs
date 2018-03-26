using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGrid : MonoBehaviour {

    public static Transform[,] gameGrid = new Transform[14, 24];

    public static void PrintArray()
    {
        string arrayOutput = "";
        int iMax = gameGrid.GetLength(0) - 1;
        int jMax = gameGrid.GetLength(1) - 1;

        for(int j = jMax; j >= 0; j--)
        {
            for (int i = 0; i <= iMax; i++)
            {
                if(gameGrid[i, j] == null)
                {
                    arrayOutput += "N";
                }
                else
                {
                    arrayOutput += "X";
                }
            }
            arrayOutput += "\n";
        }

        var myArrayComponent = GameObject.Find("Array").GetComponent<Text>();
        myArrayComponent.text = arrayOutput;
    }

}
