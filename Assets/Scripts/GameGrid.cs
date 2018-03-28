using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour {

    public static Transform[,] gameGrid = new Transform[14, 24];

    public static bool DeleteFullRows()
    {
        int lines = 0;
        for (int row = 21; row > 1; row--)
        {
            if (IsRowFull(row))
            {
                FindObjectOfType<Score>().ScoreUp();
                FindObjectOfType<SpeedUp>().IncreaseSpeed();
                lines++;

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

            if (lines > 0 && lines != 4 && row == 2)
            {
                FindObjectOfType<AudioManager>().Play("LineClear");
                return true;
            }

            if (lines == 4 && row == 2)
            {
                FindObjectOfType<AudioManager>().Play("4LineClear");
                return true;
            }
        }
        return false;
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
