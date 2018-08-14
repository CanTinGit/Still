using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Main water")
        {
            string respawnPoint = "RespawnPoint" + gameObject.GetComponent<MovementUpdated>().PlayerNum.ToString();
            gameObject.transform.position = GameObject.Find(respawnPoint).transform.position;
            gameObject.transform.rotation = GameObject.Find(respawnPoint).transform.rotation;
        }
    }

}
