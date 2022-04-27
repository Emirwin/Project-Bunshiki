using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsChanger : MonoBehaviour
{
    [SerializeField] private ScriptableObject[] scriptableObjects;
    [SerializeField] private LevelDisplay levelDisplay;
    private int currentIndex;

    private void Awake()
    {
        levelDisplay.DisplayLevel((LevelSO)scriptableObjects[0]);
    }

    public void ChangeScriptableObject(int _change)
    {
        currentIndex += _change;
        if(currentIndex<0) {
            currentIndex = scriptableObjects.Length - 1;
        }
        else if(currentIndex > scriptableObjects.Length - 1) {
            currentIndex = 0;
        }

        if(levelDisplay != null) {
            levelDisplay.DisplayLevel((LevelSO)scriptableObjects[currentIndex]);
        }
    }
}
