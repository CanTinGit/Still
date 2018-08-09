using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Use this for initialization
    GameObject timer;                                       // Timer gameObject reference
    public int unitSeconds, tenSeconds, unitMins, tenMins;
    int numPlayers;
    float timeTaken;
    void Start ()
    {
       // unitSeconds = 0;                                                        // Number of single unit seconds
        //tenSeconds = 0;                                                         // Number of tens units seconds
        //unitMins = 5;                                                           // Number of single unit minutes
        //tenMins = 0;                                                            // Number of tens unit minutes
        numPlayers = MenuScript.Instance.GetNumberofPlayers();//GameObject.FindGameObjectsWithTag("Player").Length;        // numPlayers = the length of the number of game objects with tag "Players" i.e. the number of visible players in the scene
        //TimerPlayerNum();                                                       // Time adjustment based on number of players
        timer = GameObject.FindGameObjectWithTag("Timer").GetComponentInChildren<Text>().gameObject;
        InvokeRepeating("Timing", 0.0f, 1.0f);
	}

    //timer settings
    void Timing()           // Timer function
    {
        if (MenuScript.Instance.gamePaused == false)
        {
            timeTaken++;
            if (tenMins != 0 || unitMins != 0 || tenSeconds != 0 || unitSeconds != 0)       // If any of the timer variables do NOT equal 0, run the following code
            {

                unitSeconds -= 1;                                                       // Take 1 away from the number of unit seconds
                if (unitSeconds < 0)                                                        // If the number of unit seconds is less than 0, i.e. that the timer should go to the next tens unit etc.
                {
                    if (tenSeconds != 0)                                                    // If the ten seconds unit variable does NOT equal 0
                    {
                        tenSeconds -= 1;                                                    // Take 1 away from the tens seconds unit variable, i.e it is the next tens unit down
                    }
                    else
                    {
                        tenSeconds = 5;                                                     // If it IS equal to 0, set the ten seconds unit variable to 5, i.e. the start of the next minute to countdown

                        unitMins--;                                                     // Take 1 away from the unit minutes variable, i.e. the next minute down

                    }
                    unitSeconds = 9;                                                        // Set the unit seconds variable to 9, as it is the next tens unit down
                }
            }
            //GetComponent<Image>().sprite = TimeToStars();
            GetComponent<Image>().sprite = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreSystem>().ChangeTimeToStars();
            timer.GetComponent<Text>().text = tenMins.ToString() + unitMins.ToString() + ":" + tenSeconds.ToString() + unitSeconds.ToString();         // Convert the timer integer variable to string format for in-game
        }
    }

    void TimerPlayerNum()               // Checks number of players in the game and adjusts time accordingly
    {
       if(numPlayers == 1)              // If only 1 player, full time
        {
            unitSeconds = 0;
            tenSeconds = 0;
            unitMins = 5;
            tenMins = 0;
        }
       else if(numPlayers == 2)         // If 2 players, timer set to 4:30
        {
            unitSeconds = 0;
            tenSeconds = 3;
            unitMins = 4;
            tenMins = 0;
        }
       else if(numPlayers == 3)         // If 3 players, timer set to 4:00
        {
            unitSeconds = 0;
            tenSeconds = 0;
            unitMins = 4;
            tenMins = 0;
        }
        else if(numPlayers == 4)
        {
            unitSeconds = 0;            // else it must be four players, timer set to 3:30
            tenSeconds = 3;
            unitMins = 3;
            tenMins = 0;
        }
        //Debug.Log("here 1");
    }

    public void SetTimer(int tMins, int uMins, int tSecs, int uSecs)
    {
        tenMins = tMins;
        unitMins = uMins;
        tenSeconds = tSecs;
        unitSeconds = uSecs;
    }

    public float GetTimeInSeconds()
    {
        float checkpointTime = (tenMins * 600) + (unitMins * 60) + (tenSeconds * 10) + (unitSeconds);
        return checkpointTime;
    }
    //changes the time to a sprite of cheese
    Sprite TimeToStars()
    {
        //returns a checkpointnumber
        int checkpointStar = 3;
        if (GetTimeInSeconds() > 0 && GetTimeInSeconds() <= 30)
        {
            checkpointStar = 2;
        }
        else if (GetTimeInSeconds() == 0)
        {
            checkpointStar = 1;
        }
        //if it returns 0 it is a fail return
        //return checkpointStar;
        Sprite sprite = Resources.Load<Sprite>("UI/ScoreSystem/Cheese" + checkpointStar);
        return sprite;
    }

    public float GetOverallTime()
    {
        return timeTaken;
    }

    public void ResetTimeTaken()
    {
        timeTaken = 0.0f;
    }
}


