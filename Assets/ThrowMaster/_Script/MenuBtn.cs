using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseUI;

    public void StartGame()
    {
        SceneManager.LoadScene("ThrowMaster");
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
       pauseUI.SetActive(true);
       Time.timeScale = 0.0f;
       GameIsPaused = true;
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
       Time.timeScale = 1.0f;
       GameIsPaused = false;

    }
}
