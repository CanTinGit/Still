using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public Object[] m_object;          // References to the different shirts to spawn.
    public int num_objects;                  // the number of shirts already in the instance.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int max_objects = 10;                    // The max number of shirts allowed to be in the level at a single time.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // If too many numbers are in the scene.
        if (num_objects >= max_objects)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        // Find a random index between zero and one less than the number of player_shirts.
        int objectIndex = Random.Range(0, m_object.Length);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject throwObject = Instantiate(m_object[objectIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation) as GameObject;
        throwObject.name = "PickupThrow";
        num_objects = num_objects + 1;
    }
}
