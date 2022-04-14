using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanoboriControl : MonoBehaviour
{
    public Sakanobori.jumpDirection direction;
    private Sakanobori sakanoboriScript;

    void Start()
    {
        sakanoboriScript = GameObject.FindGameObjectWithTag("ActiveSpell").GetComponent<Sakanobori>();

    }

    void OnMouseDown()
    {
        if(!sakanoboriScript.isMiniMoving)
        {
            sakanoboriScript.Jump(direction);
        }
        
    }
}
