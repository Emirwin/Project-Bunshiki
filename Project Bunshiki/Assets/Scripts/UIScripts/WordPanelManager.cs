using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordPanelManager : MonoBehaviour
{
    public GameObject baseWordInfo;
    public GameObject meaningInfo;
    public GameObject partOfSpeechInfo;

    public void ChangeText(GameObject infoScreen, string str)
    {
        infoScreen.GetComponent<TextMeshProUGUI>().text = str;
    }
}
