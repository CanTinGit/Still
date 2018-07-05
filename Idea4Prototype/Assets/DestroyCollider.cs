using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Breakable>() != null)          //If the object the ball is collidiing with has the "Breakable" script attached
        {
            StartCoroutine(other.gameObject.GetComponent<Breakable>().SplitMesh(true));     // Split/ Smash the colliding object
        }
    }
}
