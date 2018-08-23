using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour {

    public GameObject cube;
    public bool moveBack;
    public GameObject pushCube;
    public GameObject Lever;
    public GameObject leverPlatform;
    public float force;
    public GameObject wire_singlePlayer;
    public GameObject wire_multiple;
    public GameObject cheese_singlePlayer;
    public GameObject cheese_multiple;
    // Use this for initialization
    void Start ()
    {
        if (MenuScript.Instance.GetNumberofPlayers() > 1)
        {
            cube.SetActive(false);
            moveBack = true;
            Lever.SetActive(true);
            leverPlatform.SetActive(true);
            wire_singlePlayer.SetActive(false);
            wire_multiple.SetActive(true);
            cheese_multiple.SetActive(true);
            cheese_singlePlayer.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveBack)
        {
            pushCube.GetComponent<Rigidbody>().AddForce(Vector3.left * force,ForceMode.VelocityChange);
        }
	}
}
