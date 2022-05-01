using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuushakariBlades : MonoBehaviour
{
    public int crackedBlade;
    public List<FuushakariBladeInstance> blades;
    // Start is called before the first frame update
    void Start()
    {
        blades[crackedBlade-1].CrackBlade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
