using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final_Menu : MonoBehaviour
{
  
    public void StartGame()
    {

        SceneManager.LoadScene("Level01");
        Score_Manager.score = 0;

    }

    public void QuitGame()
    {

        Debug.Log("Quit!");
        Application.Quit();

    }

}