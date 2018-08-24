using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpUpdated : MonoBehaviour
{
    PlayerKeys[] playerKeys;//the keys for the player
    GameObject icon; //the icon to indicate if the player can pick something uo
    public GameObject throwArc;     //Throw arc
    public GameObject picked; //the picked up object
    public bool holdingPickUp = false; //indicates if we are holding on a item
    //percentage of how far infront and upwards a object should move based on its size
    public float PercentageY = 0.30f;
    public float Percentagez = 0.5f;
    //the power of the throw
    //public float throwPower = 0.0f;
    //the joint that will be added to the player when the player drags a object
    CharacterJoint characterJoint;
    //the start distance for the player
    float startDistance;
    //the starting angle of the picked up object
    Vector3 startAngle;
    int maxPlayer;
    // Boolean to control if player can throw, defaulted to true
    public bool canThrow = true;
    GameObject colliderStopWall;
    Color playerColor;

    //Setting of throw
    public float maxVelocity,minVelocity, currentVelocity,offsetVelocity;
    public float angle;
    public int resolution;          //Decide how accuracy of the line
    float offsetRotation;
    bool Controller; // if you dont have a controller use the keys instead
    int playerNum;
    int highlightedObject;
    void Awake()
    {
        //playerColor = this.transform.parent.GetComponent<MeshRenderer>().material.color;
        Controller = true;
        //get the keys and stats for the player
        playerKeys = MenuScript.Instance.GetPlayerKeys();
        //get the power of the throw from the player geys
        //throwPower = playerKeys.GetThrowPower();
        //Setting up icon for knowing if you can pick up item
        int iconChildIndex = this.gameObject.transform.parent.childCount - 1;
        int iconChildChildIndex = this.gameObject.transform.parent.transform.GetChild(iconChildIndex).transform.childCount- 1;
        //set the gameobject icon to the correct child object
        icon = this.gameObject.transform.parent.transform.GetChild(iconChildIndex).GetChild(iconChildChildIndex).transform.gameObject;
        //Get the throw arc
        throwArc = gameObject.transform.parent.transform.GetChild(iconChildIndex - 2).transform.gameObject;
        colliderStopWall = gameObject.transform.parent.transform.GetChild(iconChildIndex - 1).transform.gameObject;
        colliderStopWall.SetActive(false);
        currentVelocity = minVelocity;
        maxPlayer = MenuScript.Instance.GetNumberofPlayers();
        playerNum = this.transform.parent.GetComponent<MovementUpdated>().PlayerNum;
    }
    void Update()
    {
        if (Controller)
        {
            // PickUpAndThrowCode(1, playerKeys.GetKeys()[6].ToString().Insert(8,"1"), playerKeys.GetKeys()[4].ToString().Insert(8, "1"));
            PickUpAndThrowCode(playerNum, playerKeys[0].GetKeys()[6].ToString().Insert(8, playerNum.ToString()), playerKeys[0].GetKeys()[4].ToString().Insert(8, playerNum.ToString()), playerKeys[0].GetThrowPower());
            //if (maxPlayer>1)
            {
              //  PickUpAndThrowCode(2, playerKeys[1].GetKeys()[6].ToString().Insert(8, "2"), playerKeys[1].GetKeys()[4].ToString().Insert(8, "2"), playerKeys[1].GetThrowPower());
            }
            //if (maxPlayer > 2)
            {
               // PickUpAndThrowCode(3, playerKeys[2].GetKeys()[6].ToString().Insert(8, "3"), playerKeys[2].GetKeys()[4].ToString().Insert(8, "3"), playerKeys[2].GetThrowPower());
            }
            //if (maxPlayer > 3)
            {
               // PickUpAndThrowCode(4, playerKeys[3].GetKeys()[6].ToString().Insert(8, "4"), playerKeys[3].GetKeys()[4].ToString().Insert(8, "4"), playerKeys[3].GetThrowPower());
            }
        }
        ////probably remove this and controller once we are done
        //else
        //{
        //    // PickUpAndThrowCode(1, playerKeys.GetKeys()[6].ToString().Insert(8,"1"), playerKeys.GetKeys()[4].ToString().Insert(8, "1"));
        //    PickUpAndThrowCodeNoController(1, playerKeys[0].GetKeys()[6], playerKeys[0].GetKeys()[4], playerKeys[0].GetThrowPower());
        //    //if (maxPlayer>1)
        //    {
        //        PickUpAndThrowCodeNoController(2, playerKeys[1].GetKeys()[6], playerKeys[1].GetKeys()[4], playerKeys[1].GetThrowPower());
        //    }
        //    //if (maxPlayer > 2)
        //    {
        //        PickUpAndThrowCodeNoController(3, playerKeys[2].GetKeys()[6], playerKeys[2].GetKeys()[4], playerKeys[2].GetThrowPower());
        //    }
        //    //if (maxPlayer > 3)
        //    {
        //        PickUpAndThrowCodeNoController(4, playerKeys[3].GetKeys()[6], playerKeys[3].GetKeys()[4], playerKeys[3].GetThrowPower());
        //    }
        //}


    }

    //the picking up and throwing script
    void PickUpAndThrowCode(int playerNumber_,string pickUpKey,string throwKey,float throwPower_)
    {
        if (MenuScript.Instance.gamePaused == false)
        {
            //this ensures only one player will be moved
            if (transform.parent.GetComponent<MovementUpdated>().PlayerNum == playerNumber_)
            {
                //the pick ups key is pressed
                if (Input.GetButtonDown(pickUpKey.ToString()))
                {
                    
                    //if there is a objects that can be picked up and you are not holding something then pick it up

                    if ((picked != null) && (holdingPickUp == false))
                    {
                        if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                        {
                            gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", true);
                        }
                        //set it so the player now is holding something
                        holdingPickUp = true;
                        //plays lift sound
                        AkSoundEngine.SetState("Nationality", MenuScript.Instance.GetAudioClass().GetNationality(this.gameObject.transform.parent.GetComponent<MovementUpdated>().PlayerNum));
                        AkSoundEngine.PostEvent("player_lift", gameObject);
                        //turn off the visually icon since we are holding something
                        icon.GetComponent<MeshRenderer>().enabled = false;
                        //if the picked up item is a one of these two then run the script that makes the player carry the object
                        if ((picked.name.Contains("Pickup")) || (picked.name.Contains("Bucket")))
                        {
                            //return the color of the picked object back to its original color when picked up
                            if (picked.GetComponent<gravityBody>())
                            {
                                picked.GetComponent<gravityBody>().SetPicked(true);
                            }
                            Percentagez = 0.21f;                // Default holding distance is for dice sized cubes,
                            PercentageY = -0.2f;
                            if (picked.name.Contains("Rubix"))   // If its a rubix sized pickup
                            {
                                Percentagez = 0.45f;            // change holding distance to 0.45f
                            }
                           
                            //picked.GetComponent<MeshRenderer>().material.color = picked.GetComponent<PickupInfo>().ReturnOriginalColor();
                            colliderStopWall.SetActive(true);
                            picked.GetComponent<PickupInfo>().SetHolder(this.gameObject);
                            //make it kinematic so gravity doesnt effect it
                            picked.GetComponent<Rigidbody>().isKinematic = true;
                            picked.GetComponent<Rigidbody>().useGravity = false;
                            offsetRotation = picked.transform.rotation.eulerAngles.y - this.gameObject.transform.parent.rotation.eulerAngles.y;
                            //start invoke repeating to keep the object in front of the object
                            InvokeRepeating("MovePickedUp", 0.2f, 0.01666f);
                            //picked.transform.parent = gameObject.transform;
                            return;
                        }
                        // if the item picked up is a draggable
                        else if (picked.name == "Drag")
                        {
                            //run the script the picks up the drag item and also attachs the character joint
                            Invoke("DragPickedUp", 0.0f);
                            return;
                        }
                        else if (picked.name == "LeverWall" || picked.name == "Switch")
                        {
                            //run the script the picks up the new Lever and also attachs the character joint
                            if (picked.GetComponent<LeverWallScript>())
                            {
                                picked.GetComponent<LeverWallScript>().Init();
                            }
                            if (picked.GetComponent<Lever>())
                            {
                                picked.GetComponent<Lever>().Init();
                            }
                            if (picked.GetComponent<Switch>())
                            {
                                picked.GetComponent<Switch>().Init();
                            }
                            //we pulled the lever interactable
                            if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                            {
                                gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
                            }
                            holdingPickUp = false;
                            picked = null;
                            return;
                        }
                        //if the object is the lever then run this
                        else if (picked.name == "LeverFloor")
                        {
                            Debug.Log("the lever has been detected and used as a picked item");
                            //check if the lever has been pulled first and if not then
                            if (picked.GetComponent<ActiveInScene>().GetActive() != true)
                            {
                                Debug.Log("the lever has the active in scene script and now going towards the connect");
                                //rotate the object based on the distance between player and the lever
                                InvokeRepeating("LeverConnect", 0.0f, 0.01666f);
                                //get the starting distance between the player and the player
                                startDistance = Vector2.Distance(picked.transform.position, this.transform.position);
                                //the starting angle of the object
                                startAngle = picked.transform.eulerAngles;
                                if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                                {
                                    gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
                                }
                            }
                            return;
                        }
                    }
                    //this runs when the player is got a object already that he is holding
                    else if ((picked != null) & (holdingPickUp == true))
                    {
                        //since we are holding something we now drop it
                        holdingPickUp = false;
                        //plays release sound
                        AkSoundEngine.SetState("Nationality", MenuScript.Instance.GetAudioClass().GetNationality(this.gameObject.transform.parent.GetComponent<MovementUpdated>().PlayerNum));
                        AkSoundEngine.PostEvent("player_drop", gameObject);
                        //if the object is a pickup item or a bucket then do this
                        if ((picked.name.Contains("Pickup")) || (picked.name.Contains("Bucket")))
                        {
                            if (picked.GetComponent<gravityBody>())
                            {
                                picked.GetComponent<gravityBody>().SetPicked(false);
                            }
                            picked.GetComponent<PickupInfo>().SetCanAutoSnapTrue();
                            colliderStopWall.SetActive(false);
                            //set the kinematic back to false so the object is affected by gravity
                            picked.GetComponent<Rigidbody>().isKinematic = false;
                            picked.GetComponent<Rigidbody>().useGravity = true;
                            //stop the loop of position the pick up item
                            CancelInvoke("MovePickedUp");
                            //picked.transform.parent = null; //MIGHT BE NOT NEEDED
                            // set the pick up item to null
                            picked.GetComponent<PickupInfo>().SetHolder(null);
                            picked = null;
                        }
                        //destroy the joint if the item is a drag
                        else if ((picked.name == "Drag"))
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
                        if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                        {
                            gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
                        }
                        return;
                    }
                }
                if(canThrow == true)
                {
                    if(picked!= null && picked.name.Contains ("PickupThrow"))
                    {
                        //if the key pressed is the throw button
                        if (Input.GetButtonDown((throwKey.ToString())))
                        {
                            //added the != lever to stop the ability to not throw levers 
                            if (picked != null && holdingPickUp == true && picked.tag == "Pickup")
                            {
                                //Turn throw arc on
                                throwArc.SetActive(true);
                                AkSoundEngine.PostEvent("throw_charge", gameObject);
                            }                            
                        }
                        //if the throw key is pressed and not realsed
                        if (Input.GetButton((throwKey.ToString())))
                        {

                            if ((picked != null) && (holdingPickUp == true) && (picked.tag != "Lever"))
                            {
                                if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                                {
                                    gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("ThrowStart", true);
                                }
                                if (picked != null)
                                {
                                    if (picked.name.Contains("Throw") && gameObject.transform.parent.gameObject.GetComponent<Animator>().GetBool("isMoving") != true)
                                    {
                                        PercentageY = -0.68f;
                                        Percentagez = 0.4f;
                                    }
                                    else if (picked.name.Contains("Throw") && gameObject.transform.parent.gameObject.GetComponent<Animator>().GetBool("isMoving") == true)
                                    {
                                        PercentageY = -0.84f;
                                        Percentagez = 0.4f;
                                    }
                                }


                                if (currentVelocity < maxVelocity)
                                {

                                    currentVelocity = currentVelocity + offsetVelocity;
                                }
                                else
                                {
                                    //currentVelocity = maxVelocity;
                                    if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                                    {
                                        gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
                                        gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("ThrowStart", false);
                                        gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("ThrowRelease");
                                    }
                                    //picked.GetComponent<gravityBody>().SetPicked(false);
                                    AkSoundEngine.SetState("Nationality", MenuScript.Instance.GetAudioClass().GetNationality(this.gameObject.transform.parent.GetComponent<MovementUpdated>().PlayerNum));
                                    AkSoundEngine.PostEvent("player_throw", gameObject);
                                    picked.gameObject.AddComponent<CheckVelocity>();
                                    throwArc.GetComponent<ArcRenderMesh>().SetValue(currentVelocity, angle, resolution);
                                    SimulateThrow simulate = picked.AddComponent<SimulateThrow>();
                                    simulate.SetValue(currentVelocity, angle, resolution, picked.transform.position.y);
                                    currentVelocity = minVelocity;
                                    //set it so we no longer are holding the object
                                    holdingPickUp = false;
                                    //turn off the movePickedUp script since we are no longer holding the object
                                    CancelInvoke("MovePickedUp");
                                    picked.transform.parent = null;
                                    //turn kinematic off so gravity effects the object again
                                    //picked.GetComponent<Rigidbody>().isKinematic = false;
                                    //set the picked to null since we are no longer holding the object
                                    picked.GetComponent<PickupInfo>().SetDestroyActive(5.0f);
                                    picked.GetComponent<PickupInfo>().SetHolder(null);
                                    throwArc.SetActive(false);
                                    //if the character joint is present then destroy it since we were holding the object
                                    if (characterJoint != null)
                                    {
                                        Destroy(characterJoint);
                                    }
                                    colliderStopWall.SetActive(false);
                                    picked = null;
                                    AkSoundEngine.PostEvent("throw", gameObject);
                                }
                                throwArc.GetComponent<ArcRenderMesh>().SetValue(currentVelocity, angle, 10);
                            }
                        }
                        //If the throw key is realsed
                        if (Input.GetButtonUp((throwKey.ToString())))
                        {
                            if (picked != null && holdingPickUp == true && picked.tag == "Pickup")
                            {
                                if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
                                {
                                    gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
                                    gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("ThrowStart", false);
                                    gameObject.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("ThrowRelease");
                                }
                                //picked.GetComponent<gravityBody>().SetPicked(false);
                                AkSoundEngine.SetState("Nationality", MenuScript.Instance.GetAudioClass().GetNationality(this.gameObject.transform.parent.GetComponent<MovementUpdated>().PlayerNum));
                                AkSoundEngine.PostEvent("player_throw", gameObject);
                                picked.gameObject.AddComponent<CheckVelocity>();
                                throwArc.GetComponent<ArcRenderMesh>().SetValue(currentVelocity, angle, resolution);
                                SimulateThrow simulate = picked.AddComponent<SimulateThrow>();
                                simulate.SetValue(currentVelocity, angle, resolution, picked.transform.position.y);
                                currentVelocity = minVelocity;
                                //set it so we no longer are holding the object
                                holdingPickUp = false;
                                //turn off the movePickedUp script since we are no longer holding the object
                                CancelInvoke("MovePickedUp");
                                picked.transform.parent = null;
                                //turn kinematic off so gravity effects the object again
                                //picked.GetComponent<Rigidbody>().isKinematic = false;
                                //set the picked to null since we are no longer holding the object
                                picked.GetComponent<PickupInfo>().SetDestroyActive(5.0f);
                                picked.GetComponent<PickupInfo>().SetHolder(null);                        
                                throwArc.SetActive(false);
                                //if the character joint is present then destroy it since we were holding the object
                                if (characterJoint != null)
                                {
                                    Destroy(characterJoint);
                                }
                                colliderStopWall.SetActive(false);
                                picked = null;
                                AkSoundEngine.PostEvent("throw", gameObject);
                            }
                        }
                    }                   
                }
            }
        }
    }
    //the code which sets the position of the object that is being moved around
    void MovePickedUp()
    {
        //get the distance the object should be in terms of being how far forward infront of the player and how high the object is for the player
        // float yDis = this.GetComponent<BoxCollider>().bounds.size.y * PercentageY;
        picked.transform.rotation = Quaternion.identity;
        float yDis = this.GetComponent<Collider>().bounds.size.y * PercentageY;             //Possible fix for any collider type on the pickup objects
       // float zDis = picked.GetComponent<BoxCollider>().bounds.size.z * Percentagez;
        float zDis = picked.GetComponent<Collider>().bounds.size.z * Percentagez;           //Possible fix for any collider type on the pickup objects
        //set the new position based on the percentage of the mesh's dimensions
        picked.transform.position = this.transform.position + (this.transform.forward*zDis) + (this.transform.up * yDis) + (this.transform.up * 0.15f);
        picked.transform.rotation = Quaternion.Euler(new Vector3(picked.transform.rotation.eulerAngles.x, this.transform.parent.rotation.eulerAngles.y , picked.transform.rotation.eulerAngles.z));
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
    public void LetGoOffItem()
    {
        if(picked!=null)
        {
            CancelInvoke("MovePickedUp");
            colliderStopWall.SetActive(false);
            //since we are holding something we now drop it
            holdingPickUp = false;
            //make it null since we are not picking up an item
            picked = null;
            if (this.gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
            {
                this.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
            }
        }
    }

    public void LetGoOffItemBulletShot()
    {
        if (picked != null)
        {
            if (picked.GetComponent<gravityBody>())
            {
                picked.GetComponent<gravityBody>().SetPicked(false);
            }
            picked.GetComponent<PickupInfo>().SetCanAutoSnapTrue();
            colliderStopWall.SetActive(false);
            //set the kinematic back to false so the object is affected by gravity
            picked.GetComponent<Rigidbody>().isKinematic = false;
            picked.GetComponent<Rigidbody>().useGravity = true;
            //stop the loop of position the pick up item
            CancelInvoke("MovePickedUp");
            //picked.transform.parent = null; //MIGHT BE NOT NEEDED
            // set the pick up item to null
            picked.GetComponent<PickupInfo>().SetHolder(null);
            picked = null;
            holdingPickUp = false;
            if (this.gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
            {
                this.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
            }
            if (throwArc.active == true)
            {
                throwArc.SetActive(false);
            }
        }

        //CancelInvoke("MovePickedUp");
        //    colliderStopWall.SetActive(false);
        //    //if (picked.GetComponent<Rigidbody>())
        //    {
        //        picked.GetComponent<Rigidbody>().isKinematic = false;
        //        picked.GetComponent<Rigidbody>().useGravity = true;
        //    }
        //    //since we are holding something we now drop it
        //    holdingPickUp = false;
        //    //make it null since we are not picking up an item
        //    picked = null;
        //    if (this.gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
        //    {
        //        this.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
        //    }
        //}
    }
    //function for when the object interacted with is a lever
    void LeverConnect()
    {
        Debug.Log("the lever is now being run in code to be rotated");
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
            Debug.Log("the thing getting rotated is" + picked.name);
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
            if (this.gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
            {
                this.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
            }
            Debug.Log("finished the full pull");
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
            {
                picked = col.gameObject;
                //change color to the players color when over the object
                if (highlightedObject < 1)
                {
                    //picked.GetComponent<MeshRenderer>().material.color = playerColor;
                    highlightedObject++;
                }
            }              

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
            {
                //return the color back to the original color of the object
                picked = null;
            }
            if (highlightedObject > 0)
            {
                if (col.name == "LeverWall")
                {
                    return;
                }
               // col.GetComponent<MeshRenderer>().material.color = col.GetComponent<PickupInfo>().ReturnOriginalColor();
                highlightedObject--;
            }
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
