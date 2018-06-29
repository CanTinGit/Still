using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAI : MonoBehaviour {

    Vector3 angle,target;  //The angle of the Camera and the position of target
    float maxAngle, minAngle,middleAngle; //Save the date of the max angle, min angle and the middle angle
    bool isRotateLeft;  //Check if the mamera is rotating to left side
    bool isDetected, isShooted, isRun, turnOffCamera; //The four state of camaera, if it detect player, if it shooted, if it is running, if it should be turn off
    public float setCameraOffTime;   //How long should we turn the camera off
    public float cameraRotateSpeed;  //Camera rotation speed
    public float sightRange;         //Camera sight range
    public float sightAngle;         //Camera Rotation Angle
    public float accelaration;       //Camera accelaration speed
    public GameObject bullet;        //The bullet prefeb to initialize
    private Light detectionLight;    //The light of the camera

    // Use this for initialization, initilize camera state
    void Start ()
    {
        turnOffCamera = false;
        isRun = false;
        angle = transform.rotation.eulerAngles;
        maxAngle = angle.y + sightAngle / 2;
        minAngle = angle.y - sightAngle / 2;
        middleAngle = angle.y;
        isRotateLeft = true;
        isDetected = false;
        isShooted = false;
        detectionLight = gameObject.GetComponentInChildren<Light>();                        // Set detectionLight object as Light child component
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        //if the camera is not running, turn the light to white
        if (isRun == false)
        {
            detectionLight.color = Color.white;                                             // If the camera is not running, set light colour to white
            return;
        }

        //if the camera should be turn off, after setCameraOffTime seconds, turn it off
        if (turnOffCamera == true)
        {
            Invoke("TurnOffCamera", setCameraOffTime);
            turnOffCamera = false;
        }
        //Visual detecting be called every frame if the camera is running to detect player
        VisualDetect();
        //If camera do not find the player, rotate in normal
        if (isDetected == false)
        {
            Rotate();
        }
        //if camera find the player, rotate towards target quickly
        else
        {
            //Set the vector from camera to target
            Vector3 targetDir = target - transform.position;
            // The step size is equal to speed times frame time.
            float step = 5.0f * Time.deltaTime;
            //Set the angle that the camera should rotate
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);
            // If the camera is looking to the target
            if (transform.forward.normalized == targetDir.normalized)
            {
                //If the camera didn't shoot before, shoot
                if (isShooted == false)
                {
                    Shoot();
                }
                //After two seconds, Reset the camera to the state before detecting player
                Invoke("ResetCamera", 2.0f);
            }
        }
    }

    //Normal Rotate
    void Rotate()
    {
        //Get the current angle of the camera
        angle = transform.rotation.eulerAngles;

        //If it is rotating to right, angle.y++ means rotate to right
        if (!isRotateLeft)
        {
            angle.y += Time.deltaTime * cameraRotateSpeed;
        }
        //If it is rotating to left, angle.y-- means rotate to left
        else
        {
            angle.y -= Time.deltaTime * cameraRotateSpeed;
        }
        //If the camera reaches the max angle, it should rotate back which means rotate to left
        if (angle.y > maxAngle)
        {
            isRotateLeft = true;
        }
        //If the camera reaches the min, it should rotate back which means rotate to right
        else if (angle.y < minAngle)
        {
            isRotateLeft = false;
        }
        //If it is rotating to left side but not reach the middle, that means it should be accelarating, if it passed the middle, that means it should be decelarating
        if (isRotateLeft)
        {
            //if it do not pass the middle, it should be accelarating
            if (angle.y > middleAngle)
            {
                cameraRotateSpeed += accelaration;
            }
            //if it passed the middle,it should be decelarating
            else
            {
                cameraRotateSpeed -= accelaration;
            }
        }
        //If it is rotating to right side but not reach the middle, that means it should be accelarating, if it passed the middle, that means it should be decelarating
        else
        {
            //if it do not pass the middle, it should be accelarating
            if (angle.y < middleAngle)
            {
                cameraRotateSpeed += accelaration;
            }
            //if it passed the middle,it should be decelarating
            else
            {
                cameraRotateSpeed -= accelaration;
            }
        }
        //Set the rotation of camera
        transform.rotation = Quaternion.Euler(angle);
    }

    public void VisualDetect()
    {
        // Multiple player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        for(int i = 0; i < players.Length; i++)
        {
            GameObject player = players[i];
            if (player != null && isDetected == false)
            {
                // Check the condition of player
                MovementUpdated movement = player.GetComponent<MovementUpdated>();

                // If the player is not in bubble
                if (movement != null && movement.isInBubble == false)
                {

                    // Calculate the distance between player and
                    float dist = Vector3.Distance(player.transform.position, transform.position);

                    // Check if the player is in the range of sight
                    if (dist < sightRange)
                    {
                        //Get the angle between player and camera
                        Vector3 direction = player.transform.position - transform.position;
                        float degree = Vector3.Angle(direction, transform.forward);

                        // If the angle between player and camera is in the sight angle, which means camera can see the player
                        if (degree < sightAngle / 2 && degree > -sightAngle / 2)
                        {
                            Ray ray = new Ray();
                            ray.origin = transform.position;
                            ray.direction = direction;
                            RaycastHit hitInfo;
                            //Check if there is anything which may block the eyesight
                            if (Physics.Raycast(ray, out hitInfo, sightRange))
                            {
                                // If the ray can hit the player, which means nothing block the sight of camera, and the camera acctually finds the player
                                if (hitInfo.transform == player.transform && player.GetComponent<MovementUpdated>().isMoving == true)
                                {
                                    //Setting the isDetect to true means finding player and rotate towards it
                                    isDetected = true;
                                    //Make the sound
                                    AkSoundEngine.PostEvent("camera_trigger", gameObject);
                                    //Target is the player that be found
                                    target = player.transform.position;
                                    //Turn the color to red
                                    gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
                                }
                            }
                        }
                    }
                }

            }
        }
    }

    //If something make noise, call this function to turn on the camera
    public void DetectedNoise(Vector3 targetPosition)
    {
        //Set the camera run and need to be turn off
        target = targetPosition;
        isRun = true;
        turnOffCamera = true;
        //set the color to red and set camera light to red
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        detectionLight.color = Color.red;
    }

    //Shoot bullet
    public void Shoot()
    {
        //Initilize the bullet
        GameObject colonBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        //Play sound
        //AkSoundEngine.PostEvent("bubble_shot", gameObject);
        isShooted = true;
    }

    //Reset the camera back to the state before detecting
    public void ResetCamera()
    {
        isDetected = false;
        isShooted = false;
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        Vector3 resetXZ = new Vector3(0, transform.rotation.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(resetXZ);
    }
    //Turn off the camera
    void TurnOffCamera()
    {
        //Set camera back to white
        gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        SetRunning(false);
    }

    //Set the camera to running state
    void SetRunning(bool run)
    {
        isRun = run;
    }
}
