using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellAdjective : WordSpell
{
    public bool isNegative = false;
    public bool isPast = false;

    public override void SetWordSpell()
    {
        string temp;
        temp = word.ROMAJI;

        wordMesh.text = temp;
    }
}
