using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("ThrowMaster");
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
