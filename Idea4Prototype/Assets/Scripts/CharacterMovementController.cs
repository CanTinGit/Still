using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour {

    Rigidbody rb;
    public float speed = 4.0f;
    public float jumpspeed = 8.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0F;
    public bool isGrounded;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        rb.velocity = Vector3.right * Input.GetAxis("Horizontal") * speed;
    }
}
