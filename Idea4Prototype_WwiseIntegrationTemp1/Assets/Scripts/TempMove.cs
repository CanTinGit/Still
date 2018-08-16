using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMove : MonoBehaviour {

    Rigidbody rb;
    public float jumpspeed = 8.0f;
    bool grounded = false;
    public int PlayerNum;
    Vector3 startPos;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(PlayerNum==1)
        {
            if (Input.GetKey(KeyCode.D))
            {
                this.transform.Translate(0.0f, 0.0f, 5.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                this.transform.Translate(-5.0f * Time.deltaTime, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.Translate(0.0f, 0.0f, -5.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                this.transform.Translate(5.0f * Time.deltaTime, 0.0f, 0.0f);
            }
            if (grounded)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    //Vector3 moveDirection = new Vector3();
                    //moveDirection.y =
                    this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 45.0f, ForceMode.Impulse);
                    //rb.AddForce(moveDirection * speed);
                }
            }
        }
        if (PlayerNum == 2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                this.transform.Translate(0.0f, 0.0f, 5.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                this.transform.Translate(-5.0f * Time.deltaTime, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.transform.Translate(0.0f, 0.0f, -5.0f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                this.transform.Translate(5.0f * Time.deltaTime, 0.0f, 0.0f);
            }
            if (grounded)
            {
                if (Input.GetKeyDown(KeyCode.Keypad0))
                {
                    //Vector3 moveDirection = new Vector3();
                    //moveDirection.y =
                    this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpspeed, ForceMode.Impulse);
                    //rb.AddForce(moveDirection * speed);
                }
            }
        }


    }
    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Goal")
        {
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag=="Traps")
        {
            if(col.gameObject.GetComponent<Traps>().GetDisabled()==false)
            transform.position = startPos;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
