using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : MonoBehaviour {

    public GameObject Level_1, Level_2;

    void Start()
    {
        Level_1.SetActive(false);
        Level_2.SetActive(false);
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {
        Level_1.SetActive(true);
        Level_2.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Level_1.SetActive(false);
        Level_2.SetActive(false);
    }
}
