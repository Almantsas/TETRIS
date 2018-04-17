using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public GameObject speedUpText;
    public GameObject logo;
    public float speed;
    public static string difficulty;

    void Awake()
    {
        if(difficulty == "Easy")
        {
            speed = 1f;
        }
        else if(difficulty == "Medium")
        {
            speed = 0.85f;
        }
        else if (difficulty == "Hard")
        {
            speed = 0.7f;
        }
    }

    void Show()
    {
        speedUpText.SetActive(true);
        logo.SetActive(false);
    }

    void Hide()
    {
        speedUpText.SetActive(false);
        logo.SetActive(true);
    }

    public void IncreaseSpeed()
    {
        var score = FindObjectOfType<Score>().score;
        if (score == 5)
        {
            ReduceSpeed();
        }
        if (score == 15)
        {
            ReduceSpeed();
        }
        if (score == 25)
        {
            ReduceSpeed();
        }
        if (score == 35)
        {
            ReduceSpeed();
        }
        if (score == 45)
        {
            ReduceSpeed();
        }
    }

    void ReduceSpeed()
    {
        speed -= .1f;
        Show();
        Invoke("Hide", 3f);
    }

    public void SetSpeed()
    {
        ReduceSpeed();
    }
}
