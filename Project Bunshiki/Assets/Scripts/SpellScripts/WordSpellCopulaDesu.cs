using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellCopulaDesu : WordSpell
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
                temp = "deshita";
            }
            else{
                temp = "desu";
            }
            if(isNegative){
                temp = "de wa arimasen";
            }           
        }
        else{
            if(isPast){
                temp = "deshita";
            }
            else{
                temp = "desu";
            }
            if(isNegative){
                temp = "ja arimasen";
            }
        }
        

        wordMesh.text = temp;
    }
}
