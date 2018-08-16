using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityBody : MonoBehaviour {


    public GameObject attractedTo;
    public float strengthOfAttraction = 5.0f;
    public Rigidbody rb;

    public bool canBeAttracted = false;
    public bool holding = false;


    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (attractedTo == null)
        {
            return;
        }
        if (attractedTo.GetComponent<gravityBody>().holding == true)
        {
            attractedTo = null;
        }
        if (holding == false && canBeAttracted == true && attractedTo != null)
        {
            Vector3 direction = attractedTo.transform.position - transform.position;
            rb.AddForce(strengthOfAttraction * direction);
        }


     }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "Pickup")
        {
            attractedTo = col.gameObject;
            Invoke("CheckIfBounced", 1.0f);
        }
    }

    void CheckIfBounced()
    {
        if (attractedTo != null)
        {
            if (Vector3.Distance(attractedTo.transform.position, this.gameObject.transform.position) < 3.0f)
            {
                canBeAttracted = true;
            }
            else
            {
                canBeAttracted = false;
            }
        }

    }

    public void SetPicked(bool holding_)
    {
        holding = holding_;
        if (holding == true)
        {
            attractedTo = null;
        }
    }

    public void SetAttracted(GameObject attracted_)
    {
        attractedTo = attracted_;
    }
 }

