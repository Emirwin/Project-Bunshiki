using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SakanoboriNextControl : MonoBehaviour
{
    private Sakanobori sakanoboriScript;
    void Awake()
    {
        sakanoboriScript = GameObject.FindGameObjectWithTag("ActiveSpell").GetComponent<Sakanobori>();
    }

    void OnMouseDown()
    {
        sakanoboriScript.NextProblem();
    }
}
