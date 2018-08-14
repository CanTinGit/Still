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

    public Sprite ReturnStars()
    {
        float time = 0;
        Debug.Log("Return Score");
        star = 0;
        if (checkpointTime.Count!=0)
        {
            Debug.Log("checkpoint list " + checkpointTime.Count);
            foreach (float checkpoint in checkpointTime)
            {
                time = checkpoint;
                if (time > 30.0f && time <= 60.0f)
                {
                    star += 3;
                }
                else if (time > 0.0f && time <= 30.0f)
                {
                    star += 2;
                }
                else if (time == 0.0f)
                {
                    star += 1;
                }

            }
            Debug.Log("stars before " + star);
            star = Mathf.RoundToInt((float)star / 3);
            Debug.Log(star);
            Debug.Log("time is " + time);
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
}
