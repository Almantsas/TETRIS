using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour {

    float lastFallDown = 0;
    public static float speed = 1;
    public bool rotate;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpeedUp", 30f, 30f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!IsInGameGrid())
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                UpdateGameGrid();
            }
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (!IsInGameGrid())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else
            {
                UpdateGameGrid();
            }
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFallDown >= speed)
        {
            transform.position += new Vector3(0, -1, 0);

            if (!IsInGameGrid())
            {
                transform.position += new Vector3(0, 1, 0);
                enabled = false;
                FindObjectOfType<Spawner>().SpawnFigure();
            }
            else
            {
                UpdateGameGrid();
            }

            lastFallDown = Time.time;
            Debug.Log(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (rotate)
            {
                transform.Rotate(0, 0, -90);

                if (!IsInGameGrid())
                {
                    transform.Rotate(0, 0, 90);
                }
                else
                {
                    UpdateGameGrid();
                }
                Debug.Log(transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rotate)
            {
                transform.Rotate(0, 0, 90);

                if (!IsInGameGrid())
                {
                    transform.Rotate(0, 0, -90);
                }
                else
                {
                    UpdateGameGrid();
                }
                Debug.Log(transform.position);
            }
        }
    }

    bool IsInsideBorder(Vector2 pos)
    {
        return ((int)pos.x > -1 &&
                (int)pos.x <= 9 &&
                (int)pos.y > -1 &&
                (int)pos.y <= 19);
    }

    bool IsInGameGrid()
    {
        foreach(Transform childCube in transform)
        {
            Vector2 v = RoundVector(childCube.position);
            if (!IsInsideBorder(v))
            {
                return false;
            }

            if(GameGrid.gameGrid[(int)v.x, (int)v.y] != null &&
                GameGrid.gameGrid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void UpdateGameGrid()
    {
        for(int y = 0; y < 20; y++)
        {
            for(int x = 0; x < 10; x++)
            {
                if(GameGrid.gameGrid[x, y] != null &&
                   GameGrid.gameGrid[x, y].parent == transform)
                {
                    GameGrid.gameGrid[x, y] = null;
                }
            }
        }

        foreach(Transform childCube in transform)
        {
            Vector2 v = RoundVector(childCube.position);

            GameGrid.gameGrid[(int)v.x, (int)v.y] = childCube;
            Debug.Log("Cube at :" + (int)v.x + " " + (int)v.y);
        }

        GameGrid.PrintArray();
    }

    Vector2 RoundVector(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    void SpeedUp()
    {
        //add speedup message
        speed -= .1f;
    }
}
