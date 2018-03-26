using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {
    public GameObject speedUpText;
    public GameObject logo;

    // Use this for initialization
    void Start () {
        InvokeRepeating("Show", 60f, 60f);
        InvokeRepeating("Hide", 63f, 63f);
    }

    void Update()
    {
        if (Figure.speed < 0.3f)
        {
            CancelInvoke("Show");
            CancelInvoke("Hide");
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
}
