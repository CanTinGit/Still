using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtons : MonoBehaviour
{
    public GameObject button1, button2;
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "Hammer")
        {
            button1.GetComponent<PressedButton>().enabled = true;
            button2.GetComponent<PressedButton>().enabled = true;
        }
    }

}
