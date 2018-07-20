using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInfo :MonoBehaviour
{
    GameObject holder;
    Color originalColor;
    void Start()
    {
        holder = null;
        originalColor = this.GetComponent<MeshRenderer>().material.color;
    }
    public void SetHolder(GameObject holder_)
    {
        Debug.Log("test");
        if(holder!=null)
        {
            holder.GetComponent<PickUpUpdated>().LetGoOffItem();
        }
        holder = holder_;
    }

    public Color ReturnOriginalColor()
    {
        return originalColor;
    }

    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.transform.name == "Main water (1)")
    //    {
    //        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //    }
    //}
}
