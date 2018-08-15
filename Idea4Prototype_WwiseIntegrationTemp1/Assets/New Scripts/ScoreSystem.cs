using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour {

    // Use this for initialization
    float finalScore; //the final score of the level
    List<float> checkpointTime; // the amount of checkpoints that are in the level
    int collectablesObtained; //the collectables obtained overall
    int timesCameraTriggered; // the number of times the camera has been triggered
    Timer timeScript; //the timer script where we obtain the time for each checkpoint
    int Checkpoint; //tells the script which checkpoint to record for
    //values for designers so they cant chaneg the controls
    [Header("Score Settings")]
    public float timeScoreMultiplier;  //The multiplier for the time
    public float extraPlayerScore;  //The point awarded for each extra player
    public float CollectableScore; //the points awarded for collectables
    public float maxCameraTrigger; //The max amount of times a camera can be triggered before you lose trigger camera score
    public float triggerCameraScore; //The points awarded for not triggering over the max camera amount
    public float highScoreBonus; //the points awarded if you beat your high score
    public bool cameraInLevel; //the boolean to tell us if there is a camera ai in this level
    public int cheese;  //the cheese timer score
    void Start ()
    {
        timeScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        checkpointTime = new List<float>();
        Checkpoint = 0;
        cheese = 0;
        finalScore = 0;
        timesCameraTriggered = 0;
        collectablesObtained = 0;
        timeScoreMultiplier = 73;
        extraPlayerScore = 112;
        CollectableScore = 37;
        maxCameraTrigger = 3;
        triggerCameraScore = 213;
        highScoreBonus = 117;
        for(int count= 0; count <3;count++)
        {
            checkpointTime.Add(60.0f);
        }      
    }
	
    public void CalculateFinalScore()
    {
        foreach(float checkpoint in checkpointTime)
        {
            finalScore += checkpoint * timeScoreMultiplier;
        }
        //if(finalScore > MenuScript.Instance.playerdata.GetPassedLevelScore(SceneManager.GetActiveScene().buildIndex-1))
        {
            //finalScore += highScoreBonus;
        }
        finalScore += ((MenuScript.Instance.GetNumberofPlayers()-1) * extraPlayerScore) + (collectablesObtained * CollectableScore);
        if (cameraInLevel == true)
        {
            finalScore += triggerCameraScore;
        }
        Debug.Log("Calculation is ( number of players " + MenuScript.Instance.GetNumberofPlayers() +
            " multiplied by extre player score " + extraPlayerScore + " ) + ( collectablesObtained " + collectablesObtained
            + " multipled by colletable score " + "CollectableScore) +  if cameras are in level " + cameraInLevel + 
            " then the camera score is ( camera score " + triggerCameraScore + " if triggered less than " 
            + maxCameraTrigger + " which it triggered " + timesCameraTriggered + " ) + (highscore bonus is " + highScoreBonus + " based on if he beat his highscore)" ) ;

        Debug.Log("Total score is " + finalScore);       
    }

    //public void SetCollectableObtained(int collectableObtained_)
    //{
    //    collectablesObtained += collectableObtained_;
    //}

    public void SetTimesCameraTriggered(int timesCameraTriggered_)
    {
        timesCameraTriggered += timesCameraTriggered_;
        if(timesCameraTriggered > maxCameraTrigger)
        {
            triggerCameraScore = 0f;
        }
    }
    //add the time for that checkpoint
    public void AddCheckpointTime()
    {
        //Debug.Log("time added " + timeScript.GetTimeInSeconds() + " seconds" );
        checkpointTime.RemoveAt(Checkpoint);
        checkpointTime.Insert(Checkpoint, timeScript.GetTimeInSeconds());
        //checkpointTime.Add(timeScript.GetTimeInSeconds());
        Checkpoint++;
        if (Checkpoint!=3)
        {
            //Debug.Log("time done" + Checkpoint);
            timeScript.SetTimer(0, 0, 6, 0);
        }
    }
    //returns the cheese sprite for the timer based on overall time
    public Sprite ReturnStars()
    {
        float time = 0;
        Debug.Log("Return Score");
        cheese = 0;
        if (checkpointTime.Count!=0)
        {
            Debug.Log("checkpoint list " + checkpointTime.Count);
            foreach (float checkpoint in checkpointTime)
            {
                time = checkpoint;
                if (time > 30.0f && time <= 60.0f)
                {
                    cheese += 3;
                }
                else if (time > 0.0f && time <= 30.0f)
                {
                    cheese += 2;
                }
                else if (time == 0.0f)
                {
                    cheese += 1;
                }

            }
            Debug.Log("stars before " + cheese);
            cheese = Mathf.RoundToInt((float)cheese / 3);
            Debug.Log(cheese);
            Debug.Log("time is " + time);
        }
        else
        {
            cheese = 1;
        }
        Sprite sprite = Resources.Load<Sprite>("UI/ScoreSystem/Star" + cheese);
        return sprite;
    }
    public float ReturnScore()
    {
        return finalScore;
    }
    //returns the average star score of the whole levels checkpoint
    public Sprite ChangeTimeToStars()
    {
        float timeFromCheckpoint = 0;
        int stars = 0;
        Sprite sprite;
        for (int count = 0; count < checkpointTime.Count; count++)
        {
            //get the time and then add the star score based on it
            if (count != Checkpoint)
            {
                timeFromCheckpoint = checkpointTime[count];
            }
            else if(count == Checkpoint)
            {
                timeFromCheckpoint = timeScript.GetTimeInSeconds();
            }

            if (timeFromCheckpoint > 30 && timeFromCheckpoint <= 60)
            {
                stars += 3;
            }
            else if (timeFromCheckpoint > 0 && timeFromCheckpoint <= 30)
            {
                stars += 2;
            }
            else if (timeFromCheckpoint == 0)
            {
                stars += 1;
            }
        }
        //stars = Mathf.RoundToInt((float)stars / 3);
        if(stars>3)
        {
             sprite = Resources.Load<Sprite>("UI/ScoreSystem/Cheese" + stars);
        }
        else
        {
             sprite = Resources.Load<Sprite>("UI/ScoreSystem/Cheese3");
        }
        return sprite;
    }

    public void LevelSkippedScore()
    {
        
        if(checkpointTime.Count > 0)
        {
                for (int index = 0; index < checkpointTime.Count; index++)
                {
                    Debug.Log(checkpointTime[index]);
                    checkpointTime.RemoveAt(index);
                    checkpointTime.Insert(index, 0.0f);
                }
        }
    }
    public void IncreaseCollectable()
    {
        collectablesObtained++;
    }
}
