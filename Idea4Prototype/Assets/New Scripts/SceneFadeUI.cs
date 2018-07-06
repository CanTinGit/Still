using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeUI : MonoBehaviour
{
    public void OnCompleteLoad()
    {
        if (SceneManager.GetActiveScene().buildIndex != (Application.levelCount - 1))           // If the current level is not the last level
        {
            // load next level
            MenuScript.Instance.LoadNextLevel();
        }
        else
        {
            // Otherwise it must be the last level
            // Return to the main menu resetting number of players to 0
            MenuScript.Instance.LoadLevel("MainMenu");
            MenuScript.Instance.SetNumberofPlayers(-MenuScript.Instance.GetNumberofPlayers());
            MenuScript.Instance.GameReturnDelayMusic();
            MenuScript.Instance.ResetGameValues();
        }
    }
}
