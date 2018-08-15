using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float padStrength;//the strength of the force applied to the player when he enters the jump pad

    void OnTriggerEnter(Collider col)
    {
        //when the collider is the player then launch him into the air
        if (col.tag == "Player")
        {
            //add force to the player based on the padStrength
            col.GetComponent<Rigidbody>().velocity = Vector3.up * padStrength;
            //change the float value that is recorded by the player ( we dont want to record this as we want to keep a record of the velocity when the player is falling only)
            col.GetComponent<MovementUpdated>().ChangeVelocity(0.0f);
        }
    }
}
