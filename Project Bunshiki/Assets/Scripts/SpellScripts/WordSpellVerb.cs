using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellVerb : WordSpell
{
    public bool isNegative = false;
    public bool isPast = false;
    public bool isPolite = false;

    public override void SetWordSpell()
    {
        string temp;
        temp = word.ROMAJI;

        
        if(isPolite && word.PARTOFSPEECH.Contains("Ichidan verb"))
        {
            temp = temp.Substring(0,temp.Length-2);
            temp += "masu";
        }

        wordMesh.text = temp;
    }
}
