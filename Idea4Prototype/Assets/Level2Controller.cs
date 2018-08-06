using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour {

    // Use this for initialization
    Transform Point1,Point2,Point3,Camera1,Camera2,Camera3;
	void Start ()
    {
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
            Camera1.gameObject.SetActive(!Camera1.gameObject.activeSelf);
        }
        else if(pointsToDisable==2)
        {
            Point2.gameObject.SetActive(!Point2.gameObject.activeSelf);
            Camera2.gameObject.SetActive(!Camera2.gameObject.activeSelf);
        }
        else if (pointsToDisable == 3)
        {
            Point3.gameObject.SetActive(!Point3.gameObject.activeSelf);
            Camera3.gameObject.SetActive(!Camera3.gameObject.activeSelf);
        }
    }

    public void ChangeToTransitionTwo()
    {
        DisableAndEnablePoints(1);
        DisableAndEnablePoints(2);
    }
    public void ChangeToTransitionThree()
    {
        DisableAndEnablePoints(2);
        DisableAndEnablePoints(3);
    }
}
