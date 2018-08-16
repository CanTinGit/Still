using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    GameObject mainCamera;
	// Use this for initialization
	void Start ()
    {
        mainCamera = GameObject.Find("Main Camera");
	}

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = mainCamera.GetComponent<ScoreSystem>().finalScore.ToString();
    }
}
