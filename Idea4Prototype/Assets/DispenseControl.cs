using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseControl : MonoBehaviour
{
    public GameObject button;
    void OnCollisionEnter(Collision col)
    {
        if(col.transform.name == "EnableDispense")
        {
            button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
            Debug.Log("trigger block in dispense");
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            button.GetComponent<SpawnObjectButton>().SetCanDispense(false);
        }
    }


    void OnCollisionStay(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            if (button.GetComponent<SpawnObjectButton>().GetDispense()==false)
            button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
            Debug.Log("trigger block in dispense");
        }
    }
}
