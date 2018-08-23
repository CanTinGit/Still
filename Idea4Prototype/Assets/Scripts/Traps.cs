using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    bool Disabled = false;
    void OnCollisionEnter(Collision col)
    {
        if(Disabled==false)
        {
            if (col.transform.tag == "Pickup")
            {
                Disabled = true;
                GetComponent<MeshRenderer>().material = Resources.Load<Material>("TrapDisabled");
                Destroy(col.gameObject);
            }
        }

    }
    public bool GetDisabled()
    {
        return Disabled;
    }
}
