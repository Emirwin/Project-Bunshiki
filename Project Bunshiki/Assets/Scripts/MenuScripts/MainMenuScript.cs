using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject ClearConfirmScreen;
    public GameObject CreditScreen;
    public void PlayStory()
    {
        Debug.Log("StartStory");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayEndless()
    {
        Debug.Log("StartEndless");
        SceneManager.LoadScene(16);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DebugMode() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenClearConfirmScreen()
    {
        ClearConfirmScreen.SetActive(true);
    }
    public void CloseClearConfirmScreen()
    {
        ClearConfirmScreen.SetActive(false);
    }

    public void OpenCreditScreen()
    {
        CreditScreen.SetActive(true);
    }
    public void CloseCreditScreen()
    {
        CreditScreen.SetActive(false);
    }

    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
