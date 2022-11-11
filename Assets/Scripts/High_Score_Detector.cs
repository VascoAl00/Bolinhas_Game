using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class High_Score_Detector : MonoBehaviour
{

    public Text highscoreTextFinal;


    // Start is called before the first frame update
    void Start()
    {
        HighScore();
    }


    public void HighScore()
    {
        int high = PlayerPrefs.GetInt("score");
        if (Score_Manager.score > high)
        {

            highscoreTextFinal.text = "!!!New HighScore!!!";
            PlayerPrefs.SetInt("score", Score_Manager.score);

        }

        else
        {

            highscoreTextFinal.text = "";

        }

    }
}
