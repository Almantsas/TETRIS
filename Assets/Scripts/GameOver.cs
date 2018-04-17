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
            PlayerPrefs.SetInt("Score", FindObjectOfType<Score>().score);
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
        SceneManager.LoadScene("Main");
    }

    public void LoadMenu()
    {
        isOver = false;
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("Theme");
        SceneManager.LoadScene("Menu");
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
