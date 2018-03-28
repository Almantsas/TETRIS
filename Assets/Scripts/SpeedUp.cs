using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public GameObject speedUpText;
    public GameObject logo;
    public float speed = 1f;

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
        if (score == 3)
        {
            Speed();
        }
        if (score == 15)
        {
            Speed();
        }
        if (score == 25)
        {
            Speed();
        }
        if (score == 35)
        {
            Speed();
        }
        if (score == 45)
        {
            Speed();
        }
    }

    void Speed()
    {
        speed -= .1f;
        Show();
        Invoke("Hide", 3f);
    }
}
