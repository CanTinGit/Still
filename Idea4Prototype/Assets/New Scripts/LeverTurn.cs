using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTurn : MonoBehaviour {

    public Animator craneAnimator;
    public CharacterJoint cj;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (cj == null)
        {
            craneAnimator.SetBool("isCraneRelease", true);
        }

    }
}
