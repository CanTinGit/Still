using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateIcon : MonoBehaviour {

    bool resetRotation = false;
    public float rotateSpeed;
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(this.GetComponent<MeshRenderer>().enabled == true)
        {
            if (resetRotation == false)
            {
                resetRotation = true;
                this.transform.rotation = Quaternion.identity;
            }
            transform.Rotate(Vector3.up * rotateSpeed);
        }
        else
        {
            if (resetRotation == true)
            {
                resetRotation = false;
            }
        }
        
	}
}
