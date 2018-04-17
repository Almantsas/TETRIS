using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public static bool isOver = false;
    public GameObject gameOverUI;
    bool save = true;

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            Time.timeScale = 0f;
            FindObjectOfType<AudioManager>().Stop("Theme");
            gameOverUI.SetActive(true);
            if(save)
            {
                ScoreManager.AddScore(FindObjectOfType<Score>().score, FindObjectOfType<Timer>().t);
                save = false;
            }
        }
        else
        {
            gameOverUI.SetActive(false);
            save = true;
        }
    }

    public void PlayAgain()
    {
        isOver = false;
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("Theme");
        Initiate.Fade("Main", Color.black, 3.0f);
    }

    public void LoadMenu()
    {
        isOver = false;
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("Theme");
        Initiate.Fade("Menu", Color.black, 3.0f);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HoverSound()
    {
        FindObjectOfType<AudioManager>().Play("Rotate");
    }

    public void ClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Drop");
    }
}
