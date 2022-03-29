using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryButton;
    public GameObject spellButton;
    public GameObject returnButton;

    public GameObject spellButtons;

    public GameObject WordPanelManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToReturnButton(string buttonName)
    {
        if(string.Compare("returnScreen",buttonName)==0)
        {
            returnButton.SetActive(false);
            spellButton.SetActive(true);
            inventoryButton.SetActive(true);

            spellButtons.SetActive(false);
        } 
        else if (string.Compare("spellScreen",buttonName)==0)
        {
            spellButton.SetActive(false);
            inventoryButton.SetActive(false);
            returnButton.SetActive(true);

            spellButtons.SetActive(true);
        }
        else
        {
            inventoryButton.SetActive(false);
            returnButton.SetActive(true);
        }
    }


}
