﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//the states the camera can be in
enum CameraState {StillLooking,Found,Cautious,ResumeLooking,FinishedSearch}
/// <summary>
/// - StillLooking - If the camera hasnt spotted the player so is still looking
/// - Found - We have found the player, so will do something
/// - Cautious - Camera may of heard something again so will do a certain action
/// - ResumeLooking - Camera thought it heard something so will continue moving towards its last point it was going to
/// - FinishedSearch - It has finished looking through all the search areas
/// </summary>
public class CamerAIUpdated : MonoBehaviour
{
    //variable for all the target points the camera has to go to
    List<GameObject> targetPoint;
    //default height the camera should be at ( keeps the spot light at correct location and size)
    private float height;
    //speed of the camera
    public int speed;
    //boolean to control if the camera is still running (incase we need to stop it midpoint)
    bool running = true;
    //the state the camera will start on
    CameraState state = CameraState.StillLooking;
    //the delay of each movement during the coroutine ( the vector3.movetowards movement)
    private float nextMovementDelay = 0.01f;
    //on awake we set up these variables
    void Awake()
    {
        //make sure the height is the starting y position
        height = this.transform.position.y;
        //intialises the list of gameobject
        targetPoint = new List<GameObject>();
        //add all the camera travel points to the list
        targetPoint.AddRange(GameObject.FindGameObjectsWithTag("CameraSpotPoints"));
        //start the whole movement process
        NewTravelPoint();
    }
    //sets up the end point and calls the movement code
    void NewTravelPoint()
    {
        //if there is still any items in the list then continue;
        if (targetPoint.Count>-1)
        {
            //randomize the index based on the length of the list
            int index = Random.Range(0, targetPoint.Count);
            //create the end point with the correct y position
            Vector3 endPoint = new Vector3(targetPoint[index].transform.position.x, height, targetPoint[index].transform.position.z);
            //call the coroutine that will do the movement
            StartCoroutine(MoveTo(endPoint, index));
        }
    }
    //the coroutine that does the movement based on end point also takes the index so we can remove the travel point from the list when we arrive
    IEnumerator MoveTo(Vector3 endPoint_,int index_)
    {
        //the boolean that tells the game we are moving
        bool moving = true;
        //do a while loop if the camera should still be running and we are still moving to the end point
        while ((moving == true) && (running==true))
        {
            //change the position towards the end points
            this.transform.position = Vector3.MoveTowards(this.transform.position, endPoint_, speed * Time.deltaTime);
            //when we reach the end point stop the loop by setting the moving to false and remove the point
            if (this.transform.position == endPoint_)
            {
                RemoveTravelPoint(ref index_);
                moving = false;
            }
            //the delay between each move towards ( simulate the traversing)
            yield return new WaitForSeconds(nextMovementDelay);
        }
        //if we exit the while loop check the state of the camera and then run the correct function based on that
        CameraStateMachine(ref index_,ref endPoint_);
    }
    //the state machine for the camera, pass in the index so we can remove the travel point
    void CameraStateMachine(ref int index_, ref Vector3 endPoint_)
    {
        //based on the state of the camera do the correct action
        switch(state)
        {
            //since the cammera hasnt noticed the player at all then just continue to move to a new point
            case CameraState.StillLooking:
                NewTravelPoint();
                break;
            //camera was looking for the player but is going back to searching the area, so start from the last point it was at
            case CameraState.ResumeLooking:
                MoveTo(endPoint_, index_);
                break;
            //the camera has found the player so do the action
            case CameraState.Found:
                Debug.Log("found the enemy");
                break;
            //the camera thinks it heard a noise again
            case CameraState.Cautious:
                Debug.Log("beleive there is a enemy");
                break;
            //the camera has finished the serch
            case CameraState.FinishedSearch:
                Debug.Log("camera is done searching");
                break;
        }
    }
    //when the camera is done destroy it ( i think still need more designer input)
    void CameraFinishedSearch()
    {
        Destroy(this.gameObject);
    }
    //remove a travel point from the list
    void RemoveTravelPoint(ref int index_)
    {
        //remove the point from the list
        targetPoint.RemoveAt(index_);
        //after removing the point check if there is no targets left in the list
        if(targetPoint.Count==0)
        {
            //change state to finished search state
            state = CameraState.FinishedSearch;
        }
    }
    //stop the camera from moving
    void StopCamera()
    {
        running = false;
    }
    //resume the camera
    void ResumeCamera()
    {
        running = true;
    }
}
