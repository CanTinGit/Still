using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseControl : MonoBehaviour
{
    public GameObject button;
    void OnCollisionEnter(Collision col)
    {
        if(col.transform.name == "EnableDispense")
        {
            //button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex = 1;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            //button.GetComponent<SpawnObjectButton>().SetCanDispense(false);
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex = 1;
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
