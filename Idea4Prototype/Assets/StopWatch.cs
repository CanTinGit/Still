using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 5.0f);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag =="Player")
        {
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().AddTimer(0, 0, 3, 0);
            Destroy(this.gameObject);
        }
    }
}
