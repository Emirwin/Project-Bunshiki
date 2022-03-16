using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public Spell[] activeSpells;
    public Spell[] allSpells;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //StartSpell methods are called by the buttons.
    public void StartSpell(int spellNumber)
    {
        Instantiate(activeSpells[spellNumber]);
    }

    public void StartSpell(string spellName)
    {
        for(int i = 0; i < activeSpells.Length; i++)
        {
            if(string.Compare(activeSpells[i].name,spellName)==0)
            {
                Instantiate(activeSpells[i]);
            }
        }
    }
}
