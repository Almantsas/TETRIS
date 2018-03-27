using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGrid : MonoBehaviour {

    public static Transform[,] gameGrid = new Transform[14, 24];
    static SpeedUp speed = FindObjectOfType(typeof(SpeedUp)) as SpeedUp;

    public static void DeleteFullRows()
    {
        for (int row = 21; row > 1; row--)
        {
            if (IsRowFull(row))
            {
                Score.score++;
                speed.IncreaseSpeed();
                for (int col = 2; col < 12; col++)
                {
                    Destroy(gameGrid[col, row].gameObject);
                    gameGrid[col, row] = null;
                }

                for (int rowM = row + 1; rowM < 22; rowM++)
                {
                    for (int col = 2; col < 12; col++)
                    {
                        if (gameGrid[col, rowM] != null)
                        {
                            gameGrid[col, rowM - 1] = gameGrid[col, rowM];
                            gameGrid[col, rowM - 1].position += new Vector3(0, -1, 0);
                            gameGrid[col, rowM] = null;
                        }
                    }
                }
            }
        }
    }

    static bool IsRowFull(int row)
    {
        for (int col = 2; col < 12; col++)
        {
            if (gameGrid[col, row] == null)
            {
                return false;
            }
        }
        return true;
    }
}
