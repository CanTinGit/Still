using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounckBack : MonoBehaviour {

    public List<Vector3> position = new List<Vector3>();
    int cur;
    bool isStartRecord;
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
        Debug.Log(cur + " the max is " + position.Count);
        transform.position = position[cur];
        cur--;
        if (cur <= 0)
        {
            Debug.Log("Finish" );
            CancelInvoke("Rewind");
            Invoke("DelayTurnOff", 0.2f);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
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
            InvokeRepeating("Rewind", 0.0f, 0.02f);
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
            InvokeRepeating("RecordPosition", 0.0f, 0.01667f);
            isStartRecord = true;
        }
        else if (gameObject.GetComponent<MovementUpdated>().GetGrounded() == true )
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
        gameObject.GetComponent<MovementUpdated>().enabled = true;
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
