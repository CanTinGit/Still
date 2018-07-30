using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public Animator lever;
    public string animatorVariable;
    public Animator animator;
    // Use this for initialization

    public void Init()
    {
        lever.SetTrigger("LeverOn");
        animator.SetTrigger(animatorVariable);
        this.tag = "Untagged";
    }
}
