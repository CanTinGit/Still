using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{

    void FixedUpdate()
    {
        //rotate the object on y axis every frame
        transform.Rotate(Vector3.up, 5.0f);
    }
    void OnTriggerEnter(Collider col)
    {
        //when the player collider enters this trigger
        if(col.tag =="Player")
        {
            //increase the amount of collectables obtained
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreSystem>().IncreaseCollectable();
            //destroy this object since it has been picked up
            Destroy(this.gameObject);
        }
    }
}
