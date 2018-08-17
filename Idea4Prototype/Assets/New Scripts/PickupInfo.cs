using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInfo : MonoBehaviour
{
    GameObject holder;
    GameObject spawnerManager;
    Color originalColor;
    public GameObject onTopOff;
    public bool canAutoSnap = false;
    public bool grounded = false;
    public bool isOnPlatform;
    public bool dontDestroyAfterThrow;
    void Start()
    {
        if (GameObject.Find("SpawnerManager").gameObject.GetComponent<Spawner2>() != null)
        {
            spawnerManager = GameObject.Find("SpawnerManager");
        }
        holder = null;
        //originalColor = this.GetComponent<MeshRenderer>().material.color;
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
                            AkSoundEngine.PostEvent("box_click", gameObject);
                        }
                    }
                }
            }
        }
        if (col.transform.tag == "Ground")
        {
            if (isOnPlatform)
            {
                gameObject.GetComponent<Rigidbody>().mass = 10;
            }
            //Vector3 directionTowardsGrounds = -transform.up;
            //float angle = Vector3.Angle(directionTowardsGrounds, Vector3.down);
            //Debug.Log(angle);
            grounded = true;
        }
        if(this.gameObject.name.Contains("PickupWeight") && col.transform.name.Contains("m_seesaw"))
        {
            AkSoundEngine.PostEvent("weight_plank", gameObject);
        }
        if (gameObject.name.Contains("PickupThrow"))
        {
            if (col.transform.name.Contains("Main water"))
            {
                Destroy(this.gameObject, 3.0f);
            }
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

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (gameObject.GetComponent<PickupInfo>().onTopOff == null)
            {
                Vector3 direction = transform.position + Vector3.up - col.transform.position;
                float degree = Vector3.Angle(direction, Vector3.up);
                Debug.Log(degree);
                if (degree < 75)
                {
                    onTopOff = col.gameObject;
                }
                else if (degree > 75)
                {
                    onTopOff = null;
                }
            }
        }
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
        if(dontDestroyAfterThrow == false)
        {
            Invoke("DestroyObject", timeToDestroyIn_);
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    void OnDestroy()
    {
        if (spawnerManager != null)
        {
            spawnerManager.GetComponent<Spawner2>().num_objects--;
        }
    }
}
