using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptableObjectTest : MonoBehaviour
{
    public N5Verbs newWord;
    public N5VerbsList wordDB;
    public int currWord = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshPro>().text = newWord.ROMAJI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        gameObject.GetComponent<TextMeshPro>().text = wordDB.verbs[currWord].ROMAJI;
        currWord++;
        if(currWord == 3)
        {
            currWord = 0;
        }
    }
}
