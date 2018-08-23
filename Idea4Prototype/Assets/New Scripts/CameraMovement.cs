using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject boxColliderStopper;
    public GameObject boxColliderBack;
    List<GameObject> players = new List<GameObject>();
    public string CameraMove;
    public Animator camera;
    public string musicSection;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (!players.Exists(x=>x.gameObject == col.gameObject))
            {
                players.Add(col.gameObject);
            }
            if (players.Count == MenuScript.Instance.GetNumberofPlayers())
            {
                boxColliderStopper.SetActive(false);
                boxColliderBack.SetActive(true);
                gameObject.SetActive(false);
                camera.SetTrigger(CameraMove);
                AkSoundEngine.SetSwitch("Music_Transition", musicSection, GameObject.FindGameObjectWithTag("MainCamera"));
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            if (players.Exists(x => x.gameObject == col.gameObject))
            {
                players.Remove(col.gameObject);
            }
        }
    }
}
