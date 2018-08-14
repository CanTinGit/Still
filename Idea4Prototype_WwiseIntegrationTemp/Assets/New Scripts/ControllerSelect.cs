using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

struct Flags
{
    string name;
    Sprite image;

    public void SetName(string name_)
    {
        name = name_;
        SetImage(name);
    }
    void SetImage(string name_)
    {
        image = Resources.Load<Sprite>("Flags/" + name_);
    }
    public string GetName()
    {
        return name;
    }
    public Sprite GetSprite()
    {
        return image;
    }

}

public class ControllerSelect : MonoBehaviour {

    Sprite selectedControlSprite;                         // Sprite for when a player has joined 
    Sprite deselectedControlSprite;                       // Sprite for when no player is selected
    Sprite Select, UnSelect;
    Material selectedPlayerMat;                    // Material for selected player
    public Material deselectedPlayerMat;                  // Material for de-selected player
    public bool isSelected;                               // Boolean to check if sprite should change
    public bool isInGame,controllerPressed;               // Boolean to check if the player has pressed play on select screen, i.e they are going to be playing
    PlayerKeys[] playerKeys;                              // Input key bindings
    public GameObject playerMesh;
    public float DelayReturnInput,FramePerSeconds;
    int playerNum;                                        // The number of the player this script is responsible for
    Flags[] flags;                                        // Array of the different flag choices
    int Choice = 0;                                       // Integer to score the current flag choice
    GameObject[] materialMeshs;
    public GameObject playerHalo, playButton;             // The selected player sprite and the play button sprite

    // Use this for initialization
    void Start ()                                                                                           // Initialise values for the player
    {
        playerNum = int.Parse(this.name.Remove(0, this.name.Length - 1));
        InitFlags();
        isInGame = false;                                                                                   // The player is not in the game to start, so set to false
        isSelected = false;                                                                                 // The player cannot have selected a character yet, so set to false
        Choice = 0;                                                                                         // Deselected is the default to start, which equals choice 0
        FramePerSeconds = 0.0166f;
        playerKeys = MenuScript.Instance.GetPlayerKeys();                                                   // Get the players personally defined Inputs
        DelayReturnInput = 0.5f;
        controllerPressed = false;                                                                          // Used for ensuring the controller doesn't cycle options too quickly
        selectedControlSprite = Resources.Load<Sprite>("UI/MenuSelectUI/Player" + playerNum + "_console");  // Set the selected control sprite to the appropriate controller Selector this script is attached to, i.e. player 1's selected sprite
        deselectedControlSprite = Resources.Load<Sprite>("UI/MenuSelectUI/Console_grey");                   // Set the deselected sprite to the generic deselected sprite   
        Select = Resources.Load<Sprite>("UI/MenuSelectUI/Select");                                          // The sprite for the image notifying the player they can select
        UnSelect = Resources.Load<Sprite>("UI/MenuSelectUI/Unselect");
    }

    void InitFlags()
    {
        flags = new Flags[5];                       // Set the names for the different flag options for the different nationalities
        flags[0].SetName("Null");
        flags[1].SetName("Generic");
        flags[2].SetName("Indian");
        flags[3].SetName("American");
        flags[4].SetName("Chinese");
    }

    void DelayInputBack()
    {
        //InvokeRepeating("JoystickInputCharacterSelect", 0.0f, FramePerSeconds);
        controllerPressed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isInGame == false)                                               // If the player has not "entered" the game
        {
            if (Input.GetAxis("Horizontal" + playerNum) > 0.8 || Input.GetAxis("Horizontal" + playerNum) < -0.8 || (Input.GetKeyDown(playerKeys[playerNum - 1].GetKeys()[3]) || Input.GetKeyDown(playerKeys[playerNum - 1].GetKeys()[2])))                 // If the player uses the left or right key bindings
            {
                if (controllerPressed == false)
                {
                    controllerPressed = true;

                    if (Input.GetAxis("Horizontal" + playerNum) > 0.8)          // If the player moves the joystick right, add to choice number
                    {
                        Choice++;
                        if (Choice > 4)                                         // If choice reaches the upper limit
                        {
                            Choice = 0;                                         // Set choice to lower limit
                        }
                    }
                    else if (Input.GetAxis("Horizontal" + playerNum) < -0.8)    // If the player moves the joystick left, take away from the choice number
                    {
                        Choice--;
                        if (Choice < 0)                                         // If choice reaches the lower limit
                        {
                            Choice = 4;                                         // set choice to the upper limit
                        }
                    }
                    if (Choice == 1)
                    {
                        isSelected = true;

                        selectedPlayerMat = Resources.Load<Material>("PlayerMaterials/PlayerUK");
                        this.GetComponent<Image>().sprite = selectedControlSprite;
                        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = true;       // Enable select UI message, as the player CAN select this character
                    }
                    else if(Choice == 2)
                    {
                        isSelected = true;

                        selectedPlayerMat = Resources.Load<Material>("PlayerMaterials/PlayerIndia");
                        this.GetComponent<Image>().sprite = selectedControlSprite;
                        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = true;       // Enable select UI message, as the player CAN select this character
                    }
                    else if (Choice == 3)
                    {
                        isSelected = true;

                        selectedPlayerMat = Resources.Load<Material>("PlayerMaterials/PlayerUSA");
                        this.GetComponent<Image>().sprite = selectedControlSprite;
                        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = true;       // Enable select UI message, as the player CAN select this character
                    }
                    else if (Choice == 4)
                    {
                        isSelected = true;

                        selectedPlayerMat = Resources.Load<Material>("PlayerMaterials/PlayerChina");
                        this.GetComponent<Image>().sprite = selectedControlSprite;
                        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = true;       // Enable select UI message, as the player CAN select this character
                    }
                    else if(Choice == 0)
                    {
                        isSelected = false;

                        selectedPlayerMat = deselectedPlayerMat;
                        this.GetComponent<Image>().sprite = deselectedControlSprite;                                // Changed controller sprite image to de-selected
                        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = false;
                    }
                    playerMesh.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                    playerMesh.gameObject.transform.Find("CountryFlag").GetComponent<Image>().sprite = flags[Choice].GetSprite();
                    Invoke("DelayInputBack", DelayReturnInput);
                }
            }
            if ((Input.GetButtonDown("Joystick" + playerNum + "Button0") || Input.GetKeyDown(KeyCode.Return)) && isSelected == true)     // If the character is selected and the start/join button is pressed
            {
                isInGame = true;                                            // Player is in game
                if (isInGame == true)
                {// Add 1 to the number of in game players for use by later scenes

                    playerMesh.GetComponent<Animator>().SetBool("Ready", true);                                     // Play ready animation
                    MenuScript.Instance.SetNumberofPlayers(1);                                                      // Add 1 to the number of players in game
                    MenuScript.Instance.SetPlayersInGame(playerNum, true);                                          // Set that player to true in later scenes
                    MenuScript.Instance.GetAudioClass().SetNationality(playerNum, flags[Choice].GetName());         // Set the player character voice to the nationality selected in this menu
                    playerHalo.gameObject.SetActive(true);                                                          // Show the selected halo, highlighting the player has selected a character & voice
                    this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = false;          // Set the select message to invisible as the player can now no longer select a player (unless they press back)
                    playerMesh.transform.Find("SelectArrows" + playerNum).GetComponent<Image>().enabled = false;    // Set the selected arrows to invisible for the same reason as above
                }


            }
        }

