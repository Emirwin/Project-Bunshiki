using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellVerbVer3 : WordSpell
{
    public Inflection currInflection;
    public List<VerbBase> verbBases;
    public enum VerbBase {
        Terminal, Attributive,
        Hypothetical, Potential,
        Imperative, ImperativeSpoken,
        Irrealis, Volitional,
        Conjunctive, Euphonic
    }
    public enum Inflection {
        Imperfective,
        Conditional, Potential,
        Imperative,
        Negative, Passive, Causative, CausativePassive,
        Volitional, Conjunctive, Perfective, Teform
    }

    public override void SetWordSpell()
    {
        
    }
    
}
