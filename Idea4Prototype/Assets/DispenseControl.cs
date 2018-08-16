using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenseControl : MonoBehaviour
{
    public GameObject button;
    public GameObject firstSpawnLight, secondSpawnLight;
    Material firstSpawnLightMat, secondSpawnLightMat;
    bool hitDispense,moveback,sliding,hitStopper;
    
    Vector3 positon;
    void Start()
    {
        hitDispense = false;
        moveback = GameObject.Find("Level1Controller").GetComponent<Level1Controller>().moveBack;
        firstSpawnLightMat = firstSpawnLight.GetComponent<MeshRenderer>().material;
        secondSpawnLightMat = secondSpawnLight.GetComponent<MeshRenderer>().material;
        positon = transform.position;
    }

    void Update()
    {
        if ((transform.position.x - positon.x) < 0.0f)
        {
           // Debug.Log("sliding");
            sliding = true;
        }
        else
        {
            sliding = false;
            //Debug.Log("not sliding");
        }
        if (!hitStopper && positon != transform.position && sliding == true)
        {
            playMoveAudio(false);
        }
        if (positon != transform.position)
        {
            positon = transform.position;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.transform.name == "EnableDispense")
        {
            //button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex = 1;
            firstSpawnLightMat.SetFloat("_Toggle_On", 0.0f);
            secondSpawnLightMat.SetFloat("_Toggle_On", 1.0f);
            hitDispense = true;
            //firstSpawnLight.GetComponent<MeshRenderer>().material.color = Color.red;
            // secondSpawnLight.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (col.transform.name == "StopCube")
        {
            hitStopper = true;
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            //button.GetComponent<SpawnObjectButton>().SetCanDispense(false);
            GameObject.Find("SpawnerManager").GetComponent<Spawner>().spawnPointIndex = 0;
            firstSpawnLightMat.SetFloat("_Toggle_On", 1.0f);
            secondSpawnLightMat.SetFloat("_Toggle_On", 0.0f);
            hitDispense = false;
            // firstSpawnLight.GetComponent<MeshRenderer>().material.color = Color.green;
            // secondSpawnLight.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        if (col.transform.name == "StopCube")
        {
            hitStopper = false;
        }
    }


    void OnCollisionStay(Collision col)
    {
        if (col.transform.name == "EnableDispense")
        {
            if (button.GetComponent<SpawnObjectButton>().GetDispense()==false)
            button.GetComponent<SpawnObjectButton>().SetCanDispense(true);
        }
        if(col.transform.tag=="Player")
        {
            if (!hitDispense && positon != transform.position && sliding==false)
            {
                playMoveAudio(true);
            }
            //AkSoundEngine.PostEvent("player_push_trigger", gameObject)
        }

    }



    public void playMoveAudio(bool push_)
    {
        if(push_)
        {
            AkSoundEngine.PostEvent("player_push_trigger", gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, gameObject);
        }
        else
        {
            AkSoundEngine.PostEvent("object_slide_trigger", gameObject, (uint)AkCallbackType.AK_EndOfEvent, MyCallbackFunction, gameObject);
        }
    }


    void MyCallbackFunction(object in_cookie, AkCallbackType in_type, object in_info)

    {

        if (in_type == AkCallbackType.AK_EndOfEvent)
        {
            AkEventCallbackInfo info = (AkEventCallbackInfo)in_info; //Then do stuff.
        }

    }
}
