using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseControl : MonoBehaviour
{
    public GameObject button;
    public GameObject firstSpawnLight;
    public GameObject secondSpawnLight;
    void OnCollisionEnter(Collision col)
    {
        if(col.transform.name == "EnableDispense")
        {
            //button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex = 1;
            firstSpawnLight.GetComponent<MeshRenderer>().material.color = Color.red;
            secondSpawnLight.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            //button.GetComponent<SpawnObjectButton>().SetCanDispense(false);
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex = 0;
            firstSpawnLight.GetComponent<MeshRenderer>().material.color = Color.green;
            secondSpawnLight.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }


    void OnCollisionStay(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            if (button.GetComponent<SpawnObjectButton>().GetDispense()==false)
            button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
        }
    }
}
