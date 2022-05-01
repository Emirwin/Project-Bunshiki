using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataList", menuName = "ScriptableObjects/DialogData", order = 1)]

public class DialogDataSO : ScriptableObject
{
    public List<string> lines;
    public List<string> character;

}
