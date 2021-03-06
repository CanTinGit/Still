﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject boxColliderStopper;
    public GameObject boxColliderBack;
    int numbersofPlayer;
    public string CameraMove;
    public Animator camera;
    public string musicSection;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            numbersofPlayer++;
            if (numbersofPlayer == MenuScript.Instance.GetNumberofPlayers())
            {
                boxColliderStopper.SetActive(false);
                boxColliderBack.SetActive(true);
                gameObject.SetActive(false);
                camera.SetTrigger(CameraMove);
                AkSoundEngine.SetSwitch("Music_Transition", musicSection, GameObject.FindGameObjectWithTag("MainCamera"));
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            numbersofPlayer--;
        }
    }
}
