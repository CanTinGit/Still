using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInfo : MonoBehaviour
{
    GameObject holder;
    Color originalColor;
    public GameObject onTopOff;
    public bool canAutoSnap = false;
    public bool grounded = false;
    void Start()
    {
        holder = null;
        originalColor = this.GetComponent<MeshRenderer>().material.color;
    }
    public void SetHolder(GameObject holder_)
    {
        if (holder != null)
        {
            holder.GetComponent<PickUpUpdated>().LetGoOffItem();
        }
        holder = holder_;
    }
    
    public Color ReturnOriginalColor()
    {
        return originalColor;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<PickupInfo>())
        {
            if (canAutoSnap)
            {
                if (col.gameObject.GetComponent<PickupInfo>().onTopOff == null)
                {
                    if (col.transform.name.Contains("Pickup") && col.transform.tag == "Pickup" && !col.transform.GetComponent<DestroyCollider>())
                    {
                        Vector3 direction = transform.position - col.transform.position;
                        float degree = Vector3.Angle(direction, Vector3.up);
                        if (degree < 75)
                        {
                            transform.position = new Vector3(col.transform.position.x, transform.position.y, col.transform.position.z);
                            //transform.rotation = col.transform.rotation;
                            transform.eulerAngles = new Vector3(transform.eulerAngles.x, col.transform.eulerAngles.y, transform.eulerAngles.z);
                            col.gameObject.GetComponent<PickupInfo>().SetTopOff(gameObject);
                            gameObject.GetComponent<PickupInfo>().SetGrounded(true);
                        }
                    }
                }
            }
        }
        if (col.transform.tag == "Ground")
        {
            //Vector3 directionTowardsGrounds = -transform.up;
            //float angle = Vector3.Angle(directionTowardsGrounds, Vector3.down);
            //Debug.Log(angle);
            grounded = true;
        }
        //else if(col.transform.name.Contains("Pickup") && col.transform.tag == "Pickup" && col.transform.GetComponent<PickupInfo>().GetGrounded()==true)
        //{
        //    Debug.Log("herekfafas");
        //    grounded = true;
        //}
        //    if (col.transform.name == "Main water (1)")
        //    {
        //        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //    }
    }
    
    void OnCollisionExit(Collision col)
    {
        if(onTopOff == col.gameObject)
        {
            onTopOff = null;
        }
        if (col.transform.tag == "Ground")
        {
            grounded = false;
        }
    }

    public void SetTopOff(GameObject onTopOff_)
    {
        onTopOff = onTopOff_;
    }

    public void SetCanAutoSnapTrue()
    {
        canAutoSnap = true;
        Invoke("SetCanAutoSnapOff", 1.0f);
    }

    void SetCanAutoSnapOff()
    {
        canAutoSnap = false;
    }

    public void SetGrounded(bool grounded_)
    {
        grounded = grounded_;
    }
    public bool GetGrounded()
    {
        return grounded;
    }
    public GameObject GetHolder()
    {
        return holder;
    }
    public void SetDestroyActive(float timeToDestroyIn_)
    {
        Invoke("DestroyObject", timeToDestroyIn_);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
