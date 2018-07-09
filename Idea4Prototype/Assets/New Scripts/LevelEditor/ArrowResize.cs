using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowResize : MonoBehaviour {


    GameObject objectInteracted = null;
    string axis;

	void Start ()
    {
        InvokeRepeating("ResizeAndReposition", 0.0f, 0.01667f);
	}
	public void SetObject(GameObject interact_)
    {
        objectInteracted = interact_;
        Debug.Log("set " + interact_);
    }

    public void SetAxis(string axis_)
    {
        axis = axis_;
        Debug.Log("set " + axis_);
    }

    void ResizeAndReposition()
    {   
        Vector3 newScale = Vector3.one * Camera.main.fieldOfView;
        this.transform.localScale = newScale / 2;
        if (objectInteracted != null)
        {
            if(axis == "X")
            {
                this.transform.position = new Vector3(0.0f, (objectInteracted.transform.position.y + this.GetComponent<MeshCollider>().bounds.extents.y), 0.0f);
            }
            if (axis == "Y")
            {
                this.transform.position = new Vector3(0.0f, (objectInteracted.transform.position.y + this.GetComponent<MeshCollider>().bounds.extents.y), 0.0f);
            }
            if (axis == "Z")
            {
                this.transform.position = new Vector3(0.0f, (objectInteracted.transform.position.y + this.GetComponent<MeshCollider>().bounds.extents.y), 0.0f);
            }
        }
            //}
    }
}
