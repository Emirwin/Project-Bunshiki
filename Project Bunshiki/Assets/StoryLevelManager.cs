using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameClearScreen;

    public void EnableGameClearScreen()
    {
        gameClearScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelSelect()
    {
        Debug.Log(PlayerPrefs.GetInt("currentScene"));
        if(PlayerPrefs.GetInt("currentScene") < SceneManager.GetActiveScene().buildIndex-2)
        {
            PlayerPrefs.SetInt("currentScene", SceneManager.GetActiveScene().buildIndex-2);
        }
        SceneManager.LoadScene(2);
    }
}
