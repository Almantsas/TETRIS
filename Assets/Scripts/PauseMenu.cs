using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject pauseMenuUI;

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) && !GameOver.isOver)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        ScoreManager.AddScore(FindObjectOfType<Score>().score, FindObjectOfType<Timer>().t);
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("Theme");
        Initiate.Fade("Menu", Color.black, 3.0f);
    }

    public void QuitGame()
    {
        ScoreManager.AddScore(FindObjectOfType<Score>().score, FindObjectOfType<Timer>().t);
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
