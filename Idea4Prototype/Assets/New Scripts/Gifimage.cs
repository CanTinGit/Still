using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gifimage : MonoBehaviour {

    public Sprite[] frames;
    int framesPerSecond = 10;
    Image image;


    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
    }
    // Update is called once per frame
    void Update ()
    {
        int index = Mathf.RoundToInt((Time.time * framesPerSecond) % (frames.Length - 1));
        image.sprite = frames[index];
	}
}
