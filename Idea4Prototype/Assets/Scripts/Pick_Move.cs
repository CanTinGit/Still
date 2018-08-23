using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Move : MonoBehaviour
{
    public GameObject picked;
    bool detectedPickUp = false;
    public bool Holding = false;
    bool AddCom = false;
    float PercentageY = 0.35f;
    float Percentagez = 0.80f;
    public int forcePower;
    bool Joint = false;
    CharacterJoint sp = null;

    // Use this for initialization
    void Start()
    {
        //this.gameObject.AddComponent<SpringJoint>
    }

    // Update is called once per frame
    void Update()
    {
        if (detectedPickUp == true && (Holding == false))
        {
            GameObject.Find("Icon").GetComponent<MeshRenderer>().enabled = true;
            if (transform.parent.GetComponent<TempMove>().PlayerNum == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Holding = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    Holding = true;
                }
            }

        }
        else if (detectedPickUp == false || (Holding == true))
        {
            GameObject.Find("Icon").GetComponent<MeshRenderer>().enabled = false;
            if (transform.parent.GetComponent<TempMove>().PlayerNum == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Holding = false;
                    if (picked != null)
                    {
                        if (picked.name == "Pickup")
                        {
                            picked.GetComponent<Rigidbody>().useGravity = true;
                            picked = null;
                        }
                        else
                        {
                            picked.transform.parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            picked.transform.parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                            picked = null;
                            Destroy(sp);
                            Joint = false;
                        }
                    }

                }
            }
            if (transform.parent.GetComponent<TempMove>().PlayerNum == 2)
            {
                if (Input.GetKeyDown(KeyCode.Keypad1))
                {
                    Holding = false;
                    if (picked != null)
                    {
                        if (picked.name == "Pickup")
                        {
                            picked.GetComponent<Rigidbody>().useGravity = true;
                            picked = null;
                        }
                        else
                        {
                            picked = null;
                            Destroy(sp);
                            Joint = false;
                        }
                    }

                }
            }
        }

    }
    void FixedUpdate()
    {
        if (Holding == true)
        {
            Vector3 pos;
            if (picked.name == "Pickup")
            {
                float yDis = this.GetComponent<BoxCollider>().bounds.size.y * PercentageY;
                float zDis = picked.GetComponent<BoxCollider>().bounds.size.z * Percentagez;
                if (transform.name == "Hand")
                {
                    pos = new Vector3(this.transform.position.x, this.transform.position.y + yDis, this.transform.position.z + zDis);
                }
                else
                {
                    pos = new Vector3(this.transform.position.x, this.transform.position.y + yDis, this.transform.position.z - zDis);
                }
                picked.GetComponent<Rigidbody>().useGravity = false;
                //picked.transform.position = pos + Vector3.back*10;
                picked.transform.position = pos;
                //picked.transform.Translate(Vector3.forward * -1);
                if (transform.parent.GetComponent<TempMove>().PlayerNum == 1)
                {
                    if (Input.GetKeyDown(KeyCode.B))
                    {
                        Holding = false;
                        picked.GetComponent<Rigidbody>().useGravity = true;
                        picked.GetComponent<Rigidbody>().AddForce(Vector3.back * forcePower, ForceMode.Impulse);
                        picked.GetComponent<Rigidbody>().AddForce(Vector3.up * forcePower, ForceMode.Impulse);
                        picked = null;

                    }
                }
                if (transform.parent.GetComponent<TempMove>().PlayerNum == 2)
                {
                    if (Input.GetKeyDown(KeyCode.Keypad2))
                    {
                        Holding = false;
                        picked.GetComponent<Rigidbody>().useGravity = true;
                        if (transform.name == "Hand2")
                        {
                            picked.GetComponent<Rigidbody>().AddForce(Vector3.back * forcePower, ForceMode.Impulse);
                            picked.GetComponent<Rigidbody>().AddForce(Vector3.up * forcePower, ForceMode.Impulse);
                        }
                        else
                        {
                            picked.GetComponent<Rigidbody>().AddForce(Vector3.forward * forcePower, ForceMode.Impulse);
                            picked.GetComponent<Rigidbody>().AddForce(Vector3.up * forcePower, ForceMode.Impulse);
                        }

                        picked = null;

                    }
                }
            }
            if (picked != null)
            {
                if ((picked.name == "Cube1") || (picked.name == "Cube2"))
                {
                    if (Joint == false)
                    {
                        Joint = true;
                        sp = picked.AddComponent<CharacterJoint>();
                        sp.connectedBody = this.gameObject.GetComponent<Rigidbody>();
                        sp.autoConfigureConnectedAnchor = false;
                        sp.anchor = new Vector3(0, 0, 0.5f);
                        if (this.gameObject.name == "Hand")
                        {
                            sp.connectedAnchor = new Vector3(0, 0.3f, 0.72f);
                        }

                        else if (this.gameObject.name == "Hand2")
                        {
                            sp.connectedAnchor = new Vector3(0, 0.3f, -0.72f);
                        }
                        sp.breakForce = Mathf.Infinity;
                    }
                }

                if ((picked.name == "Cylinder1") || (picked.name == "Cylinder2"))
                {
                    if (Joint == false)
                    {
                        Joint = true;
                        sp = picked.AddComponent<CharacterJoint>();
                        sp.connectedBody = this.gameObject.GetComponent<Rigidbody>();
                        sp.autoConfigureConnectedAnchor = false;
                        sp.anchor = new Vector3(0, -1, 0.0f);
                        if (this.gameObject.name == "Hand")
                        {
                            sp.connectedAnchor = new Vector3(0, -1.21f, 0.21f);
                        }

                        else if (this.gameObject.name == "Hand2")
                        {
                            sp.connectedAnchor = new Vector3(0, 0.3f, -0.72f);
                        }
                        SoftJointLimit temp = new SoftJointLimit();
                        temp.limit = 0.0f;
                        sp.swing1Limit = temp;
                        sp.swing2Limit = temp;
                        sp.breakForce = Mathf.Infinity;
                    }
                }

                if (picked.name == "CylinderSide")
                {
                    if (Joint == false)
                    {
                        Joint = true;
                        sp = picked.AddComponent<CharacterJoint>();
                        sp.connectedBody = this.gameObject.GetComponent<Rigidbody>();
                        sp.autoConfigureConnectedAnchor = false;
                        sp.anchor = new Vector3(0, -1, 0.0f);
                        if (this.gameObject.name == "Hand")
                        {
                            sp.connectedAnchor = new Vector3(0, -1.21f, 0.21f);
                        }

                        else if (this.gameObject.name == "Hand2")
                        {
                            sp.connectedAnchor = new Vector3(0, 0.3f, -0.72f);
                        }
                        SoftJointLimit temp = new SoftJointLimit();
                        temp.limit = 0.0f;
                        sp.swing1Limit = temp;
                        sp.swing2Limit = temp;
                        sp.breakForce = Mathf.Infinity;
                    }
                }
            }
        }
    }
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            detectedPickUp = true;
            if (Holding == false)
            {
                picked = col.gameObject;
            }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Pickup")
        {
            detectedPickUp = false;
            if (Holding == false)
            {
                picked = null;
            }
        }
    }
}
