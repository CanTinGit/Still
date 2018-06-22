using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for controller whether the object has been used or not
public class ActiveInScene : MonoBehaviour {
    bool active;
    public Animator whichAnimator,reverseAnimator;
    public string animatorWord,reverseAnimatorWord;
    bool isDoorOpen, pulled;
    Vector3 originalPos;

    void Awake ()
    {
        originalPos = transform.GetChild(0).transform.eulerAngles;
        active = false;
        isDoorOpen = false;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.F1))
        {
            setActive(false);
        }
    }
    public bool GetActive()
    {
        return active;
    }
    //triggers the normal animator and the reverse version if needed be
    public void setActive(bool newActive_)
    {
        active = newActive_;
        if(active == true)
        {
            TriggerAnimator();
        }
        else if (active == false)
        {
            SetPulled(false);
            if(reverseAnimator!=null)
            {
                TriggerReverseAnimator();
            }
            transform.GetChild(0).eulerAngles = originalPos;
        }
    }
    //change pull state
   void SetPulled(bool newPulled_)
    {
        pulled = newPulled_;
    }

    void TriggerAnimator()
    {
       // if (isDoorOpen == false)
       // {
            whichAnimator.SetBool(animatorWord, true);
       //     isDoorOpen = true;
       // }
    }
    void TriggerReverseAnimator()
    {
        if (isDoorOpen == true)
        {
            reverseAnimator.SetBool(reverseAnimatorWord, true);
            isDoorOpen = false;
        }
    }
}
