using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour {

    public GameObject Player1, Player2, Player3, Player4;
    string player1Nationality, player2Nationality, player3Nationality, player4Nationality;
    string nationality;
    // Use this for initialization
    void Start ()
    {
        //AkSoundEngine.PostEvent("stop_level_music", gameObject);
        //AkSoundEngine.StopAll();
        //Invoke("DelayMusicStart", 0.5f);
        AkSoundEngine.PostEvent("play_level_music", gameObject);
        AkSoundEngine.SetSwitch("Music_Transition", "Section1", gameObject);
        // Sets the  number of visible/ active players in the scene based on the numPlayer value passed from the main menu
        if (MenuScript.Instance.p1InGame == true)
        {
            Player1.gameObject.SetActive(true);
            nationality = MenuScript.Instance.GetAudioClass().GetNationality(1);
            switch (nationality)
            {
                case "Generic":
                    Player1.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUK");
                    break;
                case "American":
                    Player1.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUSA");
                    break;
                case "Indian":
                    Player1.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerIndia");
                    break;
                case "Chinese":
                    Player1.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerChina");
                    break;
            }
        }
        if(MenuScript.Instance.p1InGame == false)
        {
            Player1.gameObject.SetActive(false);
        }
        if(MenuScript.Instance.p2InGame == true)
        {
            Player2.gameObject.SetActive(true);
            nationality = MenuScript.Instance.GetAudioClass().GetNationality(2);
            switch (nationality)
            {
                case "Generic":
                    Player2.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUK");
                    break;
                case "American":
                    Player2.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUSA");
                    break;
                case "Indian":
                    Player2.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerIndia");
                    break;
                case "Chinese":
                    Player2.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerChina");
                    break;
            }
        }
        if (MenuScript.Instance.p2InGame == false)
        {
            Player2.gameObject.SetActive(false);
        }
        if (MenuScript.Instance.p3InGame == true)
        {
            Player3.gameObject.SetActive(true);
            nationality = MenuScript.Instance.GetAudioClass().GetNationality(3);
            switch (nationality)
            {
                case "Generic":
                    Player3.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUK");
                    break;
                case "American":
                    Player3.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUSA");
                    break;
                case "Indian":
                    Player3.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerIndia");
                    break;
                case "Chinese":
                    Player3.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerChina");
                    break;
            }
        }
        if (MenuScript.Instance.p3InGame == false)
        {
            Player3.gameObject.SetActive(false);
        }
        if (MenuScript.Instance.p4InGame == true)
        {
            Player4.gameObject.SetActive(true);
            nationality = MenuScript.Instance.GetAudioClass().GetNationality(4);
            switch (nationality)
            {
                case "Generic":
                    Player4.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUK");
                    break;
                case "American":
                    Player4.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerUSA");
                    break;
                case "Indian":
                    Player4.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerIndia");
                    break;
                case "Chinese":
                    Player4.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = Resources.Load<Material>("PlayerMaterials/PlayerChina");
                    break;
            }
        }
        if (MenuScript.Instance.p4InGame == false)
        {
            Player4.gameObject.SetActive(false);
        }



    }

    void DelayMusicStart()
    {
        AkSoundEngine.PostEvent("play_level_music", gameObject);
        AkSoundEngine.SetSwitch("Music_Transition", "Section1", gameObject);
    }
    public void ChangeTransition(string section)
    {
        AkSoundEngine.SetSwitch("Music_Transition", section, gameObject);
    }
}
