using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordSpell : MonoBehaviour
{
    public WordSO word;
    private TextMeshPro wordMesh; 
    // Start is called before the first frame update
    void Start()
    {
        wordMesh = gameObject.GetComponent<TextMeshPro>();
        wordMesh.text = word.ROMAJI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log($"Meaning: {word.MEANINGS[0]}");
    }
}
