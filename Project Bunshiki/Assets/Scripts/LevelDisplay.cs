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
        }
        else
        {
            levelImage.color = Color.gray;
        }

        playButton.onClick.RemoveAllListeners();
        //playButton.onClick.AddListener(()=> SceneManager.LoadScene(_level.sceneToLoad.name));
        playButton.onClick.AddListener(()=> SceneManager.LoadScene(_level.loadIndex));
    }
}
