using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadMoveable : MonoBehaviour
{
    public Transform positionLocker;
    public GameObject jumpPad;
    bool triggered = false;
    void OnTriggerEnter(Collider col)
    {
        if (triggered == false)
        {           
            if (col.gameObject == positionLocker.gameObject)
            {
                triggered = true;
                positionLocker.GetComponent<Rigidbody>().isKinematic = true;
                jumpPad.SetActive(true);
            }
        }
    }
}
