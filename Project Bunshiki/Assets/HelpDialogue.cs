using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class HelpDialogue : MonoBehaviour
{
    public GameManager gameManager;
    public DialogManager DManager;
    public List<DialogDataSO> coveredTopics;

    private int deactivateCounter = 0;

    void Update()
    {
        if(DManager.state.Equals(Doublsb.Dialog.State.Deactivate))
        {
            deactivateCounter++;
        }
        if(deactivateCounter>10 && (DManager.Result != "Whatever"))
        {
            deactivateCounter = 0;
            gameManager.ResumeGame();
            gameObject.SetActive(false);
        }
    }
    
    void OnEnable()
    {
        gameManager.PauseGame();

        var dialogTexts = new List<DialogData>();

        var HelpText = new DialogData("Hey! What would you like help with?");
        //First add the covered topics
        for(int i = 0; i < coveredTopics.Count; i++)
        {
            HelpText.SelectList.Add($"{i}",$"About {coveredTopics[i].name}");
        }
        //Then, add the available spells (TODO)

        HelpText.SelectList.Add("Whatever",$"Nevermind!");

        HelpText.Callback = () => Manage_Selection();

        dialogTexts.Add(HelpText);
        DManager.Show(dialogTexts);
    }

    void Manage_Selection()
    {
        Debug.Log("Hey");
        Debug.Log($"{DManager.Result}");
        if(DManager.Result == "Whatever")
        {
            gameManager.ResumeGame();
            gameObject.SetActive(false);
        }
        else
        {
            int index = int.Parse(DManager.Result);
            var dialogTexts = new List<DialogData>();

            var HelpText = new DialogData("Okay so...");
            dialogTexts.Add(HelpText);

            for(int i = 0; i < coveredTopics[index].lines.Count; i++)
            {
                dialogTexts.Add(new DialogData(coveredTopics[index].lines[i],coveredTopics[index].character[i]));
            }

            DManager.Show(dialogTexts);
            
        }
    }
}
