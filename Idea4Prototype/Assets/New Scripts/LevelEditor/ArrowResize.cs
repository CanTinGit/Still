using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowResize : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Resize", 0.0f, 0.01667f);
	}
	
	// Update is called once per frame
	void Resize ()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            
            //this.transform.localscale += 1.0f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            //if(this.transform.localscale.x>1.0f)
            //this.transform.localscale -= 1.0f;
        }
    }
}
