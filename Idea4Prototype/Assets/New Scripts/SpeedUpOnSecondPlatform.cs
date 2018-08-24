using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpOnSecondPlatform : MonoBehaviour {

    public float Multiplier;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<MovementUpdated>().moveSpeed *= Multiplier;
            col.GetComponent<MovementUpdated>().runSpeed *= Multiplier;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<MovementUpdated>().moveSpeed /= Multiplier;
            col.GetComponent<MovementUpdated>().runSpeed /= Multiplier;
        }
    }
}
