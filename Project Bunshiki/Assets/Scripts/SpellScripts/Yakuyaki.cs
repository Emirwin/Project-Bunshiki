using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//The Yakuyaki class not only handles the Yakuyaki spells but is also the base class for other spells as it handles the randomness of problems to spawn.
public class Yakuyaki : Spell
{
    public int spellLevel = -1; 
    [SerializeField] private int numberSpawned = 0;
    public List<GameObject> problems;  //Problem prefabs
    private List<int> alreadySolved; //
    public GameObject activeProblem;
    public bool noActiveProblem = false;
    [SerializeField]
    private bool lastProblem = false;

    public override void Start()
    {
        if(spellLevel == -1 && problems.Count != 0)
        {
            spellLevel = problems.Count;
        }
        base.Start();
    }
    public override void Update()
    {
        if(activeProblem.Equals(null) && !lastProblem) 
        {
            int randomChoice = Random.Range(0,problems.Count);
            SpawnProblem(problems[randomChoice]);
            problems.RemoveAt(randomChoice);
            if(problems.Count == 0 || numberSpawned == spellLevel)
            {
                lastProblem = true;
            }
            noActiveProblem = false;
        }
        if(lastProblem && activeProblem.Equals(null))
        {
            spellManager.GetComponent<SpellManager>().onRitual = false;
        }
    }
    public override void StartRitual()
    {
        base.StartRitual();
        int randomChoice = Random.Range(0,problems.Count);
        SpawnProblem(problems[randomChoice]); //Spawn first problem
        problems.RemoveAt(randomChoice);
        if(problems.Count == 0)
        {
            lastProblem = true;
        }
    }
    
    public virtual void SpawnProblem(GameObject problem)
    {
        numberSpawned++;
        Vector3 problemPos = problem.transform.position;
        Debug.Log($"Spawning {problem}");
        activeProblem = Instantiate(problem, problemPos, Quaternion.identity, gameObject.transform);
        
    }
}
