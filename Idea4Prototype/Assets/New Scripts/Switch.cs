using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Animator lever;
    public string animatorVariable;
    public Animator animator;
    public bool hasPlayed;
    public string SoundName;
    // Use this for initialization
    public void Init()
    {
            if (hasPlayed)
            {
                return;
            }
            lever.SetTrigger("SwitchOn");
        if (SoundName != "")
        {
            AkSoundEngine.PostEvent(SoundName, gameObject);
        }
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

        this.gameObject.tag = "Untagged";
        Invoke("Delay", 0.5f);
    }
}
