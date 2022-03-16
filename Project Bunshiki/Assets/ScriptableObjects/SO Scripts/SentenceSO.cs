using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/Sentence", order = 1)]
public class SentenceSO : ScriptableObject
{
    public List<WordSO> words;
    //public List<string> translation;
}
