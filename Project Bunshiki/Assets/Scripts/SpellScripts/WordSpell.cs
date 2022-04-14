using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordSpell : MonoBehaviour //used by Nouns
{
    public WordSO word;
    protected TextMeshPro wordMesh; 
    public WordPanelManager wordPanelManager;
    public bool replaceWordMesh = false;

    // Start is called before the first frame update
    void Start()
    {
        
        wordPanelManager = GameObject.Find("WordPanel").GetComponent<WordPanelManager>();

        wordMesh = gameObject.GetComponent<TextMeshPro>();

        if(word != null)
        {
            if(replaceWordMesh) {
                SetWordSpell();
            }
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} has no Scriptable Object Word attached.");
        }
        
        
    }

    public virtual void SetWordSpell()
    {
        string temp;
        temp = word.ROMAJI;

        wordMesh.text = temp;
    }

    void OnMouseDown()
    {
        Debug.Log($"Meaning: {word.MEANINGS[0]}");
        //Display in UI

        
        DisplayWordInfo();
    }

    void DisplayWordInfo()  //Tell WordPanelManager to show in the word panel
    {
        //Selection glow?
        wordPanelManager.ChangeText(wordPanelManager.baseWordInfo, $"{word.ROMAJI} - {word.KANJI} ({word.FURIGANA})");
        wordPanelManager.ChangeText(wordPanelManager.meaningInfo, $"{word.MEANINGS[0]}");
        
        string partsOfSpeech = "";
        foreach (string str in word.PARTOFSPEECH)
        {
            partsOfSpeech += str+"\n";
        }
        
        wordPanelManager.ChangeText(wordPanelManager.partOfSpeechInfo, $"{partsOfSpeech}");
        //if verb, also add which conjugation form it is
    }
}
