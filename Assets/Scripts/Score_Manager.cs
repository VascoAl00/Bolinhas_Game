using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public static int score;


 
    void Start()
    {

        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {

        if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetInt("score", 0);
        }


    }

    public static void IncreaseScore()
    {

        score++;

    }

}
