using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject inventoryButton;
    public GameObject spellButton;
    public GameObject returnButton;

    public GameObject spellButtons;

    public GameObject WordPanelManager;

    public GameObject gameOverScreen;
    public GameObject gameClearScreen;
    
    void OnEnable()
    {
        Player.OnPlayerDeath += EnableGameOverScreen;
    }

    void OnDisable()
    {
        Player.OnPlayerDeath -= EnableGameOverScreen;
    }

    public void ChangeToReturnButton(string buttonName)
    {
        if(string.Compare("returnScreen",buttonName)==0)
        {
            returnButton.SetActive(false);
            spellButton.SetActive(true);
            //inventoryButton.SetActive(true);

            spellButtons.SetActive(false);
        } 
        else if (string.Compare("spellScreen",buttonName)==0)
        {
            spellButton.SetActive(false);
            //inventoryButton.SetActive(false);
            returnButton.SetActive(true);

            spellButtons.SetActive(true);
        }
        else
        {
            //inventoryButton.SetActive(false);
            returnButton.SetActive(true);
        }
    }

    public void EnableGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

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
        Debug.Log(PlayerPrefs.GetInt("currentScene"));
        SceneManager.LoadScene(2);
    }
}
