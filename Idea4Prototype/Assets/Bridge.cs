﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    public GameObject bridge;

    void OnDestroy()
    {
        bridge.GetComponent<Rigidbody>().isKinematic = false;
    }
}
