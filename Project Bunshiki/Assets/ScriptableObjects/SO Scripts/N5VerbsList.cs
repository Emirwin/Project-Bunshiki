using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/N5VerbsList", order = 1)]
public class N5VerbsList : ScriptableObject
{
    public List<N5Verbs> verbs;
}
