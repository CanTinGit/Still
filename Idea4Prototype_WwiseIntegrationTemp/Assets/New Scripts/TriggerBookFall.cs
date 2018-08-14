using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBookFall : MonoBehaviour {

    public Rigidbody book;
    public Rigidbody obj;
    public Transform movePlatform;
    public List<GameObject> cubes = new List<GameObject>();
    public void BookFall()
    {
        book.useGravity = true;
        book.isKinematic = false;
        book.transform.GetChild(0).gameObject.SetActive(true);
        book.transform.GetChild(1).gameObject.SetActive(true);
        Invoke("CubesFall", 2.5f);
    }

    void CubesFall()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            cubes[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    public void Freeze()
    {
        obj.isKinematic = true;
        obj.transform.parent = movePlatform;
    }
}
