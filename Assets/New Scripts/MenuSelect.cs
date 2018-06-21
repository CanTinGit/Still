using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSelect : MonoBehaviour
{

    public GameObject panel;            // Reference to the menu panel
                                        // Use this for initialization

    public void OnClick()
    {
        // If the panel isn't active, set it to be active, i.e. the menu is opened
        if (panel.activeInHierarchy == false)
        {
            panel.SetActive(true);
        }
        // If the panel is active, set it to be inactive, i.e. the menu is closed
        else if (panel.activeInHierarchy == true)
        {
            panel.SetActive(false);
        }
    }
}
