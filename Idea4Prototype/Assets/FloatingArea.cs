using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingArea : MonoBehaviour {

    public Vector3 settingVelocity;
    public float speed;

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Pickup")
        {
            col.GetComponent<Rigidbody>().velocity = settingVelocity;
            col.transform.rotation = Quaternion.RotateTowards(col.transform.rotation, Quaternion.identity, speed * Time.deltaTime);
        }
    }
}
