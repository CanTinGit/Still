using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCanBeDragged : MonoBehaviour {

    public float Fuerza = 4000;
    Rigidbody rb;
    bool tomado = false;
    public bool picking = false;
    public bool isSpExist = false;
    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //picking = false;
    }

    void OnTriggerStay(Collider col)
    {
        if (!tomado && picking)
        {
            if (col.gameObject.tag == "Hand")
            {
                
                //CharacterJoint sp = gameObject.AddComponent<CharacterJoint>();
                //sp.connectedBody = col.gameObject.GetComponent<Rigidbody>() ;
                //sp.autoConfigureConnectedAnchor = false;
                //sp.anchor = new Vector3(0, 0, 0.5f);
                //if (col.gameObject.name == "Hand")
                //{
                //    sp.connectedAnchor = new Vector3(0, 0.3f, 0.72f);
                //}

                //else if (col.gameObject.name == "Hand2")
                //{
                //    sp.connectedAnchor = new Vector3(0, 0.3f, -0.72f);
                //}

                //sp.breakForce = Mathf.Infinity;
                //tomado = true;
                //isSpExist = true;
            }

        }
    }
    void OnJointBreak()
    {
        tomado = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (isSpExist == true && picking == false)
        {
            //CharacterJoint sp = gameObject.GetComponent<CharacterJoint>();
            //Destroy(sp);
        }
    }
}
