using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public int score = 0;

    public void ScoreUp()
    {
        score++;
        var scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }
}
