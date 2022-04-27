using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StoryTest : MonoBehaviour
{
    public DialogManager DManager;

    public GameObject[] Example;
    public DialogDataSO dData;

    void OnEnable()
    {
        
        Debug.Log($"{DManager.state}"); //prints TRUE
        var dialogTexts = new List<DialogData>();

        for(int i = 0; i < dData.lines.Count; i++)
        {
            dialogTexts.Add(new DialogData(dData.lines[i],dData.character[i]));
        }

        DManager.Show(dialogTexts);

        Debug.Log($"{DManager.state}"); //prints TRUE
        //gameObject.SetActive(false);
    }
    
}
