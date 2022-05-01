using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject parent;

    void Update()
    {
        if(parent==null)
        {
            Destroy(gameObject);
        }
        
    }
}
