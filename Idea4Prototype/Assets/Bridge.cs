using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour {

    public GameObject decal;
    public GameObject bridge;
    GameObject throw_;
    void OnCollisionEnter(Collision col)
    {
        if (col.transform.name == "PickupThrow")
        {
            throw_ = col.gameObject;
            Invoke("RemoveThrowObject", 0.02f);
            this.gameObject.GetComponent<Breakable>().SplitMesh(true);
            bridge.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(decal);
            //Destroy(this.gameObject);           
        }
    }
    void RemoveThrowObject()
    {
        Destroy(throw_.gameObject);
    }

}