            if(Input.GetButtonDown("Joystick" + playerNum + "Button1"))                 //The back button is pressed
            {
                if(isInGame == true)                                                         //If the player has selected a character, de-select them
                {
                    MenuScript.Instance.SetNumberofPlayers(-1);                         // Take 1 off the players in game
                    MenuScript.Instance.SetPlayersInGame(playerNum, false);
                    playerHalo.gameObject.SetActive(false);                             // Turn the selected halo off
                    this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = true;       // Show the select UI
                    isInGame = false;
                    playerMesh.GetComponent<Animator>().SetBool("Ready", false);                                // make the animation return to idle
                    this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().sprite = Select;
            }
                else
                {                                                                           // Else they are not in the game and wish to return to the previous screen
                    ResetPlayer();                                                          // Reset the player to initial un selected values
                    MenuScript.Instance.ReturntoMainMenu();
                }
                
            }
            if(isInGame == true)
            {
                if(Input.GetButtonDown("Joystick" + playerNum + "Button0"))                 // If A button is pressed
                {
                    if (playButton.activeSelf == true)               // Move to the next screen if the play button is visible
                    {
                        MenuScript.Instance.ContinuePressed();
                    }
                }
            }
        }
    
    void SelectChange()
    {
        if(controllerPressed == false)
        {
                controllerPressed = true;
           
            if (isSelected == false)                                    // If the selected sprite isnt showing
            {
                isSelected = true;                                      // Set selected boolean to true
            }
            else
            {
                isSelected = false;                                                 // Else, i.e isSelected is true
            }
            Invoke("DelayInputBack", DelayReturnInput);
        }
        

    }
    
    public void ResetPlayer()                                           // Reset all appropriate values to their initial state, i.e. return to if the game was just started
    {
        isSelected = false;
        isInGame = false;
        Choice = 0;
        playerHalo.SetActive(false);
        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().sprite = Select;
        this.gameObject.transform.Find("SelectMessage").GetComponent<Image>().enabled = false;
        MenuScript.Instance.SetTotalNumberofPlayers(0);
        MenuScript.Instance.SetPlayersInGame(playerNum, false);
        playerMesh.gameObject.transform.Find("CountryFlag").GetComponent<Image>().sprite = flags[Choice].GetSprite();
        playerMesh.transform.Find("SelectArrows" + playerNum).GetComponent<Image>().enabled = true;


        selectedPlayerMat = deselectedPlayerMat;
        playerMesh.transform.Find("Mice_01_Low:polySurface1").GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
        this.GetComponent<Image>().sprite = deselectedControlSprite;
    }
    void CheckControllersConnected()
    {
        string[] controllers = Input.GetJoystickNames();
        //Iterate over every element
        for (int i = 0; i < controllers.Length; ++i)
        {
            //Check if the string is empty or not
            if (!string.IsNullOrEmpty(controllers[i]))
            {
                // Debug.Log(controllers[i]) ;
                //Not empty, controller temp[i] is connected
                //Debug.Log("Controller " + i + " is connected using: " + controllers[i]);
                if (i == (playerNum - 1))
                {

                    this.GetComponent<Image>().sprite = selectedControlSprite;
                }
            }
            else
            {
                //If it is empty, controller i is disconnected
                //where i indicates the controller number
                //Debug.Log("Controller: " + i + " is disconnected.");
                if (i == (playerNum - 1))
                {
                    this.GetComponent<Image>().sprite = deselectedControlSprite;
                   // playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
                    Choice = 0;
                   // playerSprite.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = flags[Choice].GetSprite();
                    if (isInGame == true)
                    {
                        isInGame = false;
                        MenuScript.Instance.SetNumberofPlayers(-1);
                        MenuScript.Instance.SetPlayersInGame(playerNum, false);
                    }
                        
                    isSelected = false;
                    this.GetComponentInChildren<Text>().enabled = false;
                    
                }

            }
        }
    }
}

