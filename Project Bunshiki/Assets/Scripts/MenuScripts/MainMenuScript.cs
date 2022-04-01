using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayStory()
    {
        Debug.Log("StartStory");
    }

    public void PlayEndless()
    {
        Debug.Log("StartEndless");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DebugMode() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
