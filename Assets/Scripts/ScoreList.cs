using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreList : MonoBehaviour {

    public GameObject scoreListItem;
    // Use this for initialization
    void Start () {
        ListAll("Easy");
	}

    public void Easy()
    {
        ListAll("Easy");
    }

    public void Medium()
    {
        ListAll("Medium");
    }

    public void Hard()
    {
        ListAll("Hard");
    }

    void ListAll(string difficulty)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        List<ScoreManager.Scores> scoresList = ScoreManager.GetScores(difficulty);
        if (scoresList.Count > 10)
        {
            scoresList.GetRange(0, 10);
        }
        for (int i = 0; i < scoresList.Count; i++)
        {
            GameObject go = Instantiate(scoreListItem);
            go.transform.SetParent(transform, false);
            go.transform.Find("#").GetComponent<TextMeshProUGUI>().text = (i + 1).ToString();
            go.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = scoresList[i].score.ToString();

            float t = scoresList[i].time;
            string min = ((int)t / 60).ToString();
            string sec = ((int)t % 60).ToString();
            go.transform.Find("Time").GetComponent<TextMeshProUGUI>().text = min + ":" + sec;
        }

        if (difficulty == "Easy")
        {
            GameObject.Find("Header").GetComponent<Graphic>().color = new Color32(111, 199, 69, 255);
        }
        else if (difficulty == "Medium")
        {
            GameObject.Find("Header").GetComponent<Graphic>().color = new Color32(255, 237, 0, 255);
        }
        else if (difficulty == "Hard")
        {
            GameObject.Find("Header").GetComponent<Graphic>().color = new Color32(248, 44, 44, 255);
        }
    }
}
