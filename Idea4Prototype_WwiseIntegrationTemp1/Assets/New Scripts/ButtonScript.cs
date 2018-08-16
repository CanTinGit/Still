using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public bool isBackButton, isResetButton, isGoToNextLevelButton, isHelpButton, isNextButton, isResumeButton;
    public GameObject pausePanel;
    public GameObject helpUI;
    PauseScript pause;
    // Use this for initialization
    void Start ()
    {
        if (isBackButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuScript.Instance.BackToMenu());
        }
        else if (isResetButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => ResetLevel());//MenuScript.Instance.ResetLevel());
        }
        else if (isGoToNextLevelButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => SetRatingOnBack());                   
        }
        else if (isHelpButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => HelpUI());
        }
        else if (isNextButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuScript.Instance.LoadNextLevel());
        }
        else if (isResumeButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => Unpause());//pause.UnPause());
        }
    }

    void Update()
    {
        //if(GameObject.Find("PausePanel"))
        //{
        //    if(updatePause == true)
        //    {
        //        if (GameObject.Find("Player1") != null || GameObject.Find("Player2") != null || GameObject.Find("Player3") != null || GameObject.Find("Player4") != null)
        //        {
        //            Debug.Log(pause);
        //            pause = GameObject.Find("Player" + MenuScript.Instance.pausePlayerNum).GetComponent<PauseScript>();
        //        }
        //    }
        //}
    }

    void Unpause()
    {
        GetPause();
        pause.UnPause();
    }

    PauseScript GetPause()
    {
        if (GameObject.Find("PausePanel"))
        {
            if (GameObject.Find("Player1") != null || GameObject.Find("Player2") != null || GameObject.Find("Player3") != null || GameObject.Find("Player4") != null)
            {
                Debug.Log(pause);
                pause = GameObject.Find("Player" + MenuScript.Instance.pausePlayerNum).GetComponent<PauseScript>();
                return pause;
            }            
        }
        //failed if returns null
        return null;
    }
    void ResetLevel()
    {
        AkSoundEngine.StopAll();
        MenuScript.Instance.ResetLevel();
    }
    void SetRatingOnBack()
    {
        //GameObject.FindWithTag("Timer").GetComponent<Timer>().SetTimer(0, 0, 0, 0);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreSystem>().LevelSkippedScore();
        MenuScript.Instance.FadeToNextLevel(GetPause().GetPausePanel());
    }
    void HelpUI()
    {
        ControllerStringToImage stringToImage = new ControllerStringToImage();
        if (helpUI.activeSelf == false)
        {
            helpUI.SetActive(true);
            //Interact
            helpUI.transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().sprite = stringToImage.ConvertStringToImage(MenuScript.Instance.GetPlayerKeys()[MenuScript.Instance.GetNumberofPlayers() - 1].GetKeys()[6].ToString());
            //Jump        
            helpUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = stringToImage.ConvertStringToImage(MenuScript.Instance.GetPlayerKeys()[MenuScript.Instance.GetNumberofPlayers() - 1].GetKeys()[5].ToString());
            //Throw
            helpUI.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().sprite = stringToImage.ConvertStringToImage(MenuScript.Instance.GetPlayerKeys()[MenuScript.Instance.GetNumberofPlayers() - 1].GetKeys()[4].ToString());
        }
        else
        {
            helpUI.SetActive(false);
        }
    }
	
}
