using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellCopulaDa : WordSpell
{
    public bool isNegative = false;
    public bool isPast = false;
    public bool isPolite = true;

    public override void SetWordSpell()
    {
        string temp;
        temp = word.ROMAJI;

        if(isPolite){
            if(isPast){
                temp = "datta";
            }
            else{
                temp = "da";
            }
            if(isNegative){
                temp = "de wa nai";
            }           
        }
        else{
            if(isPast){
                temp = "datta";
            }
            else{
                temp = "da";
            }
            if(isNegative){
                temp = "ja nai";
            }
        }
        

        wordMesh.text = temp;
    }
}
