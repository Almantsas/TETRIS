using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public GameObject speedUpText;
    public GameObject logo;

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
        if (Score.score == 5)
        {
            Figure.speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (Score.score == 15)
        {
            Figure.speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (Score.score == 25)
        {
            Figure.speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (Score.score == 35)
        {
            Figure.speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (Score.score == 45)
        {
            Figure.speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
    }
}
