using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBetterFalling : MonoBehaviour {

    float fallMultiplier;
    float lowJumpMultiplier;
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        fallMultiplier = 1.5f;
        lowJumpMultiplier = 2.0f;
    }

    // Update is called once per frame
    void Update ()
    {

        if (rigidbody.velocity.y < 0 && rigidbody.useGravity == true)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; //1.5
        }
        else if (rigidbody.velocity.y > 0 && rigidbody.useGravity == true)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; //2
        }

    }
}
