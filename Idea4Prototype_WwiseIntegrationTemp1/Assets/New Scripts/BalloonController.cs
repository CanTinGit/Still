using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour {

    public GameObject can;
    public GameObject balloon;
    public GameObject goalArea;
    int i = 9;
	public void TurnGravityOn()
    {
        can.transform.parent = null;
        can.GetComponent<Rigidbody>().isKinematic = false;
        goalArea.SetActive(true);
    }

    public void CatchCan()
    {
        can.transform.parent = balloon.transform;
        InvokeRepeating("CatchSlow", 0.0f, 0.016f);
    }

    void CatchSlow()
    {
        if (i == 0)
        {
            CancelInvoke();
        }
        can.transform.position += new Vector3(0, 0.1f, 0);
        i--;
    }
}
