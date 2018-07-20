using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
public class MenuScript : MonoBehaviour
{
    //keep information on pannels and 3 buttons which is required for when we are switching to different screens ( options , home , level select)
    GameObject LevelSelectPanel, OptionPanel, CharacterPanel, PlayButton, CloseButton, OptionButton, ContinueButton, Level1Button, Level2Button;
    //the pathway to the text file which stores what levels are in the scene
    string LevelTextPath;
    //the file to be opened that stores what levels are to be shown in level select screen
    protected FileInfo theFile = null;
    //streamReader for actually passing the file to be read through
    protected StreamReader textReader = null;
    //singleton of the menu script so we can move between levels and get players keys
    private static MenuScript _instance;
    //boolean to control if we are waiting for a key press
    bool waitingForKeyPress = false;
    //stores information on what button has been pressed
    GameObject pressedButton = null;
    //stores information of what key was pressed
    KeyCode keyPressed;
    //declaration of the player keys class
    PlayerKeys[] playerSetting = new PlayerKeys[4];
    //OLD WAY TO RECORD PLAYER CURRENT LEVEL
    int maxLevel;
    //NEW WAY TO RECORD PLAYER CURRENT LEVEL
    public PlayerData playerdata;
    int numPlayers;
    //the animator for the screen fade to level effect
    Animator sceneFade;
    // Reference to event system for menu navigation
    GameObject eventSystem;
    //the player that pauses the screen
    public int pausePlayerNum = 0;
    //if the game is paused
    public bool gamePaused = false;
    //What each player controller settings is
    int whichPlayerKey;
    //Global variable to get the only one game manager
    GameObject hoveringOver;
    // Booleans to control what players should be visible in game
    public bool p1InGame, p2InGame, p3InGame, p4InGame;
    //hold the AudioClass which stores all the information to control audio
    AudioClass audioClass;
    public static MenuScript Instance
    {
        get
        {
            if (_instance == null)
            {
                if (GameObject.Find("GameManager") == null)
                {
                    GameObject gm = new GameObject("GameManager");
                    gm.AddComponent<MenuScript>();
                    gm.tag = "GameManager";
                }
            }
            return _instance;
        }
    }
    //returns the player settings stored in the singleton
    public PlayerKeys[] GetPlayerKeys()
    {
        return playerSetting;
    }
    //on awake we intialise the player settings which is the default values and also set up the singleton
    void Awake()
    {
        audioClass = new AudioClass();
        audioClass.InitialiseAudioClass();
        playerdata = new PlayerData();
        for (int i =0; i < playerSetting.Length;i++)
        {
            playerSetting[i] = new PlayerKeys();
            playerSetting[i].IntialiseValues();
        }
        GameObject gm = GameObject.Find("GameManager");
        if (gm != null)
        {
            DontDestroyOnLoad(gm.gameObject);
            _instance = gm.GetComponent<MenuScript>();
        }
        IntialiseAndSetScene();
        LoadPlayerData();
        //Set the max level by the player data
        maxLevel = playerdata.getCurrentLevel();
        whichPlayerKey = 0;
        hoveringOver = eventSystem.GetComponent<EventSystem>().currentSelectedGameObject;

    }
    void Start()
    {
        InvokeRepeating("CheckToPlayHoverSound", 0.0f, 0.02f);
        AkSoundEngine.PostEvent("play_intro", gameObject);

    }

    public AudioClass GetAudioClass()
    {
        return audioClass;
    }

