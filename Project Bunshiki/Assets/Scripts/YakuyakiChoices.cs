using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YakuyakiChoices : MonoBehaviour
{
    public int pointValue;
    private Yakuyaki yakuyaki;
    
    void Start()
    {
        yakuyaki = GameObject.Find("Yakuyaki").GetComponent<Yakuyaki>();
    }
    void OnMouseDown()
    {
        yakuyaki.UpdateScore(pointValue);
    }
}
