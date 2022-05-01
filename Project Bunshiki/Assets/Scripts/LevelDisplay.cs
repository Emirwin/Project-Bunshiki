using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private TextMeshProUGUI levelDescription;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject lockIcon;
    [SerializeField] private Image levelImage;

    public GameObject storyIcon, battleIcon;

    public void DisplayLevel(LevelSO _level)
    {
        levelName.text = _level.levelName;
        levelName.color = _level.nameColor;
        levelDescription.text = _level.levelDescription;
        levelImage.sprite = _level.levelImage;

        bool levelUnlocked = PlayerPrefs.GetInt("currentScene", 0) >= _level.levelIndex;
        lockIcon.SetActive(!levelUnlocked);
        playButton.interactable = levelUnlocked;

        if(levelUnlocked)
        {
            levelImage.color = Color.white;
            switch (_level.levelDescription)
            {
                case "Story":
                    battleIcon.SetActive(false);
                    storyIcon.SetActive(true);
                    break;
                case "Combat":
                    storyIcon.SetActive(false);
                    battleIcon.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            battleIcon.SetActive(false);
            storyIcon.SetActive(false);
            levelImage.color = Color.gray;
        }

        

        playButton.onClick.RemoveAllListeners();
        //playButton.onClick.AddListener(()=> SceneManager.LoadScene(_level.sceneToLoad.name));
        playButton.onClick.AddListener(()=> SceneManager.LoadScene(_level.loadIndex));
    }
}
