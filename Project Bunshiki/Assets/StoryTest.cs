using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryTest : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;
    public DialogDataSO dData;

    void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData(dData.lines[0],"Yo"));
        dialogTexts.Add(new DialogData(dData.lines[1],"Yo"));
        dialogTexts.Add(new DialogData(dData.lines[2],"Yo"));

        DialogManager.Show(dialogTexts);
    }
    
}
