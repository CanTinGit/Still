using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    Rigidbody rb;
    public float speed = 5.0f;
    public float jumpspeed = 8.0f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0F;
    public bool isGrounded;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CharacterControl();
    }

    void CharacterControl()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    moveDirection = gameObject.transform.TransformDirection(Vector3.forward);
        //    rb.AddForce(moveDirection * speed);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    moveDirection = gameObject.transform.TransformDirection(Vector3.left);
        //    rb.AddForce(moveDirection * speed);
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    moveDirection = gameObject.transform.TransformDirection(Vector3.back);
        //    rb.AddForce(moveDirection * speed);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    moveDirection = gameObject.transform.TransformDirection(Vector3.right);
        //    rb.AddForce(moveDirection * speed);
        //}
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);


        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpspeed;
                rb.AddForce(moveDirection * speed);
                isGrounded = false;
            }
        }
    }

    public void setIsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    } 
}
