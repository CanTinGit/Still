using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInfo :MonoBehaviour
{
    GameObject holder;
    void Start()
    {
        holder = null;
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
}
