using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Spell : MonoBehaviour
{
    public GameObject spellManager;
    //When a spell is instantiated, it starts the ritual
    public int score = 0;
    public TextMeshPro scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        scoreUI = GameObject.Find("ScoreUI").GetComponent<TextMeshPro>();
        spellManager = GameObject.Find("SpellManager");
        StartRitual();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StartRitual()
    {
        Debug.Log($"Ritual {gameObject.name} is starting.");
    }

    public void UpdateScore(int ptsToAdd)
    {
        score += ptsToAdd;
        scoreUI.text = $"{score}";
    }
}
