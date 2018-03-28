using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MainMenu");
    }

    void Play()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Theme");
        SceneManager.LoadScene("Main");
    }

    void QuitGame()
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
