using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWeight : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Enter1");
        if (col.tag == "Weight")
        {
            Debug.Log("Enter2");
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().SpawnTrue();
            Destroy(col.gameObject);
        }
    }
}
