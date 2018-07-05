using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public bool isBackButton, isResetButton,isGoToNextLevelButton,isHelpButton;
    public GameObject pausePanel;
    public GameObject helpUI;
	// Use this for initialization
	void Start ()
    {
        if (isBackButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuScript.Instance.BackToMenu());
        }
        else if (isResetButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuScript.Instance.ResetLevel());
        }
        else if (isGoToNextLevelButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuScript.Instance.FadeToNextLevel(pausePanel));                   
        }
        else if (isHelpButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => HelpUI());
        }
    }
    void HelpUI()
    {
        ControllerStringToImage stringToImage = new ControllerStringToImage();
        if (helpUI.active == false)
        {
            Debug.Log(MenuScript.Instance.pausePlayerNum - 1);
            helpUI.SetActive(true);        
            //Interact
            helpUI.transform.GetChild(2).transform.GetChild(1).GetComponent<Image>().sprite = stringToImage.ConvertStringToImage(MenuScript.Instance.GetPlayerKeys()[MenuScript.Instance.pausePlayerNum - 1].GetKeys()[6].ToString());
            //Jump        
            helpUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = stringToImage.ConvertStringToImage(MenuScript.Instance.GetPlayerKeys()[MenuScript.Instance.pausePlayerNum - 1].GetKeys()[5].ToString());
            //Throw
            helpUI.transform.GetChild(2).transform.GetChild(2).GetComponent<Image>().sprite = stringToImage.ConvertStringToImage(MenuScript.Instance.GetPlayerKeys()[MenuScript.Instance.pausePlayerNum - 1].GetKeys()[4].ToString());
        }
        else
        {
            helpUI.SetActive(false);
        }
    }
	
}
