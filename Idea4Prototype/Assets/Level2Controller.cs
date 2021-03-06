﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour {

    // Use this for initialization
    Transform Point1,Point2,Point3,Camera1,Camera2,Camera3;
	void Start ()
    {
        //to stop the music of level 1
        Point1 = GameObject.Find("Point1").transform;
        Point2 = GameObject.Find("Point2").transform;
        Point3 = GameObject.Find("Point3").transform;
        Camera1 = GameObject.Find("g_Camera1").transform;
        Camera2 = GameObject.Find("g_Camera2").transform;
        Camera3 = GameObject.Find("g_Camera3").transform;
        DisableAndEnablePoints(2);
        DisableAndEnablePoints(3);
    }
	
    void DisableAndEnablePoints(int pointsToDisable)
    {
        if(pointsToDisable==1)
        {
            Point1.gameObject.SetActive(!Point1.gameObject.activeSelf);
            ChangeTag(Camera1);
        }
        else if(pointsToDisable==2)
        {
            Point2.gameObject.SetActive(!Point2.gameObject.activeSelf);
            ChangeTag(Camera2);
        }
        else if (pointsToDisable == 3)
        {
            Point3.gameObject.SetActive(!Point3.gameObject.activeSelf);
            ChangeTag(Camera3);
        }
    }
    //the transition to the second part of the level
    public void ChangeToTransitionTwo()
    {
        DisableAndEnablePoints(1);
        DisableAndEnablePoints(2);
    }
    //the transition to the third part of the level
    public void ChangeToTransitionThree()
    {
        DisableAndEnablePoints(2);
        DisableAndEnablePoints(3);
    }
    //change the tags of the camera ai object when we need or dont need them
    void ChangeTag(Transform camera_)
    {
        if (camera_.tag == "Untagged")
        {
            camera_.tag = "CameraObject";
        }
        else if (camera_.tag == "CameraObject")
        {
            camera_.tag = "Untagged";
        }
    }
}
