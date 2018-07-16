using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float padStrength;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        if (col.tag == "Player")
        {
            Debug.Log("player is launched");
            col.GetComponent<Rigidbody>().velocity = Vector3.up * padStrength;
        }
    }
}
