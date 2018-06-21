using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for controller whether the object has been used or not
public class ActiveInScene : MonoBehaviour {
    bool active;
    public Animator whichAnimator;
    public string animatorWord;
    bool isDoorOpen, pulled;

    void Awake ()
    {
        active = false;
        isDoorOpen = false;
    }
    public bool GetActive()
    {
        return active;
    }
    public void setActive(bool newActive_)
    {
        active = newActive_;
        if(active == true)
        {
            TriggerAnimator();
        }
    }

    void TriggerAnimator()
    {
        if (isDoorOpen == false)
        {
            whichAnimator.SetBool(animatorWord, true);
            isDoorOpen = true;
        }
    }
}
