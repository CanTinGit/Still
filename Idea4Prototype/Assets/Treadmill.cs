using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ThreadmillState {Charging,Powered,Off};


public class Treadmill : MonoBehaviour
{

    public float treadmillOnStrength;
    public float treadmillPoweringStrength;
    public float powerGenerated = 0.0f;
    public float powerNeeded = 5.0f;
    public float pushbackOtherObjectStrength = 5.0f;
    public GameObject buttonOn;
    public bool on = false;
    public GameObject powerIndicator;
    public ThreadmillState threadmillState;
    public float timeForSwitching=0.0f;
    public Color machineUIColor;
    public float SpeedOfColorChange;

    void Start()
    {
        powerGenerated = 0.0f;
        timeForSwitching = 0.0f;
        threadmillState = ThreadmillState.Off;
        InvokeRepeating("IndicatorColorChange",0.0f, SpeedOfColorChange);
        machineUIColor = Color.red;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if(MenuScript.Instance.GetNumberofPlayers()>1)
            {
                if(col.GetComponent<MovementUpdated>().isMoving && col.GetComponent<MovementUpdated>().GetGrounded())
                {
                    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    col.GetComponent<Rigidbody>().AddForce(Vector3.right * treadmillPoweringStrength, ForceMode.Acceleration);
                    buttonOn.GetComponent<PressedButton>().enabled = true;
                    //powerIndicator.GetComponent<MeshRenderer>().material.color = Color.green;
                    threadmillState = ThreadmillState.Powered;

                }
                else if(!col.GetComponent<MovementUpdated>().isMoving)
                {
                    buttonOn.GetComponent<PressedButton>().enabled = false;
                    //powerIndicator.GetComponent<MeshRenderer>().material.color = Color.red;
                    threadmillState = ThreadmillState.Off;
                }
            }
            else
            {
                if (powerGenerated > powerNeeded)
                {
                    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    col.GetComponent<Rigidbody>().AddForce(Vector3.right * treadmillOnStrength, ForceMode.VelocityChange);
                    buttonOn.GetComponent<PressedButton>().enabled = true;
                  //  powerIndicator.GetComponent<MeshRenderer>().material.color = Color.green;
                    on = true;
                    threadmillState = ThreadmillState.Powered;
                }
                else if (powerGenerated < powerNeeded && col.GetComponent<MovementUpdated>().isMoving && col.GetComponent<MovementUpdated>().GetGrounded())
                {
                    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    col.GetComponent<Rigidbody>().AddForce(Vector3.right * treadmillPoweringStrength,ForceMode.Acceleration);
                    threadmillState = ThreadmillState.Charging;
                    powerGenerated += Time.deltaTime;
                }
                if ((!col.GetComponent<MovementUpdated>().isMoving || !col.GetComponent<MovementUpdated>().GetGrounded()) && powerGenerated < powerNeeded)
                {
                    powerGenerated = 0.0f;
                   // powerIndicator.GetComponent<MeshRenderer>().material.color = Color.red;
                    threadmillState = ThreadmillState.Off;
                }
                //if (col.GetComponent<MovementUpdated>().isMoving && col.GetComponent<MovementUpdated>().GetGrounded())
                //{
                //    powerGenerated += Time.deltaTime;
                //}
            }
        }
        if (on == true && col.tag == "Pickup")
        {
            col.GetComponent<Rigidbody>().AddForce(Vector3.right * pushbackOtherObjectStrength, ForceMode.VelocityChange);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            if (MenuScript.Instance.GetNumberofPlayers() > 1)
            {
                buttonOn.GetComponent<PressedButton>().enabled = false;
                threadmillState = ThreadmillState.Off;
            }
            else
            {
                if((powerGenerated < powerNeeded))
                {
                    buttonOn.GetComponent<PressedButton>().enabled = false;
                    threadmillState = ThreadmillState.Off;
                }
            }
        }
    }
    void IndicatorColorChange()
    {
        Color ColorToChangeTo = powerIndicator.GetComponent<MeshRenderer>().material.color;
        //sets the color of the ui based on the state of threadmill
        switch(threadmillState)
        {
            case ThreadmillState.Powered:
                ColorToChangeTo = Color.green;
                break;
            case ThreadmillState.Charging:
                ColorToChangeTo = new Vector4(1.0f, 0.423f, 0.008f, 1.0f);
                break;
            case ThreadmillState.Off:
                ColorToChangeTo = Color.red;
                break;
        }
        //if the color of the machine needs to be changed then reset time
        if(machineUIColor!= ColorToChangeTo)
        {
            timeForSwitching = 0.0f;
            machineUIColor = ColorToChangeTo;
        }
        //until we got the correct colour keep lerping
        if (powerIndicator.GetComponent<MeshRenderer>().material.color != ColorToChangeTo)
        {
            timeForSwitching +=  0.001f;
            Color lerpedColor = Color.Lerp(powerIndicator.GetComponent<MeshRenderer>().material.color, ColorToChangeTo, timeForSwitching);
            powerIndicator.GetComponent<MeshRenderer>().material.color = lerpedColor;
        }

    }

}