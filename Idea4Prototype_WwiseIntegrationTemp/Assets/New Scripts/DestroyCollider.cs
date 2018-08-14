using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour {

    public float breakableMagnitude;

    void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
           // Debug.Log(other.gameObject.GetComponent<Rigidbody>().velocity.magnitude);
            if (other.gameObject.GetComponent<Breakable>() != null && other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > breakableMagnitude)          //If the object the ball is collidiing with has the "Breakable" script attached
            {
                StartCoroutine(other.gameObject.GetComponent<Breakable>().SplitMesh(true));     // Split/ Smash the colliding object
            }
        }
        else
        {
            if(other.gameObject.GetComponent<Breakable>() != null)
            {
                StartCoroutine(other.gameObject.GetComponent<Breakable>().SplitMesh(true));
            }
        }
    }
}
