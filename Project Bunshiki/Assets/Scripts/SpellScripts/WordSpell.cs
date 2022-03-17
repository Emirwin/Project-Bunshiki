using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordSpell : MonoBehaviour //used by Nouns
{
    public WordSO word;
    protected TextMeshPro wordMesh; 

    // Start is called before the first frame update
    void Start()
    {
        wordMesh = gameObject.GetComponent<TextMeshPro>();
        SetWordSpell();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
