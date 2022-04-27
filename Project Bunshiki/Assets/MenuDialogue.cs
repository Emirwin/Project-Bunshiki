using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doublsb.Dialog;

public class MenuDialogue : MonoBehaviour
{
    public GameManager gameManager;
    public DialogManager DManager;

    //public DialogDataSO[] coveredTopics;

    void OnEnable()
    {
        gameManager.PauseGame();

        var dialogTexts = new List<DialogData>();

        var Text1 = new DialogData("Return to menu?");
        Text1.SelectList.Add("LevelSelect", "Return to Level Select");
        Text1.SelectList.Add("Whatever", "Nevermind");

        Text1.Callback = () => Manage_Selection();

        dialogTexts.Add(Text1);
        DManager.Show(dialogTexts);
        
    }

    void Manage_Selection()
    {
        Debug.Log($"{DManager.Result}");
        if(DManager.Result == "LevelSelect")
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            gameManager.ResumeGame();
            gameObject.SetActive(false);
        }
    }
}
