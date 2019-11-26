using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject victoryScreen;



    public void StopAndReload()
    {
     
            if (Time.timeScale == 1)
            {
                victoryScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                victoryScreen.SetActive(false);
                Time.timeScale = 1;
            }


        
    }
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
