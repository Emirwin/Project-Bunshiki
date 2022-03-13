using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resize : MonoBehaviour
{
    public GameObject parent;
    private RectTransform spriteSize;
    // Start is called before the first frame update
    void Start()
    {
        spriteSize = gameObject.GetComponent<RectTransform>();
        Rect parentRect = parent.GetComponent<RectTransform>().rect;
        Debug.Log($"{spriteSize.transform.localScale}");
        Debug.Log($"and {parentRect}");

        spriteSize.transform.localScale = new Vector3 (parentRect.width, parentRect.height, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
