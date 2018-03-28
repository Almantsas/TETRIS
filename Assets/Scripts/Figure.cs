using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Figure : MonoBehaviour {

    float lastFallDown = 0;
    public bool canRotate;
    float speed;

    // Use this for initialization
    void Start () {
        speed = FindObjectOfType<SpeedUp>().speed;
        IsOver();
    }

    // Update is called once per frame
    void Update () {
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
                FindObjectOfType<AudioManager>().Play("Move");
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
                FindObjectOfType<AudioManager>().Play("Move");
            }
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFallDown >= speed)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!IsValidPos())
            {
                transform.position += new Vector3(0, 1, 0);
                if (!GameGrid.DeleteFullRows())
                {
                    FindObjectOfType<AudioManager>().Play("Drop");
                }
                enabled = false;
                Invoke("Spawn", .5f);
            }
            else
            {
                UpdateGameGrid();
                FindObjectOfType<AudioManager>().Play("Move");
            }

            lastFallDown = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canRotate)
            {
                transform.Rotate(0, 0, -90);

                if (!IsValidCubePos())
                {
                    transform.Rotate(0, 0, 90);
                }
                else
                {
                    if (Rotate())
                    {
                        UpdateGameGrid();
                        FindObjectOfType<AudioManager>().Play("Rotate");
                    }
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
    }

    bool Rotate()
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
                    return false;
                }
            }
            if (v.x == 0)
            {
                transform.position += new Vector3(2, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(-2, 0, 0);
                    transform.Rotate(0, 0, 90);
                    return false;
                }
            }
            if (v.x == 12)
            {
                transform.position += new Vector3(-1, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(1, 0, 0);
                    transform.Rotate(0, 0, 90);
                    return false;
                }
            }
            if (v.x == 13)
            {
                transform.position += new Vector3(-2, 0, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(2, 0, 0);
                    transform.Rotate(0, 0, 90);
                    return false;
                }
            }
            if (v.y == 1)
            {
                transform.position += new Vector3(0, 1, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(0, -1, 0);
                    transform.Rotate(0, 0, 90);
                    return false;
                }
            }
            if (v.y == 22)
            {
                transform.position += new Vector3(0, -1, 0);
                if (!IsValidCubePos())
                {
                    transform.position += new Vector3(0, 1, 0);
                    transform.Rotate(0, 0, 90);
                    return false;
                }
            }
        }
        return true;
    }

    void Spawn()
    {
        FindObjectOfType<Spawner>().SpawnFigure();
        UpdateGameGrid();
    }

    Vector2 RoundVector(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
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
