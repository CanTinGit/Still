using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class template : MonoBehaviour
{
    public Animator doorAnimator;
    public CharacterJoint cj;
    bool isDoorOpen,pulled;
	// Use this for initialization
	void Awake ()
    {
        isDoorOpen = false;
        pulled = false;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(pulled == true)
        {
            if (isDoorOpen == false)
            {
                doorAnimator.SetBool("OpenDoor", true);
                isDoorOpen = true;
            }
            
        }
	}

    public void LeverPulled()
    {
        pulled = true;
    }
}
