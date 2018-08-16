using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float moveSpeed;
    float deSpawnTime = 5.0f;
    Transform target;
    // If the bullet doesn't hit anything, then destroyed after deSpawnTime seconds
    void Start ()
    {
        Invoke("DestroyBullet", deSpawnTime);
	}
	
	// Bullet updates its position to simulate fly
	void FixedUpdate ()
    {
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    //Hit player and add a InBubble script to it to make player in bubble state
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (col.GetComponent<MovementUpdated>().isInBubble == false)
            {
                // Make the player in Bubble
                col.GetComponent<MovementUpdated>().isInBubble = true;
                col.gameObject.AddComponent<InBubble>();
                Destroy(gameObject);
            }
        }
    }

    //Destroy bullet function
    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void ResetCamera()
    {

    }
}
