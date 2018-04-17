using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var highScoreText = GetComponent<TextMeshProUGUI>();
        highScoreText.text = ScoreManager.GetHighScore().ToString();
    }
}