    void CheckToPlayHoverSound()
    {
        if(eventSystem!=null)
        {
            if (hoveringOver != eventSystem.GetComponent<EventSystem>().currentSelectedGameObject)
            {
                AkSoundEngine.PostEvent("hover", gameObject);
                hoveringOver = eventSystem.GetComponent<EventSystem>().currentSelectedGameObject;
            }
        }
    }
    //intialising variables and setting up gameobjects and how the home screen should look like
    public void IntialiseAndSetScene()
    {
        //set up all the buttons in the scene
        SetUpButton();
        //set up the file pathway
        LevelTextPath = Application.dataPath + "/StreamingAssets/LevelList.txt";
        //set all the panels and buttons to the correct gameobject
        LevelSelectPanel = GameObject.Find("LevelSelectPanel");
        OptionPanel = GameObject.Find("OptionPanel");
        CharacterPanel = GameObject.Find("CharacterSelectPanel");
        PlayButton = GameObject.Find("PlayButton");
        OptionButton = GameObject.Find("OptionButton");
        CloseButton = GameObject.Find("CloseButton");
        ContinueButton = GameObject.Find("ContinueButton");
        eventSystem = GameObject.Find("EventSystem");
      //  Level1Button = GameObject.Find("Level 1 Button");
       // Level2Button = GameObject.Find("Level 2 Button");
        //flip the level and options panel off so they can not be seen
        FlipLevelPanel();
        FlipOptionPanel();
        FlipCharacterPanel();


    }
    //flips the level panel to the opposite state
    void FlipLevelPanel()
    {
        LevelSelectPanel.gameObject.SetActive(!LevelSelectPanel.activeSelf);
    }
    //flips the option panel to the opposite state
    void FlipOptionPanel()
    {
        OptionPanel.gameObject.SetActive(!OptionPanel.activeSelf);
    }
    void FlipCharacterPanel()
    {
        CharacterPanel.gameObject.SetActive(!CharacterPanel.activeSelf);
    }
    //runs this function whent he close button is pressed in the options panel
    public void CloseButtonPressed()
    {
        //flip the options off
        FlipOptionPanel();
        //flip the menu buttons
        FlipMenuButtons();
        //reset the temporary keys to the custom keys ( the keys that are set the player and saved)
        playerSetting[whichPlayerKey].ResetTempKeysToCustom();

        // Set main menu's play button to controller input focus
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("PlayButton"));
    }
    //run the function when play button is pressed
    public void PlayPressed()
    {
        //flip the character panel on and flip off the menu button
        FlipCharacterPanel();
        AkSoundEngine.PostEvent("game_start", gameObject);
        AkSoundEngine.SetRTPCValue("click_start", 0f, null, 1000);
        FlipMenuButtons();
        //Set the navigable buttons to the character screen buttons
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ContinueButton"));

    }
    // Run the function when the continue button is pressed on the character screen
    public void ContinuePressed()
    {
        if (numPlayers > 0)                     // Level select can only be moved onto if at least one player has joined the game
        {
            // Flip the character panel off and the level panel on
            FlipCharacterPanel();
            FlipLevelPanel();

            //REMOVED MAYBE SINCE NO LEVEL PANEL ANYMORE AND STATIC
            //read the file containing the levels to be run
            //ReadFile();

            eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ReturnToMenuButton"));
        }
    }
    void ReturntoMainMenu()
    {
        AkSoundEngine.PostEvent("click_back", gameObject);
        FlipCharacterPanel();
        FlipMenuButtons();
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("PlayButton"));
        AkSoundEngine.SetRTPCValue("click_start", 100f, null, 500);
        AkSoundEngine.PostEvent("play_intro", gameObject);

    }
    //sets up all the buttons based on what is passed in
    void SetUpButton()
    {
        FindButtonAddListener(GameObject.Find("ResetButton"));
        FindButtonAddListener(GameObject.Find("ApplyButton"));
        FindButtonAddListener(GameObject.Find("CloseOptionButton"));
        FindButtonAddListener(GameObject.Find("CloseButton"));
        FindButtonAddListener(GameObject.Find("PlayButton"));
        FindButtonAddListener(GameObject.Find("OptionButton"));
        FindButtonAddListener(GameObject.Find("PickUpButton"));
        FindButtonAddListener(GameObject.Find("ForwardKeyButton"));
        FindButtonAddListener(GameObject.Find("BackwardKeyButton"));
        FindButtonAddListener(GameObject.Find("LeftButton"));
        FindButtonAddListener(GameObject.Find("RightButton"));
        FindButtonAddListener(GameObject.Find("ThrowButton"));
        FindButtonAddListener(GameObject.Find("JumpButton"));
        FindButtonAddListener(GameObject.Find("ReturnToMenuButton"));
        FindButtonAddListener(GameObject.Find("ContinueButton"));
        FindButtonAddListener(GameObject.Find("ReturnToSplashScreen"));
        FindButtonAddListener(GameObject.Find("RightChangeCharButton"));
        FindButtonAddListener(GameObject.Find("LeftChangeCharButton"));
        FindButtonAddListener(GameObject.Find("Level 1 Button"));
        FindButtonAddListener(GameObject.Find("Level 2 Button"));
        FindButtonAddListener(GameObject.Find("Level 0 Button"));
    }
    //when the return button is pressed in the level select screen
    void ReturnToMenuPressed()
    {
        //empty the level list
        //EmptyLevelList();
        //flip the level panel off
        FlipLevelPanel();
        //flip the menu buttons off
        FlipMenuButtons();
        AkSoundEngine.PostEvent("click_back", gameObject);
        AkSoundEngine.SetRTPCValue("click_start", 100f, null, 500);
        AkSoundEngine.PostEvent("play_intro", gameObject);
        Debug.Log("Return");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("PlayButton"));

    }
    //clear the level list
    void EmptyLevelList()
    {
        GameObject ContentHolder = GameObject.FindGameObjectWithTag("ContentHolder");
        Button[] Levels = ContentHolder.GetComponentsInChildren<Button>();
        foreach (Button level in Levels)
        {
            Destroy(level.gameObject);
        }
    }
    //takes the button that is passed in and adds a listener to the correct function
    void FindButtonAddListener(GameObject button_)
    {
        Button button = button_.GetComponent<Button>();
        switch (button.name)
        {
            case "ResetButton":
                button.onClick.AddListener(() => MenuScript.Instance.ResetPressed());
                break;
            case "ApplyButton":
                button.onClick.AddListener(() => MenuScript.Instance.OptionApplyButton());
                break;
            case "CloseOptionButton":
                button.onClick.AddListener(() => MenuScript.Instance.CloseButtonPressed());
                break;
            case "CloseButton":
                button.onClick.AddListener(() => MenuScript.Instance.QuitApplication());
                break;
            case "PlayButton":
                button.onClick.AddListener(() => MenuScript.Instance.PlayPressed());
                break;
            case "OptionButton":
                button.onClick.AddListener(() => MenuScript.Instance.OptionPressed());
                break;
            case "PickUpButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "ForwardKeyButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "BackwardKeyButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "LeftButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "RightButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "ThrowButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "JumpButton":
                button.onClick.AddListener(() => MenuScript.Instance.KeyBindingButtonPressed(button_));
                break;
            case "ReturnToMenuButton":
                button.onClick.AddListener(() => MenuScript.Instance.ReturnToMenuPressed());
                break;
            case "ContinueButton":
                button.onClick.AddListener(() => MenuScript.Instance.ContinuePressed());
                break;
            case "ReturnToSplashScreen":
                button.onClick.AddListener(() => MenuScript.Instance.ReturntoMainMenu());
                break;
            case "RightChangeCharButton":
                button.onClick.AddListener(() => MenuScript.Instance.SwitchPlayer(1,button.transform.parent.GetChild(0).GetComponent<Text>()));
                break;
            case "LeftChangeCharButton":
                button.onClick.AddListener(() => MenuScript.Instance.SwitchPlayer(-1, button.transform.parent.GetChild(0).GetComponent<Text>()));
                break;
            case "Level 1 Button":
                button.onClick.AddListener(() => MenuScript.Instance.LoadLevel("level_1"));
                break;
            case "Level 2 Button":
                button.onClick.AddListener(() => MenuScript.Instance.LoadLevel("level_2"));
                break;
            case "Level 0 Button":
                button.onClick.AddListener(() => MenuScript.Instance.LoadLevel("Tutorial_Level"));
                break;
        }
    }
    // runs this function when the reset to default function is pressed
    public void ResetPressed()
    {
        //gets the keybindings and stats pannels
        GameObject keybindingPanel = GameObject.FindGameObjectWithTag("KeybindingPanel");
        GameObject StatsPanel = GameObject.FindGameObjectWithTag("StatsPanel");
        //goes through each key in the panel and set it to the correct default key to show
        for (int arraySize = 0; arraySize < playerSetting[whichPlayerKey].GetDefaultKeys().Length; arraySize++)
        {
            keybindingPanel.transform.GetChild(arraySize).GetComponentInChildren<Text>().text = playerSetting[whichPlayerKey].GetDefaultKeys()[arraySize].ToString();
        }
        //set each stat panel information to the default stat option
        StatsPanel.transform.GetChild(0).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetDefaultMoveSpeed().ToString();
        StatsPanel.transform.GetChild(1).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetDefaultTurnSpeed().ToString();
        StatsPanel.transform.GetChild(2).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetDefaultThrowPower().ToString();
        StatsPanel.transform.GetChild(3).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetDefaultJumpPower().ToString();
        //reset all the temp keys to the default keys
        playerSetting[whichPlayerKey].ResetTempKeysToDefault();
    }
    //this shows all the current set key binds and also all the set player stats
    void GetOptions()
    {
        GameObject keybindingPanel = GameObject.FindGameObjectWithTag("KeybindingPanel");
        GameObject StatsPanel = GameObject.FindGameObjectWithTag("StatsPanel");
        StatsPanel.transform.parent.GetChild(2).GetChild(0).GetComponent<Text>().text = "Player " + (whichPlayerKey+1) + " keys";
        for (int arraySize = 0; arraySize < playerSetting[whichPlayerKey].GetKeys().Length; arraySize++)
        {
            keybindingPanel.transform.GetChild(arraySize).GetComponentInChildren<Text>().text = playerSetting[whichPlayerKey].GetKeys()[arraySize].ToString();
        }
        StatsPanel.transform.GetChild(0).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetMoveSpeed().ToString();
        StatsPanel.transform.GetChild(1).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetTurnSpeed().ToString();
        StatsPanel.transform.GetChild(2).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetThrowPower().ToString();
        StatsPanel.transform.GetChild(3).GetComponent<InputField>().text = playerSetting[whichPlayerKey].GetJumpPower().ToString();
    }
    //run this function we the option button is pressed
    public void OptionPressed()
    {
        //flip the options menu on
        FlipOptionPanel();
        //flip the menu buttons off
        FlipMenuButtons();
        //get all the options
        GetOptions();
        Debug.Log(GameObject.Find("ApplyButton"));
        // Set options screen buttons selectible via controller input
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("ApplyButton"));
        AkSoundEngine.PostEvent("click_positive", gameObject);



    }
    //function runs and reads the file and then displays each level within the level
    void ReadFile()
    {
        //counter for the level to be shown
        int level = 0;
        //open the file and start reading it
        theFile = new FileInfo(LevelTextPath);
        textReader = new StreamReader(LevelTextPath, Encoding.Default);
        //make a empty string to hold the level name
        string text = null;
        //stay in the loop until we hit the "END" keyword
        while (text != "END")
        {
            //set the text string to the line that is to be read
            text = textReader.ReadLine(); //moves onto the next line and reads it
            //if the text is not the keyword then make a button with that level's name
            if (text != "END")
            {
                //creates a button with that string name
                MakeLevelButton(text);
                //increment the counter
                level++;
                // if we hit the max levels to be shown then return to leave the readfile function
                if (level == maxLevel)
                {
                    textReader.Close();
                    return;
                }
            }
        }
        //textReader.Close(); may not need since we always hitting max level
    }
    void MakeLevelButton(string levelName)
    {
        //finds the panel in the scene so we can assign the button as a child of panel
        GameObject contentHolder = GameObject.FindGameObjectWithTag("ContentHolder");
        //find out how many responses there are
        Button button = Resources.Load<Button>("LevelButton");
        Button newButton = Instantiate(button);
        newButton.name = levelName;
        newButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel(levelName));
        newButton.transform.SetParent(contentHolder.transform, false);
        newButton.GetComponentInChildren<Text>().text = levelName;
    }
    //run this function when the apply button is pressed
    public void OptionApplyButton()
    {
        //the panel for showing the stats of the player
        GameObject StatsPanel = GameObject.FindGameObjectWithTag("StatsPanel");
        //transfer all the temp keys to the custom keys (saving the keys in the options menu)
        playerSetting[whichPlayerKey].TempHolderTransferToCustomKeys();
        //Checking and applying the stats ( so only numbers are taken)
        string validInput;
        float outputParse = 0.0f;
        int maxStats = 4; //the max number of stats for the player
        //tells us if we should allow the stats to be changed
        bool allowStatChange;
        //go through a for loop for each stat option
        for (int childIndex = 0; childIndex < maxStats; childIndex++)
        {
            //set boolean to true ( so when we only change it to false when we find a stat that is not a number)
            allowStatChange = true;
            //set the validInput to the content of the inputbox
            validInput = StatsPanel.transform.GetChild(childIndex).GetComponent<InputField>().text;
            //try to see if we can parse the string into a float
            try
            {
                outputParse = float.Parse(validInput);
            }
            //if we catch a exception then we know the stat was not a number
            catch (Exception e)
            {
                //exception is found so dont allow the change and display a message in the text box
                allowStatChange = false;//dont let the change happen since this one was not a number value
                //display messages for the player so he knows he needs to enter a number
                StatsPanel.transform.GetChild(childIndex).GetComponent<InputField>().text = "";
                StatsPanel.transform.GetChild(childIndex).GetComponentInChildren<Text>().text = "Please Enter a number";
            }
            //if this stayed true then we change the players stats based on which stat option it was
            if (allowStatChange == true)
            {
                switch (StatsPanel.transform.GetChild(childIndex).name)
                {
                    case "MovespeedIF":
                        playerSetting[whichPlayerKey].SetMoveSpeed(float.Parse(StatsPanel.transform.GetChild(childIndex).GetComponent<InputField>().text));
                        break;
                    case "TurnspeedIF":
                        playerSetting[whichPlayerKey].SetTurnSpeed(float.Parse(StatsPanel.transform.GetChild(childIndex).GetComponent<InputField>().text));
                        break;
                    case "ThrowpowerIF":
                        playerSetting[whichPlayerKey].SetThrowPower(float.Parse(StatsPanel.transform.GetChild(childIndex).GetComponent<InputField>().text));
                        break;
                    case "JumppowerIF":
                        playerSetting[whichPlayerKey].SetJumpPower(float.Parse(StatsPanel.transform.GetChild(childIndex).GetComponent<InputField>().text));
                        break;
                }
            }
        }
    }
    //when the key binding button is pressed
    public void KeyBindingButtonPressed(GameObject buttonPressed)
    {
        //if we are not waiting for a key to be pressed then we instatiate the message box asking for a key press and start a invoke repeating
        if (waitingForKeyPress == false)
        {
            //we get the passed in button and set it
            pressedButton = buttonPressed;
            //set waiting to true so we dont instantiate anymore messages or repeat this code again
            waitingForKeyPress = true;
            GameObject KeyPressMessage = Instantiate(Resources.Load("WaitForKeyPanel"), OptionPanel.transform, false) as GameObject;
            KeyPressMessage.name = "WaitForKeyPanel";
            KeyPressMessage.transform.SetParent(OptionPanel.transform);
            //invoke the waiting for key press
            InvokeRepeating("WaitingForKeyPress", 0.2f, 0.01666f);
        }
    }
    //function waits for a key press and then saves it
    void WaitingForKeyPress()
    {
        //if any button was pressed then we get that key press from system
        if (Input.anyKeyDown)
        {
            //go through all the keys and compare them with the key press
            foreach (KeyCode keypress in System.Enum.GetValues(typeof(KeyCode)))
            {
                //if that keypress is same as the system key then we store it and leave this function
                if (Input.GetKey(keypress))
                {
                    //stop the function
                    CancelInvoke("WaitingForKeyPress");
                    //change the buttons text to the new key
                    pressedButton.GetComponentInChildren<Text>().text = keypress.ToString();
                    //remove the key press message
                    Destroy(GameObject.FindGameObjectWithTag("KeyPressMessage"));
                    //set the wait for key press off after 0.2 seconds
                    Invoke("SetWaitForKeyOff", 0.2f);
                    // based on what button was pressed we set that key
                    AddKey(keypress, pressedButton);
                    //set the pressedbutton to false and wait for another button to be pressed
                    pressedButton = null;
                }
            }
        }
    }
    //when we get the key press we change the temp keys to that key press
    void AddKey(KeyCode keyPressed_, GameObject buttonPressed_)
    {
        //based on which button was pressed we change the key press
        switch (buttonPressed_.name)
        {
            case "ForwardKeyButton":
                playerSetting[whichPlayerKey].SetTempKey(0, keyPressed_);
                break;
            case "BackwardKeyButton":
                playerSetting[whichPlayerKey].SetTempKey(1, keyPressed_);
                break;
            case "LeftButton":
                playerSetting[whichPlayerKey].SetTempKey(2, keyPressed_);
                break;
            case "RightButton":
                playerSetting[whichPlayerKey].SetTempKey(3, keyPressed_);
                break;
            case "ThrowButton":
                playerSetting[whichPlayerKey].SetTempKey(4, keyPressed_);
                break;
            case "JumpButton":
                playerSetting[whichPlayerKey].SetTempKey(5, keyPressed_);
                break;
            case "PickUpButton":
                playerSetting[whichPlayerKey].SetTempKey(6, keyPressed_);
                break;
        }
    }
    //turns waitinf for key off so we change another key again
    void SetWaitForKeyOff()
    {
        waitingForKeyPress = false;
    }

    // UI button to go back to Menu Scene
    public void BackToMenu()
    {
        AkSoundEngine.PostEvent("click_back", gameObject);
        SceneManager.LoadScene("MainMenu");
        eventSystem = GameObject.Find("EventSystem");
        InvokeRepeating("CheckToPlayHoverSound", 0.0f, 0.02f);
        gamePaused = false;
        //flip the level and options panel off so they can not be seen
        numPlayers = 0;
        Invoke("DelayMainMenuMusic", 0.5f);
        ResetGameValues();
        //flip the level and options panel off so they can not be seen
        numPlayers = 0;

        //AkSoundEngine.PostEvent("play_intro", gameObject);


        //Invoke("DelayReturn", 0.05f);
    }
    void DelayMainMenuMusic()
    {
        AkSoundEngine.SetRTPCValue("click_start", 100f, null, 500);
        AkSoundEngine.PostEvent("play_intro", gameObject);
    }

    public void GameReturnDelayMusic()
    {
        Invoke("DelayMainMenuMusic", 0.5f);
    }
    void DelayReturn()
    {
        FlipLevelPanel();
        FlipOptionPanel();
        FlipCharacterPanel();
    }
    // UI button to let player reset the level where they are
    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ResetGameValues();
    }

    public void ResetGameValues()
    {
        gamePaused = false;
        pausePlayerNum = 0;
    }
    // A fade effect to go to next level
    public void FadeToNextLevel(GameObject pause_)
    {
        //int index = SceneManager.GetActiveScene().buildIndex;
        //if (SceneManager.GetActiveScene().buildIndex !=Application.levelCount-1)
        {
            if (pause_.activeSelf == true)
            {
                pause_.SetActive(false);
            }
            gamePaused = false;
            CompleteLevelAndRate();
            //Turn the trigger on to play the fade animation
            sceneFade = GameObject.Find("FadeSceneHolder").GetComponent<Animator>();
            sceneFade.SetTrigger("FadeOut");
        }
    }

    public void FadeToNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        //if (SceneManager.GetActiveScene().buildIndex != Application.levelCount - 1)
        //{
            CompleteLevelAndRate();
            //Turn the trigger on to play the fade animation
            sceneFade = GameObject.Find("FadeSceneHolder").GetComponent<Animator>();
            sceneFade.SetTrigger("FadeOut");
        //}

    }

    public void CompleteLevelAndRate()
    {
        //Get player score
        int score = GameObject.Find("Rater").GetComponent<Rater>().Rating();
        //Record the score of the current  in player data
        playerdata.SetScore(score, SceneManager.GetActiveScene().buildIndex);
    }

    // Load the next level according to the max level
    public void LoadNextLevel()
    {
        // Check if the index of the active scene is less than max level, if it is, load to next level and make the access_level add 1 to let player access to the scene
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            CancelInvoke("CheckToPlayHoverSound");
            eventSystem = null;
            pausePlayerNum = 0;
            maxLevel = SceneManager.GetActiveScene().buildIndex + 1;
            //Record the level in player data
            playerdata.setCurrentLevel(maxLevel);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    //Load scene according to the name of scene
    public void LoadLevel(string sceneName)
    {
        CancelInvoke("CheckToPlayHoverSound");
        eventSystem = null;
        SceneManager.LoadScene(sceneName);
    }
    //flip the menu buttons to the opposite state
    void FlipMenuButtons()
    {
        PlayButton.gameObject.SetActive(!PlayButton.activeSelf);
        CloseButton.gameObject.SetActive(!CloseButton.activeSelf);
        OptionButton.gameObject.SetActive(!OptionButton.activeSelf);
    }
    //closes the application
    public void QuitApplication()
    {
        SavePlayerData();
        Application.Quit();
    }

    //Save Player Data
    public void SavePlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        //If there is no player data file, create one for saving
        if (!File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            File.Create(Application.persistentDataPath + "/PlayerData.dat").Close();
        }
        FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
        //Save the data which is serialized
        bf.Serialize(file, playerdata);
        file.Close();
    }

    //Load player data
    public void LoadPlayerData()
    {
        //If there is no any data, initialize the player data
        if (!File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            return;
        }
        Debug.Log(Application.persistentDataPath);
        //If there is player data, load it
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
        //Load the data which is deserialized
        playerdata = (PlayerData)bf.Deserialize(file);
        file.Close();
    }

    // Set the number of players in the scene
    public void SetNumberofPlayers(int player)
    {
        numPlayers +=  player;
    }
    // Returns the number of players to be in the scene
    public int GetNumberofPlayers()
    {
        return numPlayers;
    }

    public void SetPlayersInGame(int playerNum)
    {
        if(playerNum == 1)
        {
            //Set player 1 in game
            p1InGame = true;
        }
        else if (playerNum == 2)
        {
            //Set player 2 in game
            p2InGame = true;
        }
        else if (playerNum == 3)
        {
            //Set player 3 in game
            p3InGame = true;
        }
        else
        {
            //Set player 4 in game
            p4InGame = true;
        }
    }

    //turn the screen active or not
    public void SetPlayerPaused(bool paused_)
    {
        gamePaused = paused_;
        if(gamePaused==true)
        {
            if(eventSystem==null)
            {
                eventSystem = GameObject.Find("EventSystem");
                hoveringOver = eventSystem.GetComponent<EventSystem>().currentSelectedGameObject;
            }
            InvokeRepeating("CheckToPlayHoverSound", 0.0f, 0.02f);
        }
        else if(gamePaused==false)
        {
            //eventSystem = null;
            CancelInvoke("CheckToPlayHoverSound");
        }
    }
    //switch the player keys
    //will also need to do the switch on display
    void SwitchPlayer(int change_,Text textComponent)
    {
        whichPlayerKey += change_;
        if(whichPlayerKey<0)
        {
            whichPlayerKey = 0;
        }
        else if (whichPlayerKey > 3)
        {
            whichPlayerKey = 3;
        }
        textComponent.text = "Player " + (whichPlayerKey+1) + " keys";
        GetOptions();
    }
    public int GetWhichPlayer()
    {
        return whichPlayerKey;
    }
    public int GetMaxLevel()
    {
        return maxLevel;
    }
}
