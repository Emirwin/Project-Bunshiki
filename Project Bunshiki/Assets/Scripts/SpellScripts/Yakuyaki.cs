using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//The Yakuyaki class not only handles the Yakuyaki spells but is also the base class for other spells as it handles the randomness of problems to spawn.
public class Yakuyaki : Spell
{
    public List<GameObject> problems;  //Problem prefabs
    private List<int> alreadySolved; //
    public GameObject activeProblem;
    public bool noActiveProblem = false;
    private bool lastProblem = false;

    public override void Update()
    {
        if(noActiveProblem && !lastProblem) 
        {
            int randomChoice = Random.Range(0,problems.Count);
            SpawnSentence(problems[randomChoice]);
            problems.RemoveAt(randomChoice);
            if(problems.Count == 0)
            {
                lastProblem = true;
            }
            noActiveProblem = false;
        }
        if(lastProblem && noActiveProblem)
        {
            spellManager.GetComponent<SpellManager>().onRitual = false;
        }
    }
    public override void StartRitual()
    {
        base.StartRitual();
        int randomChoice = Random.Range(0,problems.Count);
        SpawnSentence(problems[randomChoice]); //Spawn first problem
        problems.RemoveAt(randomChoice);
        if(problems.Count == 0)
        {
            lastProblem = true;
        }
    }
    
    public void SpawnSentence(GameObject problem)
    {
        Debug.Log($"Spawning {problem}");
        Instantiate(problem, problem.transform.position, Quaternion.identity, gameObject.transform);
        
    }
}
