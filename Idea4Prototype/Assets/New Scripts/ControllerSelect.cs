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

    Sprite selectedControlSprite;                // Sprite for when a player has joined 
    Sprite deselectedControlSprite;              // Sprite for when no player is selected
    public Material selectedPlayerMat;                 // Material for selected player
    public Material deselectedPlayerMat;               // Material for de-selected player
    bool isSelected;                                    // Boolean to check if sprite should change
    public bool isInGame,controllerPressed;                               // Boolean to check if the player has pressed play on select screen, i.e they are going to be playing
    PlayerKeys[] playerKeys;                              // Input key bindings
    public GameObject playerMesh;
    public GameObject playerMesh1, playerMesh2, playerMesh3, playerMesh4, playerMesh5, playerMesh6, playerMesh7, playerMesh8, playerMesh9, playerMesh10, playerMesh11;   // Reference to player meshs'
    public GameObject playerMesh12, playerMesh13, playerMesh14, playerMesh15, playerMesh16, playerMesh17, playerMesh18, playerMesh19, playerMesh20, playerMesh21, playerMesh22;
    public float DelayReturnInput,FramePerSeconds;
    int playerNum;
    Flags[] flags;
    int Choice = 0;
    GameObject[] materialMeshs;

    // Use this for initialization
    void Start ()
    {
       // InvokeRepeating("CheckControllersConnected", 0.0f, 1.0f);
        InitFlags();
        isInGame = false;
        isSelected = false;
        FramePerSeconds = 0.0166f;
        playerKeys = MenuScript.Instance.GetPlayerKeys();
        //InvokeRepeating("JoystickInputCharacterSelect", 0.0f, FramePerSeconds);
        DelayReturnInput = 0.5f;
        controllerPressed = false;
        selectedControlSprite = Resources.Load<Sprite>("UI/MenuSelectUI/PS_controller");
        deselectedControlSprite = Resources.Load<Sprite>("UI/MenuSelectUI/PS_controllerUnknown");
       // selectedPlayerMat = Resources.Load<Material>("Assets/Models/Player/Materials/Player " + this.transform.parent.name.Remove(0,this.transform.parent.name.Length-1) );
       // deselectedPlayerMat = Resources.Load<Material>("Assets/Materials/Glass_Mat");

        playerNum = int.Parse(this.transform.parent.name.Remove(0, this.transform.parent.name.Length - 1));
        //Debug.Log(playerNum);
    }

    void InitFlags()
    {
        flags = new Flags[5];
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
        //CheckControllersConnected();

        //Debug.Log(controllers[playerNum - 1].ToString());
        //if (controllers[playerNum - 1] != "")
        //{
        //    this.GetComponent<Image>().sprite = selectedControlSprite;
        //}
        //else
        //{
        //    this.GetComponent<Image>().sprite = deselectedControlSprite;
        //}
        //Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow);
        if (isInGame == false)                                               // If the player has not "entered" the game
        {
            //Debug.Log(Input.GetAxis("Horizontal" + playerNum));
            if (Input.GetAxis("Horizontal" + playerNum) > 0.8 || Input.GetAxis("Horizontal" + playerNum) < -0.8 || (Input.GetKeyDown(playerKeys[playerNum - 1].GetKeys()[3]) || Input.GetKeyDown(playerKeys[playerNum - 1].GetKeys()[2])))                 // If the player uses the left or right key bindings
            {
                Debug.Log(playerNum + " pressed left or right");
                if (controllerPressed == false)
                {
                    controllerPressed = true;

                    if (Input.GetAxis("Horizontal" + playerNum) > 0.8)
                    {
                        Choice++;
                        if (Choice > 4)
                        {
                            Choice = 0;
                        }
                    }
                    else if (Input.GetAxis("Horizontal" + playerNum) < -0.8)
                    {
                        Choice--;
                        if (Choice < 0)
                        {
                            Choice = 4;
                        }
                    }
                    if(Choice!=0)
                    {
                        isSelected = true;
                        playerMesh1.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh2.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh3.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh4.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh5.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh6.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh7.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh8.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh9.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh10.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh11.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh12.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh13.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh14.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh15.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh16.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh17.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh18.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh19.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh20.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh21.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        playerMesh22.GetComponent<SkinnedMeshRenderer>().material = selectedPlayerMat;
                        //playerMesh.GetComponent<Image>().sprite = selectedPlayerMat; // Set selected chr material on player mesh
                    }
                    else
                    {
                        isSelected = false;
                        playerMesh1.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh2.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh3.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh4.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh5.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh6.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh7.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh8.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh9.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh10.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh11.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh12.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh13.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh14.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh15.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh16.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh17.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh18.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh19.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh20.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh21.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        playerMesh22.GetComponent<SkinnedMeshRenderer>().material = deselectedPlayerMat;
                        //playerMesh.GetComponent<Image>().sprite = deselectedPlayerMat; // Set deselected player material on player mesh
                    }
                    playerMesh.gameObject.transform.Find("CountryFlag").GetComponent<Image>().sprite = flags[Choice].GetSprite();
                    Invoke("DelayInputBack", DelayReturnInput);
                }



                //if (controllerPressed == false)
                //{
                //    controllerPressed = true;

                //    if (isSelected == false)                                    // If the selected sprite isnt showing
                //    {
                //        isSelected = true;                                      // Set selected boolean to true
                //                                                                //  this.GetComponent<Image>().sprite = selectedControlSprite;          // Set selected controller sprite
                //        playerSprite.GetComponent<Image>().sprite = selectedPlayerSprite;   // Set selected chr


                //    }
                //    else
                //    {
                //        isSelected = false;                                                 // Else, i.e isSelected is true
                //                                                                            // this.GetComponent<Image>().sprite = deselectedControlSprite;        // Set deselected controller sprite
                //        playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite

                //    }
                //    Invoke("DelayInputBack", DelayReturnInput);

                //}
                    //pressed123 = true;
                    //SelectChange();
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
            if ((Input.GetButtonDown("Start" + playerNum) || Input.GetKeyDown(KeyCode.Return)) && isSelected == true)     // If the character is selected and the start/join button is pressed
            {
                isInGame = !isInGame;                                            // Player is in game
                if (isInGame == true)
                {// Add 1 to the number of in game players for use by later scenes
                    this.GetComponent<Image>().sprite = selectedControlSprite;
                    MenuScript.Instance.SetNumberofPlayers(1);
                    this.GetComponentInChildren<Text>().enabled = true;
                    MenuScript.Instance.SetPlayersInGame(playerNum, true);
                    MenuScript.Instance.GetAudioClass().SetNationality(playerNum, flags[Choice].GetName());
                    playerMesh.GetComponent<Animator>().SetBool("Ready", true);
                }
                else
                {
                    MenuScript.Instance.SetNumberofPlayers(-1);
                    MenuScript.Instance.SetPlayersInGame(playerNum, false);
                    this.GetComponentInChildren<Text>().enabled = false;
                    this.GetComponent<Image>().sprite = deselectedControlSprite;
                    playerMesh.GetComponent<Animator>().SetBool("Ready", false);
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
              //  this.GetComponent<Image>().sprite = selectedControlSprite;          // Set selected controller sprite
               // playerSprite.GetComponent<Image>().sprite = selectedPlayerSprite;   // Set selected chr
                

            }
            else
            {
                isSelected = false;                                                 // Else, i.e isSelected is true
               // this.GetComponent<Image>().sprite = deselectedControlSprite;        // Set deselected controller sprite
               // playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
                
            }
            Invoke("DelayInputBack", DelayReturnInput);
        }
        

    }
    
    void CheckControllersConnected()
    {
        //List<string> controllers = new List<string>();
        //// Debug.Log("controller string" + controllers.Length);
        ////Debug.Log("joystick string" + Input.GetJoystickNames().Length);
        //foreach(string item in Input.GetJoystickNames())
        //{
        //    if(item !="")
        //    {
        //        controllers.Add(item);
        //    }
        //}
        ////Check whether array contains anything
        //if (controllers.Count > 0)
        //{
        //    for(int i =0; i< 4;i++)
        //    {
        //        if(i < controllers.Count)
        //        {
        //            //if (controller[i]!=null)
        //            {
        //                this.GetComponent<Image>().sprite = selectedControlSprite;
        //            }
        //        }
        //        else
        //        {
        //            //        //If it is empty, controller i is disconnected
        //            //        //where i indicates the controller number
        //            //        //Debug.Log("Controller: " + i + " is disconnected.");
        //            //        if(i == (playerNum - 1))
        //            //        {
        //            this.GetComponent<Image>().sprite = deselectedControlSprite;
        //            playerSprite.GetComponent<Image>().sprite = deselectedPlayerSprite; // Set deselected player sprite
        //            Choice = 0;
        //            playerSprite.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = flags[Choice].GetSprite();
        //            isInGame = false;
        //            isSelected = false;
        //            this.GetComponentInChildren<Text>().enabled = false;
        //            //        }
        //        }

        //    }
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

