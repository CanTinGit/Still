using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject[] m_object;          // References to the different object to spawn.
    public int num_objects;                  // the number of objects already in the instance.
    public float spawnTime;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int max_objects;                    // The max number of objects allowed to be in the level at a single time.
    public bool canSpawn = true;
    public bool setToNumPlayers;
    public bool unlimited;
    public int spawnPointIndex;
    void Start()
    {
        if (setToNumPlayers == true)
        {
            max_objects = MenuScript.Instance.GetNumberofPlayers();
        }
        spawnPointIndex = 0;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        // InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {/*
        for (int x = 0; x == num_objects; x++)
        {
            Debug.Log(x);
            m_object[x].GetComponent<Rigidbody>().mass = m_object[x].GetComponent<Rigidbody>().mass / MenuScript.Instance.GetNumberofPlayers();
        }*/
    }


    public void Spawn()
    {
        if(canSpawn)
        {
            canSpawn = false;
            // If too many numbers are in the scene.
            if (num_objects >= max_objects)
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            //int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // Find a random index between zero and one less than the number of player_shirts.
            int objectIndex = Random.Range(0, m_object.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            GameObject weight = Instantiate(m_object[objectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            weight.name = "PickupWeight";
            if (spawnPointIndex == 1)
            {
                weight.layer = 0;
            }
            //weight.GetComponent<Rigidbody>().mass = m_object[objectIndex].GetComponent<Rigidbody>().mass / MenuScript.Instance.GetNumberofPlayers();
            num_objects = num_objects + 1;
            AkSoundEngine.PostEvent("weight_drop_trigger", gameObject);
            if(unlimited)
            {
                max_objects++;
            }
        }

    }
    public void SpawnTrue()
    {
        canSpawn = true;
    }
    public void SpawnFalse()
    {
        canSpawn = false;
    }
}
