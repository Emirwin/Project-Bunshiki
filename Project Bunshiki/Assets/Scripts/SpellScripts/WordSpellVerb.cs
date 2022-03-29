using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellVerb : WordSpell
{
    public bool isNegative = false;
    public bool isPolite = false;
    public enum Inflection
    {
        Plain, //Indicative
        Past, //Indicative
        TeForm,
        Infinitive,
        Potential,
        Passive,
        Causative,
        CausativePassive,
        Imperative,
        Conditional,
        ProvisionalConditional,
        PastProgressive,
        Progressive,
        PastPresumptive,
        Presumptive
    }
    protected enum verbType{
        Ichidan,
        Godan,
        Special

    }

    public Inflection inflection = Inflection.Plain;

    public override void SetWordSpell()
    {
        string temp;
        temp = word.ROMAJI;
        verbType vType = verbType.Special;


        
        if(word.PARTOFSPEECH.Contains("Ichidan verb"))
        {
            vType = verbType.Ichidan;
        }
        else
        {
            vType = verbType.Godan;
        }

        if(inflection != Inflection.Plain)
        {
            wordMesh.text = InflectVerb(vType);
        }
        else
        {
            wordMesh.text = temp;
        }


        
    }

    private string InflectVerb(verbType type)
    {
        string temp = word.ROMAJI;

        if(type == verbType.Ichidan) //TO DO: Other forms 
        {
            temp = temp.Substring(0,temp.Length-2);
            if(inflection == Inflection.Past)
            {
                temp += "ta";
            }
            else if(inflection == Inflection.TeForm)
            {
                temp += "te";
            }
            else if(inflection == Inflection.Potential)
            {
                temp += "rareru";
            }
            else if(inflection == Inflection.Passive)
            {
                temp += "rareru";
            }
                else if(inflection == Inflection.Causative)
            {
                temp += "saseru";
            }
            else if(inflection == Inflection.CausativePassive)
            {
                temp += "saserareru";
            }
            else if(inflection == Inflection.Imperative)
            {
                temp += "ro";
            }
        }
        else if(type == verbType.Godan) //GODAN VERBS
        {
            //-----------------------------------
            //  Check for Godan Verb subgroup
            //-----------------------------------
            string godanKind = "u"; //KAU
            int len = temp.Length;
            //Debug.Log(temp);
            //Debug.Log($"starts at {len-2} with length {2}: {temp.Substring(len-2,2)}");
            //Debug.Log($"starts at {len-3} with length {3}: {temp.Substring(len-3,3)}");
            string twoLastLetters = temp.Substring(len-2,2);
            string threeLastLetters = temp.Substring(len-3,3);
            if(string.Equals(twoLastLetters,"ku")||string.Equals(twoLastLetters,"gu")) {
                godanKind = "ku"; //Example: OYOGU
            }
            else if(string.Equals(threeLastLetters,"tsu")) {
                godanKind = "tsu"; //MATSU
            }
            else if(string.Equals(twoLastLetters,"su")) {
                godanKind = "su"; //HANASU
            }
            else if(string.Equals(twoLastLetters,"bu")||string.Equals(twoLastLetters,"mu")||string.Equals(twoLastLetters,"nu")) {
                godanKind = "bu"; //YOBU
            }
            else if(string.Equals(twoLastLetters,"ru")){
                godanKind = "ru"; //SHIRU
            }

            //Do conjugation
            temp = temp.Substring(0,temp.Length-1);
            if(inflection == Inflection.Plain)      
            {
                if(isPolite)                //PLAIN-Polite
                {
                    if(isNegative){
                        temp += "imasen";   //KAIMASEN  OYOGIMASEN
                    }
                    else {
                        temp += "imasu";    //KAIMASU   OYOGIMASU
                    }
                    
                }
                else                        //PLAIN
                {
                    if(isNegative){
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "anai"; //KAWANAI   OYOGANAI
                    }
                    else {
                        temp += "u";    //KAU   OYOGU
                    }
                }
            }
            else if(inflection == Inflection.Past)
            {
                if(isPolite)                        //PAST-Polite
                {
                    if(isNegative){
                        temp += "imasendeshita";    //KAIMASENDESHITA   
                    }
                    else {
                        temp += "imashita";     //KAIMASHITA
                    }
                    
                }
                else                                //PAST
                {
                    if(isNegative){
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "anakatta";     //KAWANAKATTA
                    }
                    else {
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ida";            //OYOIDA
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="nda";            //YONDA
                        }
                        else{
                            temp += "tta";          //KATTA
                        }
                        
                    }
                }
            }
            else if(inflection == Inflection.TeForm)
            {
                if(string.Equals(godanKind, "ku")){
                    temp = temp.Substring(0,temp.Length-1);
                    temp+="ide";            //OYOIDE
                } 
                else if(string.Equals(godanKind, "bu")){
                    temp = temp.Substring(0,temp.Length-1);
                    temp+="nde";            //YONDE
                }
                else if(string.Equals(godanKind, "ru")){
                    temp = temp.Substring(0,temp.Length-1);
                    temp += "tte";
                }
                else{
                    temp += "tte";          //KATTE
                }
            }
            else if(inflection == Inflection.Potential)
            {
                if(isPolite)    //POT-Polite
                {
                    if(isNegative){ 
                        temp += "emasen"; //KAEMASEN
                    }
                    else {
                        temp += "emasu";    //KAEMASU
                    }
                    
                }
                else            //POT-Plain
                {
                    if(isNegative){
                        temp += "enai";     //KAENAI
                    }
                    else {
                        temp += "eru";    //KAERU
                    }
                }               
            }
            else if(inflection == Inflection.Passive)
            {
                if(string.Equals(godanKind, "u")){
                    temp += "w";
                }

                if(isPolite)            //Passive-Polite
                {
                    if(isNegative){ 
                        temp += "aremasen";  //KAWAREMASEN
                    }
                    else {
                        temp += "aremasu";    //KAWAREMASU
                    }
                    
                }
                else            //Passive
                {
                    if(isNegative){
                        temp += "arenai";     //KAWARENAI
                    }
                    else {
                        temp += "areru";    //KAWARERU
                    }
                } 
                
            }
                else if(inflection == Inflection.Causative)
            {
                if(string.Equals(godanKind, "u")){
                    temp += "w";
                }
                if(isPolite)            //Causative-Polite
                {
                    if(isNegative){ 
                        temp += "asemasen";  //KAWASEMASEN
                    }
                    else {
                        temp += "asemasu";    //KAWASEMASU
                    }
                    
                }
                else            //Causative
                {
                    if(isNegative){
                        temp += "asenai";     //KAWASENAI
                    }
                    else {
                        temp += "aseru";    //KAWASERU
                    }
                }
            }
            else if(inflection == Inflection.CausativePassive)
            {
                if(string.Equals(godanKind, "u")){
                    temp += "w";
                }
                if(isPolite)            //CausativePassive-Polite
                {
                    if(isNegative){ 
                        temp += "aseraremasen";  //KAWASERAREMASEN
                    }
                    else {
                        temp += "aseraremasu";    //KAWASERAREMASU
                    }
                    
                }
                else            //CausativePassive
                {
                    if(isNegative){
                        temp += "aserarenai";     //KAWASERARENAI
                    }
                    else {
                        temp += "aserareru";    //KAWASRARERU
                    }
                }
            }
            else if(inflection == Inflection.Imperative)
            {

                if(isPolite)            //Imperative-Polite
                {
                    if(isNegative){ 
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "anaidekudasai";  //KAWANAIDEKUDASAI
                    }
                    else {
                        
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="idekudasai";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndekudasai";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "ttekudasai";
                        }
                        else{
                            temp += "ttekudasai";          //KATTE
                        }
                    }
                    
                }
                else            //Imperative
                {
                    if(isNegative){
                        temp += "una";     //KAUNA
                    }
                    else {
                        temp += "e";    //KAE
                    }
                }
            }
            else if(inflection == Inflection.Conditional)
            {

                if(isPolite)            //Conditional-Polite
                {
                    if(isNegative){ 
                        temp += "imasendeshitara";  //KAWANAIDEKUDASAI
                    }
                    else {
                        temp += "imashitara";    //KATTEKUDASAI
                    }
                    
                }
                else            //Conditional
                {
                    if(isNegative){
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "anakattara";     //KAUNA
                    }
                    else {
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="idara";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndara";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "ttara";
                        }
                        else{
                            temp += "ttara";          //KATTE
                        }
                    }
                }
            }
            else if(inflection == Inflection.ProvisionalConditional)
            {

                if(isPolite)            //Conditional-Polite
                {
                    temp = "N/A";  //KAWANAIDEKUDASAI
                }
                else            //Conditional
                {
                    if(isNegative){
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "anakereba";     //KAUNA
                    }
                    else {
                        temp += "eba";    //KAE
                    }
                }
            }
            else if(inflection == Inflection.PastProgressive)
            {

                if(isPolite)            //Conditional-Polite
                {
                    if(isNegative){ 
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideimasendeshita";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeimasendeshita";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteimasendhita";
                        }
                        else{
                            temp += "tteimasendeshita";          //KATTE
                        }
                    }
                    else {
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideimashita";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeimashita";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteimahita";
                        }
                        else{
                            temp += "tteimashita";          //KATTE
                        }
                    }
                }
                else            //Conditional
                {
                    if(isNegative){
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideinai";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeinai";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteinai";
                        }
                        else{
                            temp += "tteinai";          //KATTE
                        }
                    }
                    else {
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideita";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeita";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteita";
                        }
                        else{
                            temp += "tteita";          //KATTE
                        }
                    }
                }
            }
            else if(inflection == Inflection.Progressive)
            {

                if(isPolite)            //Conditional-Polite
                {
                    if(isNegative){ 
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideimasen";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeimasen";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteimasen";
                        }
                        else{
                            temp += "tteimasen";          //KATTE
                        }
                    }
                    else {
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideimasu";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeimasu";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteimasu";
                        }
                        else{
                            temp += "tteimasu";          //KATTE
                        }
                    }
                    
                }
                else            //Conditional
                {
                    if(isNegative){
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideinai";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeinai";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteinai";
                        }
                        else{
                            temp += "tteinai";          //KATTE
                        }     //KAUNA
                    }
                    else {
                        if(string.Equals(godanKind, "ku")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ideiru";            //OYOIDE
                        } 
                        else if(string.Equals(godanKind, "bu")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp+="ndeiru";            //YONDE
                        }
                        else if(string.Equals(godanKind, "ru")){
                            temp = temp.Substring(0,temp.Length-1);
                            temp += "tteiru";
                        }
                        else{
                            temp += "tteiru";          //KATTE
                        }    //KAE
                    }
                }
            }
            else if(inflection == Inflection.PastPresumptive)
            {

                if(isPolite)            //Conditional-Polite
                {
                    if(isNegative){ 
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "-TODO";  //KAWANAIDEKUDASAI
                    }
                    else {
                        temp += "-TODO";    //KATTEKUDASAI
                    }
                    
                }
                else            //Conditional
                {
                    if(isNegative){
                        temp += "-TODO";     //KAUNA
                    }
                    else {
                        temp += "-TODO";    //KAE
                    }
                }
            }
            else if(inflection == Inflection.Presumptive)
            {

                if(isPolite)            //Conditional-Polite
                {
                    if(isNegative){ 
                        if(string.Equals(godanKind, "u")){
                            temp += "w";
                        }
                        temp += "-TODO";  //KAWANAIDEKUDASAI
                    }
                    else {
                        temp += "-TODO";    //KATTEKUDASAI
                    }
                    
                }
                else            //Conditional
                {
                    if(isNegative){
                        temp += "-TODO";     //KAUNA
                    }
                    else {
                        temp += "-TODO";    //KAE
                    }
                }
            }
            //TO DO: Other forms 
        }


        return temp;
    }
}
