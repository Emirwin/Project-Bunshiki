using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WordSO : ScriptableObject
{
    public string KANJI; 
    public string FURIGANA; 
    public string ROMAJI;

    public List<string> MEANINGS;

    public List<string> PARTOFSPEECH;
    public string COMMON;
}
