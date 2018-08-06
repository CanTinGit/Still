using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounckBack : MonoBehaviour {

    public List<Vector3> position = new List<Vector3>();
    public int cur;
    public bool isStartRecord;
    GameObject distanceTowards;
    float speed = 5;
	// Use this for initialization
	void Start ()
    {
        isStartRecord = false;
    }

    void RecordPosition()
    {
        if(this.transform.GetComponent<MovementUpdated>().isMoving==true)
        {
            position.Add(transform.position);
        }
    }

    void Rewind()
    {
        if (cur > position.Count - 1)
        {
            CancelInvoke();
            cur = 0;
            Invoke("DelayTurnOff", 0.0f);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            return;
        }
        if (cur <= 0)
        {
            Debug.Log("Finish");
            CancelInvoke("Rewind");
            cur = 0;
            gameObject.GetComponent<Rigidbody>().velocity = (distanceTowards.transform.position - gameObject.transform.position).normalized * speed;
            Invoke("DelayTurnOff", 0.3f);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
        transform.position = position[cur] + Vector3.up * 0.1f;
        //if (cur > 10)
        //{
        //    transform.position = Vector3.Slerp(transform.position, position[cur], 0.5f);
        //}
        //else if (cur > 3)
        //{
        //    transform.position = Vector3.Slerp(transform.position, position[cur], 0.5f);
        //}
        //else
        //{
        //    transform.position = position[cur];
        //}

        cur--;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Main water")
        {
            Debug.Log(" first time " + cur + " the max is " + position.Count);
            CancelInvoke("RecordPosition");
            gameObject.GetComponent<MovementUpdated>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            cur = position.Count - 1;
            InvokeRepeating("Rewind", 0.0f, 0.01666f);
        }
        else
        {
            distanceTowards = col.gameObject;
        }

    }

    void OnTriggerExit(Collider col)
    {
        
        //if (isStartRecord == false && col.tag=="Bounce")
        //{
        //    InvokeRepeating("RecordPosition", 0.0f, 0.01667f);
        //    isStartRecord = true;
        //}
    }
    // Update is called once per frame
    void Update ()
    {
        if (gameObject.GetComponent<MovementUpdated>().GetGrounded() == false && isStartRecord == false)
        {
            InvokeRepeating("RecordPosition", 0.0f, 0.05f);
            isStartRecord = true;
        }
        else if (gameObject.GetComponent<MovementUpdated>().GetGrounded() == true || gameObject.GetComponent<MovementUpdated>().isInBubble == true)
        {
            if (position.Count != 0)
            {
                isStartRecord = false;
                Debug.Log("this is run clear");
                //CancelInvoke();
                position.Clear();
            }
        }	
	}

    void DelayTurnOff()
    {
        //if (position.Count != 0)
        //{
        //    isStartRecord = false;
        //    Debug.Log("this is run clear");
        //    CancelInvoke();
        //    position.Clear();
        //}
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<MovementUpdated>().enabled = true;
        gameObject.GetComponent<MovementUpdated>().SetGround(false);
        isStartRecord = false;
        position.Clear();
    }
    /*
     
    2 colliders - bounce record , ground
    1 bool - isstarrrecord( not record when recording), is rewinding - to check if rewinding
  //  1 enum - state - record,rewind,none


   // state - 
  //  =record - we are recording movement
  //  =rewind - we going through the list of position
  //  = none - you can move

    is rewinding - if he rewinding and touchs the ground then re-enable movement

    when we touch the ground - clear the record




     
     
     
    */
    
}
