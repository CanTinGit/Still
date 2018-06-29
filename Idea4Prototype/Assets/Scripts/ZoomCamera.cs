using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {

    float minFov = 15.0f;
    float maxFov = 90f;

    Camera mainCamera;
    GameObject LevelBuilderManager;
    Vector3 intialClickPos,origin, intialRotateClickPos;
    bool drag = false;
    bool altHeld = false;
    bool middleClick = false;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        LevelBuilderManager = GameObject.Find("LevelBuilderManager");
    }

	// Update is called once per frame
	void Update ()
    {
        BoolSwitchs();
        
        if ((LevelBuilderManager.GetComponent<LevelBuilder>().GetState() == EditorState.None) )
        {
            ZoomMovement();
            if (altHeld == true )
            {
                RotateCamera();
            }
            else if (middleClick == true)
            {
                moveCamera();
            }
        }

    }
    void BoolSwitchs()
    {

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            altHeld = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            altHeld = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            middleClick = true;
            intialClickPos = Input.mousePosition;
            origin = mainCamera.transform.position;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            middleClick = false;
        }
    }

    void RotateCamera()
    {

        float movementSensitivity = 0.1f;
        if (Input.GetMouseButtonDown(0))
        {
            intialRotateClickPos = Input.mousePosition;
        }
        else if ((Input.GetMouseButton(0)))
        {
            Vector3 dragClickPos = Input.mousePosition;
            Vector3 difference = (dragClickPos - intialRotateClickPos) * movementSensitivity; ;
            Debug.Log(difference);
            mainCamera.transform.RotateAround(Vector3.zero, Vector3.up, difference.x * Time.deltaTime);
        }
    }
    void ZoomMovement()
    {
        float sensitivity = 15f;
        if ((Input.GetAxis("Mouse ScrollWheel") > 0.0f) || (Input.GetAxis("Mouse ScrollWheel") < -0.0f))
        {
            float fov = Camera.main.fieldOfView;
            fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            mainCamera.fieldOfView = fov;
        }
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
    // TESTING camera movement with alt + mouseclick ( switch to rotate around object as well)
    private void moveCamera()
    {
        float movementSensitivity = 0.1f;
        float zMovement = 15.0f;
        //if ((Input.GetAxis("Mouse ScrollWheel") > 0.0f) || (Input.GetAxis("Mouse ScrollWheel") < -0.0f))
        //{
        //    mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + (-transform.forward.magnitude * (Input.GetAxisRaw("Mouse ScrollWheel") * zMovement)), mainCamera.transform.position.y, mainCamera.transform.position.z);
        //}
        //if ((Input.GetMouseButtonDown(0)) && (drag == false))
        //{
        //    drag = true;
        //    origin = mainCamera.transform.position;
        //    intialClickPos = Input.mousePosition;
        //}
        if( (middleClick == true))
        {
            Vector3 dragClickPos = Input.mousePosition;
            Vector3 difference = (dragClickPos - intialClickPos)* movementSensitivity;
            //Debug.Log()
            mainCamera.transform.position = new Vector3(origin.x,origin.y - difference.y,origin.z-difference.x);
        }
        //if(Input.GetMouseButtonUp(0))
        //{
        //    drag = false;
        //}
    }

}
