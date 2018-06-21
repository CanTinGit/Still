using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpdated : MonoBehaviour {

    PlayerKeys playerKeys;
    new Rigidbody rigidbody;
    //used to tell us if the player is on the ground
    bool grounded = false;
    //which player this is 1-4
    public int PlayerNum;
    //store the start position of the player incase he dies
    Vector3 startPos;
    Vector3 movement;
    //the values for player movements
    public float jumpSpeed = 8.0f;
    public float moveSpeed = 1.0f;
    public float TurnSpeed = 10.0f;
    float moveHorizontal = 0.0f;
    float moveVertical = 0.0f;
    public bool isInBubble;
    public bool isMoving;
    GameObject pausePanel;
    // Use this for initialization
    void Awake()
    {
        //pausePanel = GameObject.Find("PausePanel");
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
        playerKeys = MenuScript.Instance.GetPlayerKeys();
        jumpSpeed = playerKeys.GetJumpPower();
        moveSpeed = playerKeys.GetMoveSpeed();
        TurnSpeed = playerKeys.GetTurnSpeed();
        isInBubble = false;      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindObjectOfType<PauseScript>().GetActive()==false)
        {
            //movement controls for player - (S and W keys move forwards and back) & ( A and D keys rotate the player left and right)
            if (PlayerNum == 1)
            {
                //Using custom keys to control
                if (Input.GetKey(playerKeys.GetKeys()[3]))
                {
                    this.transform.Rotate(Vector3.up * TurnSpeed);
                    isMoving = true;
                }

                if (Input.GetKey(playerKeys.GetKeys()[0]))
                {
                    this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    isMoving = true;
                    //rigidbody.AddForce(transform.forward * moveSpeed,ForceMode.VelocityChange);           
                }

                if (Input.GetKey(playerKeys.GetKeys()[2]))
                {
                    this.transform.Rotate(Vector3.down * TurnSpeed);
                    isMoving = true;
                }

                if (Input.GetKey(playerKeys.GetKeys()[1]))
                {
                    this.transform.position += (-transform.forward) * moveSpeed * Time.deltaTime;
                    isMoving = true;
                    //rigidbody.AddForce(-transform.forward * moveSpeed , ForceMode.VelocityChange);
                }
                //if the player is grounded then he can jump
                if (grounded)
                {
                    //when the player presses k apply a force to make him jump
                    if (Input.GetKeyDown(playerKeys.GetKeys()[5]))
                    {
                        rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
                        isMoving = true;
                    }
                }
                if (!Input.GetKey(playerKeys.GetKeys()[3]) && !Input.GetKey(playerKeys.GetKeys()[0]) && !Input.GetKey(playerKeys.GetKeys()[2]) && !Input.GetKey(playerKeys.GetKeys()[1]) && !Input.GetKey(playerKeys.GetKeys()[5]))
                {
                    isMoving = false;
                }
            }

            //The example of using controller to move
            if (PlayerNum == 2)
            {
                if (Input.GetAxisRaw("Horizontal")>0.3f || Input.GetAxisRaw("Horizontal") < -0.3f)
                {
                    moveHorizontal = Input.GetAxisRaw("Horizontal");
                    isMoving = true;
                }
                if (Input.GetAxisRaw("Vertical") > 0.3f || Input.GetAxisRaw("Vertical") < -0.3f)
                {
                    moveVertical = Input.GetAxisRaw("Vertical");
                    isMoving = true;
                }
                    //float moveHorizontal = Input.GetAxisRaw("Horizontal");
                    //float moveVertical = Input.GetAxisRaw("Vertical");
                if(isMoving==true)
                {
                    movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
                    transform.rotation = Quaternion.LookRotation(movement);//Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.40f);
                    transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
                }

                //transform.LookAt(direction);
                ////Using Axis button to move
                //if (Input.GetAxis("Horizontal") > 0.3f)
                //{
                //    //Turn right
                //    this.transform.Rotate(Vector3.up * TurnSpeed);
                //    isMoving = true;
                //}

                //if (Input.GetAxis("Vertical") > 0.3f)
                //{
                //    //Move forward
                //    this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
                //    isMoving = true;
                //    //rigidbody.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
                //    //rigidbody.velocity = transform.forward * moveSpeed;
                //}

                //if (Input.GetAxis("Horizontal") < -0.3f)
                //{
                //    //Turn left
                //    this.transform.Rotate(Vector3.down * TurnSpeed);
                //    isMoving = true;
                //}

                //if (Input.GetAxis("Vertical") < -0.3f)
                //{
                //    //Move backward
                //    this.transform.position += (-transform.forward) * moveSpeed * Time.deltaTime;
                //    isMoving = true;
                //    //rigidbody.AddForce(-transform.forward * moveSpeed, ForceMode.VelocityChange);
                //    //rigidbody.velocity = (-transform.forward) * moveSpeed;
                //}
                //if the player is grounded then he can jump
                if (grounded)
                {
                    //when the player presses k apply a force to make him jump
                    if (Input.GetKeyDown(playerKeys.GetKeys()[5]))
                    {
                        isMoving = true;
                        rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
                    }
                }

                if (Input.GetAxis("Vertical") > -0.1f && Input.GetAxis("Vertical") < 0.1f && Input.GetAxis("Horizontal") > -0.1f && Input.GetAxis("Horizontal") < 0.1f && !Input.GetKey(playerKeys.GetKeys()[5]))
                {
                    isMoving = false;
                    transform.rotation = Quaternion.LookRotation(movement);
                }
            }
            //OLD VELOCITY LIMIT
            //if(rigidbody.velocity.magnitude>5)
            //{
            //    Vector3 newVelocity = rigidbody.velocity.normalized;
            //    newVelocity *= 5;
            //    rigidbody.velocity = newVelocity;
            //}
        }
    }


    //OLD CODE WILL BE UPDATED AS PROGRESS
    void OnCollisionStay(Collision col)
    {
        //When player landed, set the grouded to true to let player be able to jump
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }

    }

    //When player collider with others
    void OnCollisionEnter(Collision col)
    {
        //collider with goal, go to next level
        if (col.gameObject.name == "Goal")
        {
            MenuScript.Instance.FadeToNextLevel();
            Destroy(col.gameObject);
        }
        //collider with goal, dead and back to start position
        if (col.gameObject.tag == "Traps")
        {
            if (col.gameObject.GetComponent<Traps>().GetDisabled() == false)
                transform.position = startPos;
        }
    }

    //Lastest landing code
    void OnTriggerStay(Collider col)
    {
        //When player landed, set the grouded to true to let player be able to jump
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    //When player jumped, set grouded to false to let player be not able to jump in the sky
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    //When player jumped, set grouded to false to let player be not able to jump in the sky
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
