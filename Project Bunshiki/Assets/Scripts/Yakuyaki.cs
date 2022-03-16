using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Yakuyaki : Spell
{
    public List<GameObject> problems;  //Problem prefabs
    private List<int> alreadySolved; //
    public override void StartRitual()
    {
        base.StartRitual();
        SpawnSentence(problems[0]);
    }
    
    public void SpawnSentence(GameObject problem)
    {
        Debug.Log($"Spawning {problem}");
        Instantiate(problem);
    }
}
