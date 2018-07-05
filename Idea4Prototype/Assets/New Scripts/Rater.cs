using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

// New structure to present the time
[Serializable]
public class setTime
{
    public int unitSeconds, tenSeconds, unitMins, tenMins;

    // Overload the operator > to use to compare time
    public static bool operator >(setTime time1, setTime time2)
    {
        //If the ten minute of time1 is more than time2, that means time1 is more than time2, so return true
        if (time1.tenMins > time2.tenMins)
        {
            return true;
        }
        //If the ten minute of time1 is equal time2, then compare the unit minute
        else if (time1.tenMins == time2.tenMins)
        {
            //If the unit minute of time1 is more than time2, that means time1 is more than time2, so return true
            if (time1.unitMins > time2.unitMins)
            {
                return true;
            }
            //If the unit minute of time1 is equal to time2, then compare the ten second
            else if (time1.unitMins == time2.unitMins)
            {
                //If the ten second of time1 is more than time2, that means time1 is more than time2, so return true
                if (time1.tenSeconds > time2.tenSeconds)
                {
                    return true;
                }
                //If the ten second time1 is equal to time2, then compare the unit second
                else if (time1.tenSeconds == time2.tenSeconds)
                {
                    //If the unit second of time1 is more than time2, that means time1 is more than time2, so return true, if not, return false
                    if (time1.unitSeconds > time2.unitSeconds)
                    {
                        return true;
                    }
                    // Else of comparing unit second
                    else
                    {
                        return false;
                    }
                }
                // Else of comparing ten second
                else
                {
                    return false;
                }
            }
            // Else of comparing unit minute
            else
            {
                return false;
            }
        }
        // Else of comparing ten minute
        else
        {
            return false;
        }
    }

    // Same logic to overload the < operator
    public static bool operator <(setTime time1, setTime time2)
    {
        //If the ten minute of time1 is less than time2, that means time1 is less than time2, so return true
        if (time1.tenMins < time2.tenMins)
        {
            return true;
        }
        //If the ten minute of time1 is equal time2, then compare the unit minute
        else if (time1.tenMins == time2.tenMins)
        {
            //If the unit minute of time1 is less than time2, that means time1 is less than time2, so return true
            if (time1.unitMins < time2.unitMins)
            {
                return true;
            }
            //If the unit minute of time1 is equal to time2, then compare the ten second
            else if (time1.unitMins == time2.unitMins)
            {
                //If the ten second of time1 is less than time2, that means time1 is less than time2, so return true
                if (time1.tenSeconds < time2.tenSeconds)
                {
                    return true;
                }
                //If the ten second time1 is equal to time2, then compare the unit second
                else if (time1.tenSeconds == time2.tenSeconds)
                {
                    //If the unit second of time1 is less than time2, that means time1 is less than time2, so return true, if not, return false
                    if (time1.unitSeconds < time2.unitSeconds)
                    {
                        return true;
                    }
                    // Else of comparing unit second
                    else
                    {
                        return false;
                    }
                }
                // Else of comparing ten second
                else
                {
                    return false;
                }
            }
            // Else of comparing unit minute
            else
            {
                return false;
            }
        }
        // Else of comparing ten minute
        else
        {
            return false;
        }
    }
}
    
public class Rater : MonoBehaviour
{
    //Three setting timing to rate
    public setTime[] setTimings = new setTime[3];
    public Sprite[] stars = new Sprite[3];
    Image starImage;
    Timer time;
    //Rate function
    public int Rating()
    {
        //Get the UI of Rating
        starImage = GameObject.Find("FadeSceneHolder").transform.GetChild(1).GetComponent<Image>();
        time = GameObject.Find("Timer").GetComponent<Timer>();
        //Get current time that players used to pass

        setTime finishedTime = new setTime();
        finishedTime.unitSeconds = time.unitSeconds;
        finishedTime.tenSeconds = time.tenSeconds;
        finishedTime.unitMins = time.unitMins;
        finishedTime.tenMins = time.tenMins;

        //If it's more than setting timing 1, get three star
        if (finishedTime > setTimings[0])
        {
            starImage.sprite = stars[2];
            starImage.SetNativeSize();
            return 3;
        }

        //If it's less than setting timing 1, but more than setting timing 2, get two star
        else if (finishedTime < setTimings[0] && finishedTime > setTimings[1])
        {
            starImage.sprite = stars[1];
            starImage.SetNativeSize();
            return 2;
        }
        //Else getting one star
        else
        {
            starImage.sprite = stars[0];
            starImage.SetNativeSize();
            return 1;
        }
    }
}
