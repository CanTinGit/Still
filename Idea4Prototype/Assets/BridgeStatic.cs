using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeStatic : MonoBehaviour {

    public string collisionName;
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == collisionName)
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        if(col.transform.name == "PickupThrow" && this.gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            Destroy(col.gameObject);
        }
    }
}
