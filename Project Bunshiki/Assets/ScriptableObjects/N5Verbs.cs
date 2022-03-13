using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/N5Verb", order = 1)]
public class N5Verbs : ScriptableObject
{
    public string KANJI; 
    public string FURIGANA; 
    public string ROMAJI;

    public List<string> MEANINGS;

    public List<string> PARTOFSPEECH;
    public string COMMON;
}
