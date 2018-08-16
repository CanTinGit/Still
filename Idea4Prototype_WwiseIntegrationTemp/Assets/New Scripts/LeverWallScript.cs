using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverWallScript : MonoBehaviour
{
    bool isPlayed;
    Animator lever;
    HingeJoint hammer;
    ParticleSystem air;
    void Start()
    {
        lever = GameObject.Find("LeverWall").GetComponent<Animator>();
        air = GameObject.Find("AIRCON").GetComponent<ParticleSystem>();
        hammer = GameObject.Find("Hammer").GetComponent<HingeJoint>();
        isPlayed = false;
    }

    public void Init()
    {
        if (isPlayed == true)
        {
            return;
        }
        lever.SetTrigger("LeverOn");
        air.Play();
        Invoke("Delay", 0.5f);
    }

    void Delay()
    {
        hammer.useLimits = false;
    }
}
