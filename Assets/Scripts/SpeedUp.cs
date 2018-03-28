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
        Score scor = FindObjectOfType(typeof(Score)) as Score;
        if (scor.score == 1)
        {
            speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (scor.score == 15)
        {
            speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (scor.score == 25)
        {
            speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (scor.score == 35)
        {
            speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
        if (scor.score == 45)
        {
            speed -= .1f;
            Show();
            Invoke("Hide", 3f);
        }
    }
}
