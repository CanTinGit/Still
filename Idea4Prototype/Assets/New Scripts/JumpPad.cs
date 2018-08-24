using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float padStrength;//the strength of the force applied to the player when he enters the jump pad
    public float maxHeight;
    public GameObject aircon;
    public float minHeight;
    void OnTriggerStay(Collider col)
    {
        //when the collider is the player then launch him into the air
        if (col.tag == "Player")
        {
            //add force to the player based on the padStrength
            //col.GetComponent<Rigidbody>().velocity = Vector3.up * padStrength;
            float distance = col.transform.position.y - aircon.transform.position.y;
            if (distance < minHeight && col.GetComponent<Rigidbody>().velocity.y < -1)
            {
                col.GetComponent<Rigidbody>().velocity = Vector3.Lerp(col.GetComponent<Rigidbody>().velocity, Vector3.zero, 10 * Time.deltaTime);
            }
            if (distance > maxHeight && col.GetComponent<Rigidbody>().velocity.y > 1)
            {
                col.GetComponent<Rigidbody>().velocity = Vector3.Lerp(col.GetComponent<Rigidbody>().velocity, Vector3.zero, 10 * Time.deltaTime);
            }
            Debug.Log(distance);
            col.GetComponent<Rigidbody>().AddForce(Vector3.up * padStrength /distance, ForceMode.Acceleration);
            //if(col.transform.position.y>= maxHeight)
            //{
            //    col.transform.position = new Vector3(col.transform.position.x, maxHeight, col.transform.position.z);
            //    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //}

            //if(col.transform.position.y < (this.transform.position.y + this.GetComponent<BoxCollider>().bounds.size.y/2+maxHeight))
            //{
            //    col.transform.position += Vector3.up * padStrength * Time.deltaTime;
            //}
            //change the float value that is recorded by the player ( we dont want to record this as we want to keep a record of the velocity when the player is falling only)
           // col.GetComponent<MovementUpdated>().ChangeVelocity(0.0f);
        }
    }
    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "Player")
    //    {
    //        //add force to the player based on the padStrength
    //        col.GetComponent<Rigidbody>().velocity = Vector3.up * padStrength;
    //        //col.GetComponent<Rigidbody>().AddForce(Vector3.up * padStrength, ForceMode.Acceleration);
    //        //change the float value that is recorded by the player ( we dont want to record this as we want to keep a record of the velocity when the player is falling only)
    //        col.GetComponent<MovementUpdated>().ChangeVelocity(0.0f);
    //    }
    //}
}
