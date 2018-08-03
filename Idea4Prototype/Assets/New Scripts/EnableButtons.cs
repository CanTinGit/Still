using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtons : MonoBehaviour
{
    public GameObject button1, button2;
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "Hammer")
        {
            if(button1 !=null)
            {
                button1.GetComponent<PressedButton>().enabled = true;
            }
            if (button2 != null)
            {
                button2.GetComponent<PressedButton>().enabled = true;
            }
            if (GameObject.FindGameObjectWithTag("AlertSpotlight") == null)
            {
                Instantiate(Resources.Load("Prefabs/NewCameraAI"));
            }
            AkSoundEngine.PostEvent("button_click", gameObject);
        }
    }

}
