using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : MonoBehaviour {

    public GameObject Level_1, Level_2, Tutorial_Level;

    void Start()
    {
        Level_1.SetActive(false);
        Level_2.SetActive(false);
        Tutorial_Level.SetActive(false);
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(MenuScript.Instance.GetMaxLevel());
        Tutorial_Level.SetActive(true);
        if (MenuScript.Instance.GetMaxLevel()>1)
        {
            Level_1.SetActive(true);
            Tutorial_Level.SetActive(false);
        }
        if(MenuScript.Instance.GetMaxLevel() >2)
        {
            Level_2.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Level_1.SetActive(false);
        Level_2.SetActive(false);
        Tutorial_Level.SetActive(false);
    }
}
