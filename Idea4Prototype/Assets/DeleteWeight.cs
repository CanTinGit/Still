using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWeight : MonoBehaviour {
    public GameObject mButton;
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("Enter1");
        if (col.tag == "Weight")
        {
            //Debug.Log("Enter2");
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().SpawnTrue();
            mButton.GetComponent<SpawnObjectButton>().audioPlayed = false;
            Destroy(col.gameObject);
        }
    }
}
