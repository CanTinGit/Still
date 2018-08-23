using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ThreadmillState {Charging,Powered,Off};


public class Treadmill : MonoBehaviour
{

    public float treadmillOnStrength;
    public float treadmillPoweringStrength;
    public float powerGenerated = 0.0f;
    public float powerNeeded = 3.0f;
    public float pushbackOtherObjectStrength = 5.0f;
    public GameObject buttonOn;
    public bool on = false;
    public GameObject powerIndicator;
    public ThreadmillState threadmillState;
    public float timeForSwitching=0.0f;
    public Color machineUIColor;
    public float SpeedOfColorChange;
    public float RunMultiplier;

    //for sound
    float audioAKRTPC=0;
    float in_UseRTPC = 1.0f;
    //for texture panning
    public Vector2 uvAnimationRate = new Vector2(0.002f,0.0f);
    public string textureName = "_MainTex";
    private Vector2 uvOffset = Vector2.zero;
    public float threadmillDelayPan;
    bool animateThreadmill;
    bool trigger = false;

    void Start()
    {
        powerGenerated = 0.0f;
        timeForSwitching = 0.0f;
        threadmillState = ThreadmillState.Off;
        InvokeRepeating("IndicatorColorChange",0.0f, SpeedOfColorChange);
        machineUIColor = Color.red;
        buttonOn.transform.parent.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    void LateUpdate()
    {
        if(animateThreadmill==true)
        {
            uvOffset += (uvAnimationRate * Time.deltaTime);
            transform.parent.GetComponent<MeshRenderer>().material.SetTextureOffset(textureName, uvOffset);
            trigger = false;
        }
        if(threadmillState == ThreadmillState.Off)
        {
            if(trigger == false)
            {
                Invoke("DelayTreadmillStop", threadmillDelayPan);
                trigger = true;
            }
        }  
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            if(col.GetComponent<MovementUpdated>().GetRunning())
            {
                RunMultiplier = 5.0f;
            }
            else
            {
                RunMultiplier = 1.0f;
            }
            if(MenuScript.Instance.GetNumberofPlayers()>1)
            {
                if(col.GetComponent<MovementUpdated>().isMoving && col.GetComponent<MovementUpdated>().GetGrounded())
                {
                    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    col.GetComponent<Rigidbody>().AddForce(Vector3.right * treadmillPoweringStrength, ForceMode.Acceleration);
                    buttonOn.GetComponent<PressedButton>().enabled = true;
                    //powerIndicator.GetComponent<MeshRenderer>().material.color = Color.green;
                    threadmillState = ThreadmillState.Powered;
                    animateThreadmill = true;
                    buttonOn.transform.parent.GetComponent<MeshRenderer>().material.color = Color.red;

                }
                else if(!col.GetComponent<MovementUpdated>().isMoving)
                {
                    buttonOn.GetComponent<PressedButton>().enabled = false;
                    //powerIndicator.GetComponent<MeshRenderer>().material.color = Color.red;
                    threadmillState = ThreadmillState.Off;
                    buttonOn.transform.parent.GetComponent<MeshRenderer>().material.color = Color.white;
                    //Invoke("DelayTreadmillStop", threadmillDelayPan);
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
                    animateThreadmill = true;
                    buttonOn.transform.parent.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else if (powerGenerated < powerNeeded && col.GetComponent<MovementUpdated>().isMoving && col.GetComponent<MovementUpdated>().GetGrounded())
                {
                    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    col.GetComponent<Rigidbody>().AddForce(Vector3.right * treadmillPoweringStrength,ForceMode.Acceleration);
                    threadmillState = ThreadmillState.Charging;
                    animateThreadmill = true;
                    powerGenerated += Time.deltaTime * RunMultiplier;
                }
                if ((!col.GetComponent<MovementUpdated>().isMoving || !col.GetComponent<MovementUpdated>().GetGrounded()) && powerGenerated < powerNeeded)
                {
                    powerGenerated = 0.0f;
                   // powerIndicator.GetComponent<MeshRenderer>().material.color = Color.red;
                    threadmillState = ThreadmillState.Off;
                    //Invoke("DelayTreadmillStop", threadmillDelayPan);
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

    void DelayTreadmillStop()
    {
        if(threadmillState==ThreadmillState.Off)
        {
            if(animateThreadmill!=false)
            {
                animateThreadmill = false;
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
                audioAKRTPC = 0.4f;
                if(on==true)
                {
                    in_UseRTPC = 0.0f;
                }
                break;
            case ThreadmillState.Charging:
                ColorToChangeTo = new Vector4(1.0f, 0.423f, 0.008f, 1.0f);
                audioAKRTPC = 0.4f;
                break;
            case ThreadmillState.Off:
                ColorToChangeTo = Color.red;
                audioAKRTPC = 0;
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
            //float trackRTCPValue =
            powerIndicator.GetComponent<MeshRenderer>().material.color = lerpedColor;
            AkSoundEngine.PostEvent("treadmill_trigger", gameObject);
            AkSoundEngine.SetRTPCValue("run_time", audioAKRTPC, gameObject, 500);
            AkSoundEngine.SetRTPCValue("in_use", in_UseRTPC, gameObject, 500);

        }
    }
}