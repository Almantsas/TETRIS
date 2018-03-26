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
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            gameOverUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void PlayAgain()
    {
        isOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main");
    }

    public void LoadMenu()
    {
        isOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
