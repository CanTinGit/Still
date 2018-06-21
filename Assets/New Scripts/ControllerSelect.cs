using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSelect : MonoBehaviour {

    public Sprite selectedControlSprite;                // Sprite for when a player has joined 
    public Sprite deselectedControlSprite;              // Sprite for when no player is selected
    public Sprite selectedPlayerSprite;                 // Sprite for selected player
    public Sprite deselectedPlayerSprite;               // Sprite for de-selected player
    bool isSelected;                                    // Boolean to check if sprite should change
    public bool isInGame,pressed123;                               // Boolean to check if the player has pressed play on select screen, i.e they are going to be playing
    PlayerKeys playerKeys;                              // Input key bindings
    public GameObject playerSprite;                     // Reference to player sprite
    public float DelayReturnInput,FramePerSeconds;
    // Use this for initialization
    void Start ()
    {
        isInGame = false;
        isSelected = false;
        FramePerSeconds = 0.0166f;
        playerKeys = MenuScript.Instance.GetPlayerKeys();
        //InvokeRepeating("JoystickInputCharacterSelect", 0.0f, FramePerSeconds);
        DelayReturnInput = 0.5f;
        pressed123 = false;



    }
	void JoystickInputCharacterSelect()
    {
        Debug.Log(MenuScript.Instance.GetNumberofPlayers());
        if (isInGame == false)                                               // If the player has not "entered" the game
        {
            //Debug.Log(Input.GetAxis("XboxLeftStickXaxis"));
            if (Input.GetAxis("XboxLeftStickXaxis") == 1  || Input.GetAxis("XboxLeftStickXaxis") == -1 || (Input.GetKeyDown(playerKeys.GetKeys()[3]) || Input.GetKeyDown(playerKeys.GetKeys()[2])) )                  // If the player uses the left or right key bindings
            {
                ChangeSprite(isSelected);
            }
            
            
        }
        if ((Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.Return)) && isSelected == true)     // If the character is selected and the start/join button is pressed
        {
            isInGame = !isInGame;                                            // Player is in game
            if (isInGame == true)
            {// Add 1 to the number of in game players for use by later scenes
                MenuScript.Instance.SetNumberofPlayers(1);
            }
            else
            {
                MenuScript.Instance.SetNumberofPlayers(-1);
            }
        }
    }

    void ChangeSprite(bool isSelected_)
    {
        CancelInvoke("JoystickInputCharacterSelect");
        isSelected = isSelected_;
        if (isSelected == false)                                    // If the selected sprite isnt showing
        {
            isSelected = true;                                      // Set selected boolean to true
            this.GetComponent<Image>().sprite = selectedControlSprite;          // Set selected controller sprite
            playerSprite.GetComponent<Image>().sprite = selectedPlayerSprite;   // Set selected chr                 
        }
        else
        {
            isSelected = false;                                                 // Else, i.e isSelected is true
            this.GetComponent<Image>().sprite = deselectedControlSprite;        // Set deselected controller sprite
            playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
        }
        Invoke("DelayInputBack", DelayReturnInput);

    }

    void DelayInputBack()
    {
        //InvokeRepeating("JoystickInputCharacterSelect", 0.0f, FramePerSeconds);
        pressed123 = false;
    }
	// Update is called once per frame
	void Update ()
    {
        //Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow);
        if (isInGame == false)                                               // If the player has not "entered" the game
        {
            //Debug.Log(Input.GetAxis("XboxLeftStickXaxis"));
            if (Input.GetAxis("XboxLeftStickXaxis") == 1 || Input.GetAxis("XboxLeftStickXaxis") == -1 || (Input.GetKeyDown(playerKeys.GetKeys()[3]) || Input.GetKeyDown(playerKeys.GetKeys()[2])))                 // If the player uses the left or right key bindings
            {
                //pressed123 = true;
                Code();
                //if (isSelected == false)                                    // If the selected sprite isnt showing
                //{
                //    isSelected = true;                                      // Set selected boolean to true
                //    this.GetComponent<Image>().sprite = selectedControlSprite;          // Set selected controller sprite
                //    playerSprite.GetComponent<Image>().sprite = selectedPlayerSprite;   // Set selected chr

                //}
                //else
                //{
                //    isSelected = false;                                                 // Else, i.e isSelected is true
                //    this.GetComponent<Image>().sprite = deselectedControlSprite;        // Set deselected controller sprite
                //    playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
                //}
            }
            //if (Input.GetButtonDown("Start") && isSelected == true)     // If the character is selected and the start/join button is pressed
            //{
            //    isInGame = true;                                            // Player is in game
            //    // Add 1 to the number of in game players for use by later scenes
            //    MenuScript.Instance.SetNumberofPlayers(1);
            //}
        }
        if ((Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.Return)) && isSelected == true)     // If the character is selected and the start/join button is pressed
        {
            isInGame = !isInGame;                                            // Player is in game
            if (isInGame == true)
            {// Add 1 to the number of in game players for use by later scenes
                MenuScript.Instance.SetNumberofPlayers(1);
                this.GetComponentInChildren<Text>().enabled = true;

            }
            else
            {
                MenuScript.Instance.SetNumberofPlayers(-1);
                this.GetComponentInChildren<Text>().enabled = false;
            }
        }
    }

    void Code()
    {
        if(pressed123==false)
        {
            pressed123 = true;
           
            if (isSelected == false)                                    // If the selected sprite isnt showing
            {
                isSelected = true;                                      // Set selected boolean to true
                this.GetComponent<Image>().sprite = selectedControlSprite;          // Set selected controller sprite
                playerSprite.GetComponent<Image>().sprite = selectedPlayerSprite;   // Set selected chr
                

            }
            else
            {
                isSelected = false;                                                 // Else, i.e isSelected is true
                this.GetComponent<Image>().sprite = deselectedControlSprite;        // Set deselected controller sprite
                playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
                
            }
            Invoke("DelayInputBack", DelayReturnInput);
        }
        

    }
}
