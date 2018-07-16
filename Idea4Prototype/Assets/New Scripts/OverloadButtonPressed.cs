using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverloadButtonPressed : MonoBehaviour
{
    Spawner buttonReference;
    void Awake()
    {
        buttonReference = GameObject.Find("SpawnerManager").GetComponent<Spawner>();
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Pickup")
        {
            buttonReference.SpawnFalse();
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            buttonReference.SpawnTrue();
        }
    }
}
