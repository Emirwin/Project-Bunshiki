using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public bool isActive = false;
    public int duration = 5;
    void Awake()
    {
        isActive = true;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("I am attacking!");
    }
}
