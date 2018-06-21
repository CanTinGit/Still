using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public bool isBackButton, isResetButton,isGoToNextLevelButton,isHelpButton;
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
            gameObject.GetComponent<Button>().onClick.AddListener(() => MenuScript.Instance.FadeToNextLevel());                   
        }
        else if (isHelpButton)
        {
            gameObject.GetComponent<Button>().onClick.AddListener(() => HelpUI());
        }
    }

    void HelpUI()
    {
        if (helpUI.active == false)
        {
            helpUI.SetActive(true);
            //Turn left
            helpUI.transform.GetChild(1).GetComponentInChildren<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[2].ToString();
            //Turn right
            helpUI.transform.GetChild(2).GetComponentInChildren<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[3].ToString();
            //Up
            helpUI.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[0].ToString();
            //Down
            helpUI.transform.GetChild(3).transform.GetChild(1).GetComponent<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[1].ToString();
            //Interact
            helpUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[6].ToString();
            //Jump
            helpUI.transform.GetChild(4).transform.GetChild(1).GetComponent<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[5].ToString();
            //Throw
            helpUI.transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = MenuScript.Instance.GetPlayerKeys().GetKeys()[4].ToString();
        }
        else
        {
            helpUI.SetActive(false);
        }
    }
	
}
