using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour {

    public void Easy()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Theme");
        SceneManager.LoadScene("Main");
        SpeedUp.difficulty = "Easy";
    }

    public void Medium()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Theme");
        SceneManager.LoadScene("Main");
        SpeedUp.difficulty = "Medium";
    }

    public void Hard()
    {
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Theme");
        SceneManager.LoadScene("Main");
        SpeedUp.difficulty = "Hard";
    }
}
