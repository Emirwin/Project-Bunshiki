using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/SentenceList", order = 1)]
public class SentenceList : ScriptableObject
{
    public List<SentenceSO> sentences; 
}
