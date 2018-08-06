using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour {

    // Use this for initialization
    float finalScore;
    List<float> checkpointTime;
    public float timeScoreMultiplier;
    public float extraPlayerScore;
    public float CollectableScore;
    public float maxCameraTrigger;
    public float triggerCameraScore;
    public float highScoreBonus;
    int collectablesObtained;
    int timesCameraTriggered;
    public bool cameraInLevel;
    Timer timeScript;
    public int star;
    int Checkpoint;
    void Start ()
    {
        timeScript = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        checkpointTime = new List<float>();
        Checkpoint = 0;
        star = 0;
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
            finalScore +=triggerCameraScore;
        }
        Debug.Log("Calculation is ( number of players " + MenuScript.Instance.GetNumberofPlayers() +
            " multiplied by extre player score " + extraPlayerScore + " ) + ( collectablesObtained " + collectablesObtained
            + " multipled by colletable score " + "CollectableScore) +  if cameras are in level " + cameraInLevel + 
            " then the camera score is ( camera score " + triggerCameraScore + " if triggered less than " 
            + maxCameraTrigger + " which it triggered " + timesCameraTriggered + " ) + (highscore bonus is " + highScoreBonus + " based on if he beat his highscore)" ) ;

        Debug.Log("Total score is " + finalScore);       
    }

    public void SetCollectableObtained(int collectableObtained_)
    {
        collectablesObtained += collectableObtained_;
    }

    public void SetTimesCameraTriggered(int timesCameraTriggered_)
    {
        timesCameraTriggered += timesCameraTriggered_;
        if(timesCameraTriggered> maxCameraTrigger)
        {
            triggerCameraScore = 0f;
        }
    }
    public void AddCheckpointTime()
    {
        Debug.Log("time added " + timeScript.GetTimeInSeconds() + " seconds" );
        checkpointTime.RemoveAt(Checkpoint);
        checkpointTime.Insert(Checkpoint, timeScript.GetTimeInSeconds());
        //checkpointTime.Add(timeScript.GetTimeInSeconds());
        Checkpoint++;
        if (Checkpoint!=3)
        {
            Debug.Log("time done" + Checkpoint);
            timeScript.SetTimer(0, 0, 6, 0);
        }
    }

    public Sprite ReturnStars()
    {
        float time = 0;
        if(checkpointTime.Count!=0)
        {
            Debug.Log("checkpoint list");
            foreach (float checkpoint in checkpointTime)
            {
                //if (checkpoint > 30 && checkpoint <= 60)
                //{
                //    star += 3;
                //}
                //else if (checkpoint > 0 && checkpoint <= 30)
                //{
                //    star += 2;
                //}
                //else
                //{
                //    star += 1;
                //}
                time += checkpoint;
            }

            time = time / 3;
            Debug.Log("time is " + time);
            if (time > 30.0f && time <= 60.0f)
            {
                star += 3;
            }
            else if (time > 0.0f && time <= 30.0f)
            {
                star += 2;
            }
            else if(time==0.0f)
            {
                star += 1;
            }
            //star = star / 3;
        }
        else
        {
            star = 1;
        }
        Sprite sprite = Resources.Load<Sprite>("UI/ScoreSystem/Star" + star);
        return sprite;
    }
    public float ReturnScore()
    {
        return finalScore;
    }
    //return the star of checkpoint ( pass in 1 if u want checkpoint 1 ) 
    public Sprite ChangeTimeToStars()
    {

        float timeFromCheckpoint = 0;
        int stars=3;
        for(int count = 0; count < checkpointTime.Count;count++)
        {
            if(count!=Checkpoint)
            {
                timeFromCheckpoint += checkpointTime[count];
              //  Debug.Log("total time (fake time ) " + timeFromCheckpoint + " checkpoint" + count + " time is " + checkpointTime[count]);
            }
        }
        timeFromCheckpoint += timeScript.GetTimeInSeconds();
        //Debug.Log("total time (fake time ) " + timeFromCheckpoint + " and the time is " + timeScript.GetTimeInSeconds());
        timeFromCheckpoint = timeFromCheckpoint / 3;
       // Debug.Log("averaged time is " + timeFromCheckpoint);
        if (timeFromCheckpoint > 30 && timeFromCheckpoint <= 60)
        {
            stars = 3;
        }
        else if (timeFromCheckpoint > 0 && timeFromCheckpoint <= 30)
        {
            stars = 2;
        }
        else if (timeFromCheckpoint == 0)
        {
            stars = 1;
        }
        Sprite sprite = Resources.Load<Sprite>("UI/ScoreSystem/Cheese" + stars);
        return sprite;
        ////returns a checkpointnumber
        //int checkpointStar = 3;
        //float timeToStar = timeScript.GetTimeInSeconds();
        //if (timeToStar > 0 && timeToStar <= 30)
        //{
        //    checkpointStar = 2;
        //}
        //else if(timeToStar == 0)
        //{
        //    checkpointStar = 1;
        //}
        ////if it returns 0 it is a fail return
        ////return checkpointStar;
        //Sprite sprite = Resources.Load<Sprite>("UI/ScoreSystem/Star" + checkpointStar);
        //return sprite;
    }
}
