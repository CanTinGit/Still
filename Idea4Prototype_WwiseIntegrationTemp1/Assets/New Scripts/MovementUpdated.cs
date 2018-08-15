using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpdated : MonoBehaviour {

    PlayerKeys[] playerKeys;
    new Rigidbody rigidbody;
    //used to tell us if the player is on the ground
    bool grounded = false;
    //which player this is 1-4
    public int PlayerNum;
    //store the start position of the player incase he dies
    Vector3 startPos;
    Vector3 movement;
    //the values for player movements
    public float jumpSpeed = 70.0f;
    public float moveSpeed;
    public float TurnSpeed = 10.0f;
    float moveHorizontal = 0.0f;
    float moveVertical = 0.0f;
    public bool isInBubble;
    public bool isMoving;
    public bool isRunning;
    GameObject pausePanel;
    public PhysicMaterial jumpingMaterial;
    public PhysicMaterial originalMaterial;
    public float runSpeed;
    public float cameraTrigger;
    public GameObject runSmoke;

    Vector3 forward;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    float velocity;
    // Use this for initialization
    //void Awake()
    //{
    //    //pausePanel = GameObject.Find("PausePanel");
    //}
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startPos = transform.position;
        playerKeys = MenuScript.Instance.GetPlayerKeys();
        //jumpSpeed = playerKeys[PlayerNum-1].GetJumpPower();
        //moveSpeed = playerKeys[PlayerNum-1].GetMoveSpeed();
        TurnSpeed = playerKeys[PlayerNum-1].GetTurnSpeed();
        isInBubble = false;
        isRunning = false;
        CalculateDirection();
        originalMaterial = gameObject.GetComponent<CapsuleCollider>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MenuScript.Instance.gamePaused==false)
        {           
            ControllerMovement();
            if (rigidbody.velocity.y < 0)
            {
                rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime; //2.5
            }
            else if (rigidbody.velocity.y > 0)
            {
                rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; //2
            }

            if(rigidbody.velocity.y < velocity)
            {
                Debug.Log("old velo == " + velocity);
                velocity = rigidbody.velocity.y;
                Debug.Log("new velo == " + velocity);
            }
            ////movement controls for player - (S and W keys move forwards and back) & ( A and D keys rotate the player left and right)
            //if (PlayerNum == 1)
            //{
            //    //Using custom keys to control
            //    if (Input.GetKey(playerKeys.GetKeys()[3]))
            //    {
            //        this.transform.Rotate(Vector3.up * TurnSpeed);
            //        isMoving = true;
            //    }

            //    if (Input.GetKey(playerKeys.GetKeys()[0]))
            //    {
            //        this.transform.position += transform.forward * moveSpeed * Time.deltaTime;
            //        isMoving = true;
            //        //rigidbody.AddForce(transform.forward * moveSpeed,ForceMode.VelocityChange);
            //    }

            //    if (Input.GetKey(playerKeys.GetKeys()[2]))
            //    {
            //        this.transform.Rotate(Vector3.down * TurnSpeed);
            //        isMoving = true;
            //    }

            //    if (Input.GetKey(playerKeys.GetKeys()[1]))
            //    {
            //        this.transform.position += (-transform.forward) * moveSpeed * Time.deltaTime;
            //        isMoving = true;
            //        //rigidbody.AddForce(-transform.forward * moveSpeed , ForceMode.VelocityChange);
            //    }
            //    //if the player is grounded then he can jump
            //    if (grounded)
            //    {
            //        //when the player presses k apply a force to make him jump
            //        if (Input.GetKeyDown(playerKeys.GetKeys()[5]))
            //        {
            //            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            //            isMoving = true;
            //        }
            //    }
            //    if (!Input.GetKey(playerKeys.GetKeys()[3]) && !Input.GetKey(playerKeys.GetKeys()[0]) && !Input.GetKey(playerKeys.GetKeys()[2]) && !Input.GetKey(playerKeys.GetKeys()[1]) && !Input.GetKey(playerKeys.GetKeys()[5]))
            //    {
            //        isMoving = false;
            //    }
            //}

            ////The example of using controller to move
            //if (PlayerNum == 2)
            //{

            //    if (Input.GetAxis("Horizontal")>0.5f || Input.GetAxis("Horizontal") < -0.5f)
            //    {
            //        isMoving = true;
            //    }
            //    if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Vertical") < -0.5f)
            //    {
            //        isMoving = true;
            //    }

            //    if (isMoving == true)
            //    {
            //        movement = Input.GetAxis("Horizontal") * Camera.main.transform.right + Input.GetAxis("Vertical") * forward;
            //        if (movement!= Vector3.zero)
            //        {
            //            transform.rotation =Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.40f);// Quaternion.LookRotation(movement);
            //        }
            //        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
            //    }

            //    //if the player is grounded then he can jump
            //    if (grounded)
            //    {
            //        //when the player presses k apply a force to make him jump
            //        if (Input.GetKeyDown(playerKeys.GetKeys()[5]))
            //        {
            //            isMoving = true;
            //            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.VelocityChange);
            //        }
            //    }

            //    if (Input.GetAxis("Vertical") > -0.1f && Input.GetAxis("Vertical") < 0.1f && Input.GetAxis("Horizontal") > -0.1f && Input.GetAxis("Horizontal") < 0.1f && !Input.GetKey(playerKeys.GetKeys()[5]))
            //    {
            //        isMoving = false;

            //    }
            //}

        }
    }
    public void ChangeVelocity(float velocity_)
    {
        velocity = velocity_;
    }

    void ControllerMovement()
    {
        if (Input.GetAxis("Horizontal" + PlayerNum.ToString()) > 0.5f || Input.GetAxis("Horizontal" + PlayerNum.ToString()) < -0.5f)
        {
            isMoving = true;
        }
        if (Input.GetAxis("Vertical" + PlayerNum.ToString()) > 0.5f || Input.GetAxis("Vertical" + PlayerNum.ToString()) < -0.5f)
        {
            isMoving = true;
        }

        if (isMoving == true)
        {
            movement = Input.GetAxis("Horizontal" + PlayerNum.ToString()) * Camera.main.transform.right + Input.GetAxis("Vertical" + PlayerNum.ToString()) * (-forward);
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f);// Quaternion.LookRotation(movement);
            }

            if (Input.GetAxis("XboxRightTrigger" + PlayerNum.ToString()) < -0.5f)
            {
                //movement = movement.normalized * runSpeed;
                //rigidbody.velocity = new Vector3(movement.x, rigidbody.velocity.y, movement.z);
                transform.Translate(movement * runSpeed * Time.deltaTime, Space.World);
                gameObject.GetComponent<Animator>().SetFloat("Speed", runSpeed);
                isRunning = true;
                runSmoke.SetActive(true);

            }
            else
            {
                //movement = movement.normalized * moveSpeed;
                //rigidbody.velocity = new Vector3(movement.x,rigidbody.velocity.y,movement.z);
                transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
                gameObject.GetComponent<Animator>().SetFloat("Speed", 0.0f);
                isRunning = false;
                runSmoke.SetActive(false);
            }
        }

        //if the player is grounded then he can jump
        if (grounded)
            {
                //when the player presses the jump key apply a force to make him jump
                if (Input.GetButtonDown(playerKeys[PlayerNum-1].GetKeys()[5].ToString().Insert(8,PlayerNum.ToString())))
                {
                    AkSoundEngine.SetState("Nationality", MenuScript.Instance.GetAudioClass().GetNationality(PlayerNum));
                    AkSoundEngine.PostEvent("player_jump", gameObject);
                    //isMoving = true;
                    
                    grounded = false;
                    if (gameObject.GetComponent<Animator>() != null && grounded == false)
                    {
                        gameObject.GetComponent<Animator>().SetBool("isMoving", false);
                        gameObject.GetComponent<Animator>().SetBool("Jump", true);
                    }
                    rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
                    Debug.Log("Strat");
                    gameObject.GetComponent<CapsuleCollider>().material = jumpingMaterial;
                    Debug.Log("End");
                }
            }

            if (Input.GetAxis("Vertical" + PlayerNum.ToString()) > -0.19f && Input.GetAxis("Vertical" + PlayerNum.ToString()) < 0.19f && Input.GetAxis("Horizontal" + PlayerNum.ToString()) > -0.19f && Input.GetAxis("Horizontal" + PlayerNum.ToString()) < 0.19f && !Input.GetKey(playerKeys[PlayerNum-1].GetKeys()[5]))
            {
                isMoving = false;
            }

            if(gameObject.GetComponent<Animator>() != null && isMoving == true && grounded == true)
            {
                gameObject.GetComponent<Animator>().SetBool("isMoving", true);
            }
            else if(gameObject.GetComponent<Animator>() != null /*&& isMoving == false*/)
            {
                gameObject.GetComponent<Animator>().SetBool("isMoving", false);
            }

            if (gameObject.GetComponent<Animator>() != null && grounded == true)
            {
                gameObject.GetComponent<Animator>().SetBool("JumpEnd", true);
                gameObject.GetComponent<Animator>().SetBool("Jump", false);
            }
            if (gameObject.GetComponent<Animator>() != null && grounded == false)
            {
                gameObject.GetComponent<Animator>().SetBool("JumpEnd", false);
            }
    }
    // Calculate the direction based on Camera
    void CalculateDirection()
    {
        forward = Vector3.Cross(Camera.main.transform.right, Vector3.up).normalized;
    }

    //OLD CODE WILL BE UPDATED AS PROGRESS
    void OnCollisionStay(Collision col)
    {
        //When player landed, set the grouded to true to let player be able to jump
        if (col.gameObject.tag == "Ground")
        {
            grounded = true;
            //The example of using controller to move
            if (rigidbody.velocity.magnitude < 0.5f)
            {
                rigidbody.velocity = Vector3.zero;
            }
        }
        if (grounded==false)
        {
            if (col.gameObject.GetComponent<PickupInfo>())
            {
                if (col.gameObject.GetComponent<PickupInfo>().GetGrounded() == true)
                {
                    Vector3 direction = transform.position - col.transform.position;
                    //Debug.Log("direction is " + direction);
                    float degree = Vector3.Angle(direction, Vector3.up);
                    //Debug.Log(transform.position.y);
                    if (degree < 60)
                    {
                        grounded = true;
                    }
                }
            }
        }
       //THIS HAS MORE CALCULATION BUT SHOULD WORK FOR ANY SIDE THE ABOVE WORKS WITH OUR UNITY CUBES
        //float degree = Vector3.Angle(direction, Vector3.up);
        //Debug.Log("degree is " + degree);
        //if (degree < 40)
        //{
        //    grounded = true;
        //}
    }

    //When player collider with others
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if(GameObject.FindGameObjectWithTag("CameraObject"))
            {
                if(velocity < cameraTrigger)
                {
                    Debug.Log("triggered");
                    if (GameObject.FindGameObjectWithTag("AlertSpotlight") == null)
                    {
                        Instantiate(Resources.Load("Prefabs/NewCameraAI"));
                    }
                    velocity = 0;
                }
            }
            rigidbody.velocity = Vector3.zero;
            gameObject.GetComponent<CapsuleCollider>().material = originalMaterial;
            
        }
        if (col.transform.name == "m_seesaw")
        {
            runSpeed = runSpeed / 2;
        }

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
        if (col.gameObject.GetComponent<PickupInfo>())
        {
            if (col.gameObject.GetComponent<PickupInfo>().GetGrounded() == true)
            {
                
                Vector3 direction = transform.position - col.transform.position;
                Debug.Log(transform.position);
                Debug.Log(col.transform.position);
                Debug.Log(direction);
                //Debug.Log("direction is " + direction);
                float degree = Vector3.Angle(direction, Vector3.up);
                Debug.Log(degree);
                //Debug.Log(transform.position.y);
                if (degree < 60)
                {
                    gameObject.GetComponent<CapsuleCollider>().material = originalMaterial;
                }
            }
        }
        //if (col.gameObject.GetComponent<PickupInfo>())
        //{
        //    if (col.gameObject.GetComponent<PickupInfo>().GetGrounded() == true)
        //    {
        //        Vector3 direction = transform.position - col.transform.position;
        //        //Debug.Log("direction is " + direction);
        //        float degree = Vector3.Angle(direction, Vector3.up);
        //        //Debug.Log("degree is " + degree);
        //        if (degree < 40)
        //        {
        //            grounded = true;
        //        }
        //    }
        //}
    }
    //Lastest landing code
    void OnTriggerEnter(Collider col)
    {
        //When player landed, set the grouded to true to let player be able to jump
        if (col.gameObject.tag == "Ground")
        {
           gameObject.GetComponent<CapsuleCollider>().material = originalMaterial;
            if (GameObject.FindGameObjectWithTag("CameraObject"))
            {
                if (velocity < cameraTrigger)
                {
                    Debug.Log("triggered");
                    if (GameObject.FindGameObjectWithTag("AlertSpotlight") == null)
                    {
                        Instantiate(Resources.Load("Prefabs/NewCameraAI"));
                    }
                    velocity = 0;
                }
            }

        }
    }

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
        if (col.gameObject.GetComponent<PickupInfo>())
        {
            if (col.gameObject.GetComponent<PickupInfo>().GetGrounded() == true)
            {
                grounded = false;
            }
        }
        if (col.transform.name == "m_seesaw")
        {
            runSpeed = 6 ;
        }
    }

    public bool GetGrounded()
    {
        return grounded;
    }

    public void SetGround(bool ground_)
    {
        grounded = ground_;
    }

    public bool GetRunning()
    {
        return isRunning;
    }
}
