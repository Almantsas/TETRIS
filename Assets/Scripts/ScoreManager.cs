using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static void AddScore(int score, float time)
    {
        int i = 0;
        if(score > 0)
        {
            while (true)
            {
                if (!PlayerPrefs.HasKey(i + "Score"))
                {
                    PlayerPrefs.SetInt(i + "Score", score);
                    PlayerPrefs.SetFloat(i + "Time", time);
                    PlayerPrefs.SetString(i + "Difficulty", SpeedUp.difficulty);
                    break;
                }
                i++;
            }
        }
    }

    public static List<Scores> GetScores(string difficulty)
    {
        List<Scores> scoresList = new List<Scores>();
        int i = 0;
        while (true)
        {
            if (PlayerPrefs.HasKey(i + "Score"))
            {
                Scores temp = new Scores
                {
                    score = PlayerPrefs.GetInt(i + "Score"),
                    time = PlayerPrefs.GetFloat(i + "Time"),
                    difficulty = PlayerPrefs.GetString(i + "Difficulty")
            };
                scoresList.Add(temp);
            }
            else {
                break;
            }
            i++;
        }
        if (difficulty == "Easy")
        {
            scoresList = scoresList.Where(x => x.difficulty == "Easy").ToList();
        }
        else if (difficulty == "Medium")
        {
            scoresList = scoresList.Where(x => x.difficulty == "Medium").ToList();
        }
        else if (difficulty == "Hard")
        {
            scoresList = scoresList.Where(x => x.difficulty == "Hard").ToList();
        }
        scoresList = scoresList.OrderByDescending(x => x.score).ThenBy(x => x.time).ToList();
        return scoresList;
    }

    public static int GetHighScore()
    {
        List<Scores> scoresList = GetScores(SpeedUp.difficulty);
        if(scoresList.Count > 0)
        {
            int highScore = scoresList[0].score;
            return highScore;
        }
        else
        {
            return 0;
        }
    }

    public class Scores
    {
        public int score;
        public float time;
        public string difficulty;
    }
}
