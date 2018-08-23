﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerButton : MonoBehaviour {



    void OnTriggerEnter(Collider other)
    {
        ParticleSystem jumpair = GameObject.Find("JumpFan").GetComponent<ParticleSystem>();

        jumpair.Play();
        AkSoundEngine.PostEvent("computer_fan_trigger", gameObject);
        jumpair.transform.Find("AirJumpZone").gameObject.SetActive(true);
    }
}
