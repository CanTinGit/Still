using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBookFall : MonoBehaviour {

    public Rigidbody book;
    public Rigidbody obj;
    public Transform movePlatform;
    public void BookFall()
    {
        book.useGravity = true;
        book.isKinematic = false;
        book.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Freeze()
    {
        obj.isKinematic = true;
        obj.transform.parent = movePlatform;
    }
}
