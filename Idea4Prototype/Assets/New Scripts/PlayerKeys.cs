using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys
{
    //Custom
    KeyCode[] keys = new KeyCode[7];
    float playerTurnSpeed, playerMoveSpeed, playerThrowPower,playerJumpPower;
    //default keys
    KeyCode[] defaultKeys = new KeyCode[7];

    //container for keys pressed
    KeyCode[] TempHolder = new KeyCode[7];

    float defaultPlayerTurnSpeed, defaultPlayerMoveSpeed, defaultPlayerThrowPower,defaultPlayerJumpPower;
    //tells us if there is custom keys
    bool CustomKeySet = false;
    bool StatsChanged = false;
    public void IntialiseValues()
    {
        //default keys
        defaultKeys[0] = KeyCode.W;
        defaultKeys[1] = KeyCode.S;
        defaultKeys[2] = KeyCode.A;
        defaultKeys[3] = KeyCode.D;
        defaultKeys[4] = KeyCode.Joystick1Button1;
        defaultKeys[5] = KeyCode.Joystick1Button0;
        defaultKeys[6] = KeyCode.Joystick1Button2;
        defaultPlayerTurnSpeed = 2.0f;
        defaultPlayerMoveSpeed = 3.0f;
        defaultPlayerThrowPower = 6.0f;
        defaultPlayerJumpPower = 6.0f;
        //custom keys also set up to be same for start
        keys[0] = KeyCode.W;
        keys[1] = KeyCode.S;
        keys[2] = KeyCode.A;
        keys[3] = KeyCode.D;
        keys[4] = KeyCode.Joystick1Button1;
        keys[5] = KeyCode.Joystick1Button0;
        keys[6] = KeyCode.Joystick1Button2;
        //tempholder keys
        TempHolder[0] = KeyCode.W;
        TempHolder[1] = KeyCode.S;
        TempHolder[2] = KeyCode.A;
        TempHolder[3] = KeyCode.D;
        TempHolder[4] = KeyCode.Joystick1Button1;
        TempHolder[5] = KeyCode.Joystick1Button0;
        TempHolder[6] = KeyCode.Joystick1Button2;
        playerTurnSpeed = 2.0f;
        playerMoveSpeed = 3.0f;
        playerThrowPower = 6.0f;
        playerJumpPower = 6.0f;
    }
    //the custom keys will be set with the option menus temporary keys
    public void TempHolderTransferToCustomKeys()
    {
        for(int i=0;i <7;i++)
        {
            keys[i] =  TempHolder[i];
        }
    }
    //reset the keys to the default value
    public void ResetToDefaultValues()
    {
        IntialiseValues();
    }
    //resets the options menus temp keys to the default keys
    public void ResetTempKeysToDefault()
    {
        for(int arraySize = 0; arraySize < keys.Length;arraySize++)
        {
            TempHolder[arraySize] = defaultKeys[arraySize];
        }
    }
    //resets the temporary keys to the custom keys ( when leaving the option menu without clicking the apply button)
    public void ResetTempKeysToCustom()
    {
        for (int arraySize = 0; arraySize < keys.Length; arraySize++)
        {
            TempHolder[arraySize] = keys[arraySize];
        }
    }
    //reset the option stat values to the default ones
    public void ResetStats()
    {
        playerTurnSpeed = defaultPlayerTurnSpeed;
        playerMoveSpeed = defaultPlayerMoveSpeed;
        playerThrowPower = defaultPlayerThrowPower;
        playerJumpPower = defaultPlayerJumpPower;
    }
    //getter for if keys have been set
    public bool GetCustomKeySet()
    {
        return CustomKeySet;
    }
    //setter for if custom keys have been set
    public void SetCustomKey(bool customSet_)
    {
        CustomKeySet = customSet_;
    }
    //getter for if stats have been set
    public bool GetStatsSet()
    {
        return StatsChanged;
    }
    //setter for if stats have been set
    public void SetKey(bool customstat_)
    {
        StatsChanged = customstat_;
    }

    //setter for custom keys
    public void SetMoveSpeed(float moveSpeed_)
    {
        playerMoveSpeed = moveSpeed_;
    }
    public void SetTurnSpeed(float turnSpeed_)
    {
        playerTurnSpeed = turnSpeed_;
    }
    public void SetJumpPower(float jumpSpeed_)
    {
        playerJumpPower = jumpSpeed_;
    }
    public void SetThrowPower(float throwSpeed_)
    {
        playerThrowPower = throwSpeed_;
    }
    //set custom keys
    public void SetKey(int index_,KeyCode keypress_)
    {
        keys[index_] = keypress_;
    }
    //set temp cotainer for keys
    public void SetTempKey(int index_, KeyCode keypress_)
    {
        TempHolder[index_] = keypress_;
    }

    //getter for default keybinding
    public float GetDefaultMoveSpeed()
    {
        return defaultPlayerMoveSpeed;
    }
    public float GetDefaultTurnSpeed()
    {
        return defaultPlayerTurnSpeed;
    }
    public float GetDefaultJumpPower()
    {
        return defaultPlayerJumpPower;
    }
    public float GetDefaultThrowPower()
    {
        return defaultPlayerThrowPower;
    }
    public KeyCode[] GetDefaultKeys()
    {
        return defaultKeys;
    }

    //getter for custom keybinding
    public float GetMoveSpeed()
    {
        return playerMoveSpeed;
    }
    public float GetTurnSpeed()
    {
        return playerTurnSpeed;
    }
    public float GetJumpPower()
    {
        return playerJumpPower;
    }
    public float GetThrowPower()
    {
        return playerThrowPower;
    }
    //gets the custom keys
    public KeyCode[] GetKeys()
    {
        return keys;
    }
}
