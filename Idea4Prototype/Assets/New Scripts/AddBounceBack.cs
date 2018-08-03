using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBounceBack : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (col.gameObject.GetComponent<Respawn>() == null)
            {
                col.gameObject.AddComponent<Respawn>();
            }
        }
    }
}
