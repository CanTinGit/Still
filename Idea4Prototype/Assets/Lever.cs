using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public Animator lever;
    public string animatorVariable;
    public Animator animator;
    public bool isLevel2;
    public bool hasPlayed;
    // Use this for initialization

    public void Init()
    {
        if (!isLevel2)
        {
            lever.SetTrigger("Level1Lever");
            Invoke("DelayDoorOpen", 1.0f);
            this.tag = "Untagged";
        }
        else
        {
            if (hasPlayed)
            {
                return;
            }
            lever.SetTrigger("buttonOn");
        }
    }

    void DelayDoorOpen()
    {
        //AkSoundEngine.PostEvent("gate"); //PLAY THE GATE
        animator.SetTrigger(animatorVariable);
    }
    void Delay()
    {
        HingeJoint hammer = GameObject.Find("Hammer").GetComponent<HingeJoint>();
        hammer.useLimits = false;
    }

    public void VCon()
    {
        ParticleSystem air = GameObject.Find("AIRFan").GetComponent<ParticleSystem>();
        
        HingeJoint hammer = GameObject.Find("Hammer").GetComponent<HingeJoint>();
        air.Play();
        hasPlayed = true;
        this.gameObject.tag = "Untagged";
        Invoke("Delay", 0.5f);
    }
}
