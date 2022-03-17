using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public Spell[] activeSpells;
    public Spell[] allSpells;

    public UIManager uiManager;
    public GameManager gameManager;
    public GameObject activeSpell;
    public bool onRitual = false;
    public bool spellIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!onRitual && spellIsActive)
        {
            EndSpell();
        }
        
    }

    //StartSpell methods are called by the buttons.
    public void StartSpell(int spellNumber)
    {
        Instantiate(activeSpells[spellNumber]);
        onRitual = true;
    }

    public void StartSpell(string spellName)
    {
        int selectedSpell = -1;
        for(int i = 0; i < activeSpells.Length; i++)
        {
            if(string.Compare(activeSpells[i].name,spellName)==0)
            {
                Instantiate(activeSpells[i]);
                selectedSpell = i;
            }
        }
        onRitual = true;
        spellIsActive = true;
        
        //spell is started, tell UI Manager to hide spell buttons
        uiManager.spellButtons.SetActive(false);
        //During the spell's duration, also hide the returnButton.
        //After a set duration, the ritual/spell ends so set those buttons back to active
        StartCoroutine(SpellCountdownRoutine(activeSpells[selectedSpell].durationSeconds));

        
        //EndRitual(FindObjectByTag("ActiveSpell"))
    }

    public void EndSpell()
    {
        Debug.Log("END RITUAL");
        //Store the score THEN Destroy the spell
        activeSpell = GameObject.FindGameObjectWithTag("ActiveSpell");
        Debug.Log($"Score: {activeSpell.GetComponent<Spell>().score}!");

        //Before destroying the spell, first stop the timer if it was still running
        StopAllCoroutines();

        Destroy(activeSpell);
        spellIsActive = false;

        //Press return.
        gameManager.ChangeScreen("returnScreen");
        uiManager.ChangeToReturnButton("returnScreen");
    }

    IEnumerator SpellCountdownRoutine(int seconds)
    {
        activeSpell = GameObject.FindGameObjectWithTag("ActiveSpell");
        for(int i = seconds; i>0; i--)
        {
            yield return new WaitForSeconds(1f);
            activeSpell.GetComponent<Spell>().CountDownUI();
        }
        onRitual = false;
    }
}
