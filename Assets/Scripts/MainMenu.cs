using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoreText;

    void Start()
    {
        HighScore();
        Debug.Log(PlayerPrefs.GetInt("score"));
    }

    public void StartGame()
    {

        SceneManager.LoadScene("Level01");


    }

    public void QuitGame()
    {

        Debug.Log("Quit!");
        Application.Quit();

    }

    public void HighScore()
    {
        
        highscoreText.text = "Highscore = " + PlayerPrefs.GetInt("score");

    }

    public void ResetHighScore()
    {

        PlayerPrefs.SetInt("score", 0);

    }

}
