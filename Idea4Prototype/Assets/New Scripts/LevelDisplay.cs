﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelDisplay : MonoBehaviour {

    public GameObject Level_1, Level_2, Tutorial_Level;
    GameObject eventSystem;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        Level_1.SetActive(false);
        Level_2.SetActive(false);
        Tutorial_Level.SetActive(false);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        //Tutorial_Level.SetActive(true);
        //eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(Tutorial_Level);
        Level_1.SetActive(true);
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(Level_1);
        if (MenuScript.Instance.GetMaxLevel() > 1)
        {
            Level_2.SetActive(true);
            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(Level_2);
            //Level_1.SetActive(true);
            //Tutorial_Level.SetActive(false);
            //eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(Level_1);
        }
        if (MenuScript.Instance.GetMaxLevel() > 2)
        {
            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Level_1.SetActive(false);
        Level_2.SetActive(false);
        Tutorial_Level.SetActive(false);
    }
}
