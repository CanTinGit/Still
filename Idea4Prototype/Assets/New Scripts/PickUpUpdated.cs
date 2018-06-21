using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUpdated : MonoBehaviour
{
    PlayerKeys playerKeys;//the keys for the player
    GameObject icon; //the icon to indicate if the player can pick something uo
    public GameObject picked; //the picked up object
    bool holdingPickUp = false; //indicates if we are holding on a item
    //percentage of how far infront and upwards a object should move based on its size
    float PercentageY = 0.50f;
    float Percentagez = 0.65f;
    //the power of the throw
    public float throwPower = 0.0f;
    //the joint that will be added to the player when the player drags a object
    CharacterJoint characterJoint;
    //the start distance for the player
    float startDistance;
    //the starting angle of the picked up object
    Vector3 startAngle;
    void Awake()
    {       
        //get the keys and stats for the player
        playerKeys = MenuScript.Instance.GetPlayerKeys();
        //get the power of the throw from the player geys
        throwPower = playerKeys.GetThrowPower();
        //Setting up icon for knowing if you can pick up item
        int iconChildIndex = this.gameObject.transform.parent.childCount - 1;
        //set the gameobject icon to the correct child object
        icon = this.gameObject.transform.parent.transform.GetChild(iconChildIndex).transform.gameObject;
    }
    void Update()
    {
        PickUpAndThrowCode(1, playerKeys.GetKeys()[6], playerKeys.GetKeys()[4]);
        PickUpAndThrowCode(2, playerKeys.GetKeys()[6], playerKeys.GetKeys()[4]);  //disabled since no player      
    }

    //the picking up and throwing script
    void PickUpAndThrowCode(int playerNumber_,KeyCode pickUpKey,KeyCode throwKey)
    {
        //this ensures only one player will be moved
        if (transform.parent.GetComponent<MovementUpdated>().PlayerNum == playerNumber_)
        {
            //the pick ups key is pressed
            if (Input.GetKeyDown(pickUpKey))
            {
                //if there is a objects that can be picked up and you are not holding something then pick it up
                if ((picked != null) & (holdingPickUp == false))
                {
                    //set it so the player now is holding something
                    holdingPickUp = true;
                    //turn off the visually icon since we are holding something
                    icon.GetComponent<MeshRenderer>().enabled = false;
                    //if the picked up item is a one of these two then run the script that makes the player carry the object
                    if ((picked.name == "Pickup") || (picked.name =="Bucket"))
                    {
                        //make it kinematic so gravity doesnt effect it
                        picked.GetComponent<Rigidbody>().isKinematic = true;
                        //start invoke repeating to keep the object in front of the object
                        InvokeRepeating("MovePickedUp", 0.0f, 0.01666f);
                    }
                    // if the item picked up is a draggable
                    else if (picked.name == "Drag")
                    {
                        //run the script the picks up the drag item and also attachs the character joint
                        Invoke("DragPickedUp", 0.0f);
                    }
                    //if the object is the lever then run this
                    if (picked.name == "LeverFloor")
                    {
                        //check if the lever has been pulled first and if not then
                        if (picked.GetComponent<ActiveInScene>().GetActive() != true)
                        {
                            //rotate the object based on the distance between player and the lever
                            InvokeRepeating("LeverConnect", 0.0f, 0.01666f);
                            //get the starting distance between the player and the player
                            startDistance = Vector2.Distance(picked.transform.position, this.transform.position);
                            //the starting angle of the object
                            startAngle = picked.transform.eulerAngles;
                        }
                    }
                }
                //this runs when the player is got a object already that he is holding
                else if ((picked != null) & (holdingPickUp == true))
                {
                    //since we are holding something we now drop it
                    holdingPickUp = false;
                    //if the object is a pickup item or a bucket then do this
                    if ((picked.name == "Pickup") || (picked.name == "Bucket"))
                    {
                        //set the kinematic back to false so the object is affected by gravity
                        picked.GetComponent<Rigidbody>().isKinematic = false;
                        //stop the loop of position the pick up item
                        CancelInvoke("MovePickedUp");
                        // set the pick up item to null
                        picked = null;
                    }
                    //destroy the joint if the item is a drag 
                    else if ((picked.name == "Drag") )
                    {
                        Destroy(characterJoint);
                    }
                    //if the object is a lever
                    else if (picked.name == "LeverFloor")
                    {
                        //stop moving the lever
                        CancelInvoke("LeverConnect");
                        //change the distance to the values since we stopped
                        startDistance = Vector2.Distance(picked.transform.position, this.transform.position);
                        //change the start angle since we stopped so we can remember it ( broken right now)
                        startAngle = picked.transform.eulerAngles;
                        //set picked to null since we dropped the object
                        picked = null;
                    }
                }
            }
            //if the key pressed is the throw button
            if (Input.GetKeyDown(throwKey))
            {
                //added the != lever to stop the ability to not throw levers ( MAY CHANGE TO == "Pickup")
                if ((picked != null) && (holdingPickUp == true) && (picked.tag!="Lever"))
                {
                    //set it so we no longer are holding the object
                    holdingPickUp = false;
                    //turn kinematic off so gravity effects the object again
                    picked.GetComponent<Rigidbody>().isKinematic = false;
                    //turn off the movePickedUp script since we are no longer holding the object
                    CancelInvoke("MovePickedUp");
                    //add force forwards and upwards to the picked up object
                    picked.GetComponent<Rigidbody>().AddForce((this.transform.forward + this.transform.up) * (throwPower), ForceMode.VelocityChange);
                    //set the picked to null since we are no longer holding the object
                    picked = null;
                    //if the character joint is present then destroy it since we were holding the object
                    if(characterJoint!=null)
                    {
                        Destroy(characterJoint);
                    }
                }
            }
        }
    }
    //the code which sets the position of the object that is being moved around
    void MovePickedUp()
    {
        //get the distance the object should be in terms of being how far forward infront of the player and how high the object is for the player
        float yDis = this.GetComponent<BoxCollider>().bounds.size.y * PercentageY;
        float zDis = picked.GetComponent<BoxCollider>().bounds.size.z * Percentagez;
        //set the new position based on the percentage of the mesh's dimensions
        picked.transform.position = this.transform.position + (this.transform.forward*zDis) + new Vector3(0.0f,yDis,0.0f);
    }
    //the function which controls the drag
    void DragPickedUp()
    {
        //add a character joint to the picked up object and set up its anchors and the connectors anchors
        characterJoint = picked.AddComponent<CharacterJoint>();
        characterJoint.connectedBody = this.GetComponent<Rigidbody>();
        //set this to false so we can set the anchors ourselves
        characterJoint.autoConfigureConnectedAnchor = false;
        characterJoint.anchor = new Vector3(0, 0, -0.5f);
        characterJoint.connectedAnchor = new Vector3(0, 0.5f, 1.0f);
    }
    //function for when the object interacted with is a lever
    void LeverConnect()
    {
        //get the distance between the object and the player
        float Distance = Vector2.Distance(picked.transform.position, this.transform.position);
        //get the percentage of the start and the new distance
        float percentage = (startDistance - Distance);
        //make sure the percentage is always positive
        if(percentage<0)
        {
            percentage *= -1;
        }
        //how much it is pulled is based on the percentage * the max pull distance
        float Pulled = 40*percentage ;
        //make sure the pulled is never negatuve
        if(Pulled <0)
        {
            Pulled *= -Pulled;
        }
        //change the rotation based on percentage being between 0% - 100%
        if ((percentage > 0.0f) & (percentage < 1.01f))
        {
            picked.transform.GetChild(0).transform.eulerAngles = startAngle - new Vector3(0.0f, 0.0f, Pulled);
        }
        //if we have reached max pull then turn off the lever function and set the lever to being active
        else if(percentage>1.0f)
        {
            picked.GetComponent<ActiveInScene>().setActive(true);
            CancelInvoke("LeverConnect");
            //set objet to null
            picked = null; 
            //since we are no longer holding a object then turn it false
            holdingPickUp = false;
        }
    }

    //when we are on the object then we turn on indicator and make it possible to pick upa  object
    void OnTriggerStay(Collider col)
    {
        //if the object is a pick up 
        if (col.gameObject.tag == "Pickup")
        {
            //only show the indicator if we are not holding something
            if (holdingPickUp!=true)
            {
                icon.GetComponent<MeshRenderer>().enabled = true;
            }
            //if we are not holding something set the picked gameobject so we can pick it up when the key is pressed
            if (holdingPickUp == false)
                picked = col.gameObject;

        }
        //same process but we also only allow interactions if the lever is not being fully pulled
        else if (col.gameObject.tag == "Lever")
        {
            if ((col.GetComponent<ActiveInScene>().GetActive() == false) )
            {
                if (holdingPickUp != true)
                {
                    icon.GetComponent<MeshRenderer>().enabled = true;
                }
                if (holdingPickUp == false)
                    picked = col.gameObject;
            }
        }
    }
    //when we leave the object pick up zone then we do this
    void OnTriggerExit(Collider col)
    {
        //if we leave any object then we turn indicator off and set the object to null if we are not holding something
        if (col.tag == "Pickup")
        {
            icon.GetComponent<MeshRenderer>().enabled = false;
            if(holdingPickUp==false)
            picked = null;
        }
        //same process but with lever
        else if (col.gameObject.tag == "Lever")
        {
            //if the lever is not fully pulled then we do the same thing
            if ((col.GetComponent<ActiveInScene>().GetActive() == false))
            {
                icon.GetComponent<MeshRenderer>().enabled = false;
                if (holdingPickUp == false)
                    picked = null;
            }
        }
    }
}
