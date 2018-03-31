using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public static bool isOver = false;
    public GameObject gameOverUI;

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            FindObjectOfType<AudioManager>().Stop("Theme");
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOverUI.SetActive(false);
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
