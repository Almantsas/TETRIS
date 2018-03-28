using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        var timerText = GetComponent<TextMeshProUGUI>();
        float t = Time.time - startTime;
        string min = ((int)t / 60).ToString();
        string sec = ((int)t % 60).ToString();
        timerText.text = min + ":" + sec;
    }
}
