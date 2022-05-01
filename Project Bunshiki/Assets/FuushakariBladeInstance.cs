using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuushakariBladeInstance : MonoBehaviour
{
    public int number;
    public bool isCracked = false;
    public GameObject cracks;
    
    public void CrackBlade()
    {
        isCracked = true;
        cracks.SetActive(true);
    }
    public void FixBlade()
    {
        cracks.SetActive(false);
    }
}
