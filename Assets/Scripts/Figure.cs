using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Figure : MonoBehaviour {

    float lastFallDown = 0;
    public static float speed = 1f;
    public bool rotate;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpeedUp", 60f, 60f);
        IsOver();
    }

    // Update is called once per frame
    void Update () {
        if (speed < 0.3f)
        {
            CancelInvoke("SpeedUp");
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);

            if (!IsValidPos())
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else
            {
                UpdateGameGrid();
            }
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);

            if (!IsValidPos())
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else
            {
                UpdateGameGrid();
            }
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFallDown >= speed)
        {
            transform.position += new Vector3(0, -1, 0);

            if (!IsValidPos())
            {
                transform.position += new Vector3(0, 1, 0);
                enabled = false;
                Invoke("Spawn", 0.5f);
            }
            else
            {
                UpdateGameGrid();
            }

            lastFallDown = Time.time;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, -1, 0);

            if (!IsValidPos())
            {
                transform.position += new Vector3(0, 1, 0);
                enabled = false;
                Invoke("Spawn", 0.5f);
            }
            else
            {
                UpdateGameGrid();
            }
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (rotate)
            {
                transform.Rotate(0, 0, -90);

                if (!IsValidCubePos())
                {
                    transform.Rotate(0, 0, 90);
                }
                else
                {
                    Rotate();
                    UpdateGameGrid();
                }
            }
        }
    }

    bool IsValidPos()
    {
        foreach(Transform childCube in transform)
        {
            Vector2 v = RoundVector(childCube.position);
            if (!((int)v.x > 1 &&
                (int)v.x < 12 &&
                (int)v.y > 1 &&
                (int)v.y < 22))
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

    bool IsValidCubePos()
    {
        foreach (Transform childCube in transform)
        {
            Vector2 v = RoundVector(childCube.position);
            if (GameGrid.gameGrid[(int)v.x, (int)v.y] != null &&
                GameGrid.gameGrid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }

    void UpdateGameGrid()
    {
        for(int y = 0; y < 24; y++)
        {
            for(int x = 0; x < 14; x++)
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
        }

        GameGrid.PrintArray();
    }

    void Rotate()
    {
        foreach (Transform childCube in transform)
        {
            Vector2 v = RoundVector(childCube.position);

            if (v.x == 1)
            {
                transform.position += new Vector3(1, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(-1, 0, 0);
                    transform.Rotate(0, 0, 90);
                }
            }
            if (v.x == 0)
            {
                transform.position += new Vector3(2, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(-2, 0, 0);
                    transform.Rotate(0, 0, 90);
                }
            }
            if (v.x == 12)
            {
                transform.position += new Vector3(-1, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(1, 0, 0);
                    transform.Rotate(0, 0, 90);
                }
            }
            if (v.x == 13)
            {
                transform.position += new Vector3(-2, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(2, 0, 0);
                    transform.Rotate(0, 0, 90);
                }
            }
            if (v.y == 1)
            {
                transform.position += new Vector3(0, 1, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(0, -1, 0);
                    transform.Rotate(0, 0, 90);
                }
            }
            if (v.y == 22)
            {
                transform.position += new Vector3(0, -1, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(0, 1, 0);
                    transform.Rotate(0, 0, 90);
                }
            }
        }
    }

    void Spawn()
    {
        FindObjectOfType<Spawner>().SpawnFigure();
    }

    Vector2 RoundVector(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }

    void SpeedUp()
    {
        speed -= .1f;
    }

    void IsOver()
    {
        if (!IsValidPos())
        {
            Destroy(gameObject);
            GameOver.isOver = true;
        }
    }
}
