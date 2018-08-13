using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabberOn : MonoBehaviour {

    public void CameraMove_GrabberOn()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().SetTrigger("CameraMove_GrabberOn");
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Animator>().SetBool("isMoving", false);
            players[i].GetComponent<MovementUpdated>().isMoving = false;
            players[i].GetComponent<MovementUpdated>().enabled = false;
            //if (gameObject.transform.parent.gameObject.GetComponent<Animator>() != null)
            //{
            //    gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("PickUp", false);
            //}
            //players[i].GetComponent<Animator>().set

        }
    }

    public void CameraMove_GrabberFinished()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<MovementUpdated>().enabled = true;
        }
    }
}
