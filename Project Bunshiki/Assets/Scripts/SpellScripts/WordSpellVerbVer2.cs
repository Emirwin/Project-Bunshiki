using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpellVerbVer2 : WordSpell
{
    public bool isNegative = false;
    public bool isPolite = false;
    public Inflection inflection;

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
    public enum verbType{
        Ichidan, Godan, Suru, Kuru
    }
    public enum godanType{
        k, g, s, t, n,
        b, m, r, w
    }

    public Dictionary<VerbBase,string> baseForms;
    private Dictionary<VerbBase,string> baseFormsJP;

    private Dictionary<Inflection,string> inflectedForms;

    private Dictionary<VerbBase,string> baseInflectedForms;
    private Dictionary<Inflection,string> infbaseinfForms;

    public List<Inflection> currentInflections;

    public override void SetWordSpell()
    {
        string temp = word.ROMAJI;
        verbType vType;
        
        vType = FindVerbType();

        if(vType==verbType.Godan)
        {
            godanType gType = FindGodanType();
            PopulateGoVerbBaseList(temp, gType,ref baseForms);
            PopulateGoInflectedFormList(gType, ref inflectedForms);
        }
        else if(vType==verbType.Ichidan)
        {
            PopulateIchiVerbBaseList(temp,ref baseForms);
            PopulateIchiInflectedFormList(ref inflectedForms);
        }
        else if(vType==verbType.Suru)
        {
            //TODO
        }
        else
        {
            //KURU
        }

        if(inflection != Inflection.Imperfective)
        {
            wordMesh.text = InflectVerb(inflection);
        }
        else
        {
            wordMesh.text = temp;
        }
    }

    public string InflectVerb(Inflection inflection)
    {
        currentInflections.Add(inflection);
        return inflectedForms[inflection];
    }

    public void AddInflection(Inflection inflection)
    {
        currentInflections.Add(inflection);
    }

    private void PopulateGoInflectedFormList(godanType gtype, ref Dictionary<Inflection, string> dictionary)
    {
        dictionary = new Dictionary<Inflection,string>(){
            {Inflection.Imperfective, baseForms[VerbBase.Terminal]}
            };
        dictionary.Add(Inflection.Conditional, baseForms[VerbBase.Hypothetical]+"ba");
        dictionary.Add(Inflection.Potential, baseForms[VerbBase.Potential]+"ru");
        dictionary.Add(Inflection.Imperative, baseForms[VerbBase.Imperative]);
        dictionary.Add(Inflection.Negative, baseForms[VerbBase.Irrealis]+"nai");
        dictionary.Add(Inflection.Passive, baseForms[VerbBase.Irrealis]+"reru");
        dictionary.Add(Inflection.Causative, baseForms[VerbBase.Irrealis]+"seru");
        dictionary.Add(Inflection.CausativePassive, baseForms[VerbBase.Irrealis]+"sareru");
        dictionary.Add(Inflection.Volitional, baseForms[VerbBase.Volitional]+"u");
        dictionary.Add(Inflection.Conjunctive, baseForms[VerbBase.Conjunctive]);

        if(gtype==godanType.g||gtype==godanType.b||gtype==godanType.m||gtype==godanType.n){
            dictionary.Add(Inflection.Perfective, baseForms[VerbBase.Euphonic]+"da");
            dictionary.Add(Inflection.Teform, baseForms[VerbBase.Euphonic]+"de");
        }
        else {
            dictionary.Add(Inflection.Perfective, baseForms[VerbBase.Euphonic]+"ta");
            dictionary.Add(Inflection.Teform, baseForms[VerbBase.Euphonic]+"te");
        }
    }

    private void PopulateIchiInflectedFormList(ref Dictionary<Inflection, string> dictionary)
    {
        dictionary = new Dictionary<Inflection,string>(){
            {Inflection.Imperfective, baseForms[VerbBase.Terminal]}
            };
        dictionary.Add(Inflection.Conditional, baseForms[VerbBase.Hypothetical]+"ba");
        dictionary.Add(Inflection.Potential, baseForms[VerbBase.Potential]+"ru");
        dictionary.Add(Inflection.Imperative, baseForms[VerbBase.ImperativeSpoken]);
        dictionary.Add(Inflection.Negative, baseForms[VerbBase.Irrealis]+"nai");
        dictionary.Add(Inflection.Passive, baseForms[VerbBase.Irrealis]+"rareru");
        dictionary.Add(Inflection.Causative, baseForms[VerbBase.Irrealis]+"saseru");
        dictionary.Add(Inflection.CausativePassive, baseForms[VerbBase.Irrealis]+"saserareru");
        dictionary.Add(Inflection.Volitional, baseForms[VerbBase.Volitional]+"you");
        dictionary.Add(Inflection.Conjunctive, baseForms[VerbBase.Conjunctive]);
        dictionary.Add(Inflection.Perfective, baseForms[VerbBase.Euphonic]+"ta");
        dictionary.Add(Inflection.Teform, baseForms[VerbBase.Euphonic]+"te");
        
    }

    private void PopulateIchiVerbBaseList(string temp, ref Dictionary<VerbBase,string> dictionary)
    {
        string vBase = temp;
        dictionary = new Dictionary<VerbBase,string>(){
            {VerbBase.Terminal, temp}
            };
        dictionary.Add(VerbBase.Attributive, temp); //Att
        dictionary.Add(VerbBase.Hypothetical, temp.Substring(0,temp.Length-2)); //Hypo
        dictionary.Add(VerbBase.Potential, temp.Substring(0,temp.Length-2)); //Pot
        dictionary.Add(VerbBase.Imperative, temp.Substring(0,temp.Length-2));
        dictionary.Add(VerbBase.ImperativeSpoken, temp.Substring(0,temp.Length-2)+"ro"); //Imp
        dictionary.Add(VerbBase.Irrealis, temp.Substring(0,temp.Length-2)); //Irr
        dictionary.Add(VerbBase.Volitional, temp.Substring(0,temp.Length-2)); //Vol
        dictionary.Add(VerbBase.Conjunctive, temp.Substring(0,temp.Length-2)); //Con
        dictionary.Add(VerbBase.Euphonic, temp.Substring(0,temp.Length-2)); //Eup
    }

    private void PopulateGoVerbBaseList(string temp, godanType godanType,ref Dictionary<VerbBase,string> dictionary)
    {
        string vBase = temp;
        int trim = vBase.Length;
        if(godanType == godanType.t)
        {
            trim-=2;
        }
        else
        {
            trim-=1;
        }
        string vStem = vBase.Substring(0,trim);  

        //TERMINAl ATTRIBUTIVE (終身刑　連体形)
        dictionary = new Dictionary<VerbBase,string>(){
            {VerbBase.Terminal, vBase}
            };
        dictionary.Add(VerbBase.Attributive, vBase); 

        //HYPOTHETICAL POTENTIAL (仮定形　可能形)
        dictionary.Add(VerbBase.Hypothetical, vStem+"e");
        dictionary.Add(VerbBase.Potential, vStem+"e");

        //IMPERATIVE (命令形)
        dictionary.Add(VerbBase.Imperative, vStem+"e");
        dictionary.Add(VerbBase.ImperativeSpoken, vStem+"e"); //Imp

        //IRREALIS VOLITIONAL (未然形　意思形)
        if(godanType == godanType.w) {
            dictionary.Add(VerbBase.Irrealis, vStem+"wa"); //Irr
        }
        else {
            dictionary.Add(VerbBase.Irrealis, vStem+"a"); //Irr
        } 
        dictionary.Add(VerbBase.Volitional, vStem+"o"); //Vol

        //CONJUNCTIVE (連用形)
        if(godanType==godanType.s)
        {
            dictionary.Add(VerbBase.Conjunctive, vStem+"hi"); //Con
        }
        else
        {
            dictionary.Add(VerbBase.Conjunctive, vStem+"i"); //Con
        }
        
        //EUPHONIC (音便形)
        if(godanType==godanType.t||godanType==godanType.r||godanType==godanType.w)
        {
            dictionary.Add(VerbBase.Euphonic, vStem+"t"); //Eup
        }
        else if(godanType==godanType.n||godanType==godanType.b||godanType==godanType.m)
        {
            dictionary.Add(VerbBase.Euphonic, vStem.Substring(0,vStem.Length-1)+"n"); //Eup
        }
        else if(godanType == godanType.s)
        {
            dictionary.Add(VerbBase.Euphonic, vStem+"hi"); 
        }
        else 
        {
            dictionary.Add(VerbBase.Euphonic, vStem+"i"); 
        }
        
        
    }

    private godanType FindGodanType()
    {
        if(word.PARTOFSPEECH.Contains("Godan verb with u ending")) {
            return godanType.w;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with ku ending")) {
            return godanType.k;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with gu ending")) {
            return godanType.g;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with su ending")) {
            return godanType.s;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with tsu ending")) {
            return godanType.t;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with nu ending")) {
            return godanType.n;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with bu ending")) {
            return godanType.b;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with mu ending")) {
            return godanType.m;
        }
        else if(word.PARTOFSPEECH.Contains("Godan verb with ru ending")) {
            return godanType.r;
        }
        else {
            return godanType.k;
        }
    }

    verbType FindVerbType()
    {
        if(word.PARTOFSPEECH.Contains("Ichidan verb")) {
            
            return verbType.Ichidan;
        }
        else if(word.PARTOFSPEECH.Contains("suru verb"))
        {
            return verbType.Suru;
        }
        else if(word.FURIGANA.Contains("kuru"))
        {
            return verbType.Kuru;
        }
        else {
            return verbType.Godan;
            
        }
    }
}
