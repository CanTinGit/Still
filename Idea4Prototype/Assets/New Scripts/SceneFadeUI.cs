using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneFadeUI : MonoBehaviour
{
    public GameObject gameWonPanel;
    GameObject eventSystem;
    GameObject m_camera;
    int NumPlayers = 0;

    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        m_camera = GameObject.Find("Main Camera");
    }

    public void OnCompleteLoad()
    {
        // Fade to next level if possible else go to main menu
        //ScoreSystem scoreSystem = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreSystem>();
        //scoreSystem.AddCheckpointTime();
        //scoreSystem.CalculateFinalScore();
        gameWonPanel.gameObject.SetActive(true);
        gameWonPanel.GetComponent<Animator>().SetTrigger("FadeIn");
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("NextLevel"));
        gameWonPanel.gameObject.transform.Find("CheesesImage").gameObject.GetComponent<Image>().sprite = m_camera.GetComponent<ScoreSystem>().ReturnStars();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            player.GetComponent<Animator>().SetBool("isMoving", false);
            player.GetComponent<MovementUpdated>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
        }

        //if (SceneManager.GetActiveScene().buildIndex != (Application.levelCount - 1))           // If the current level is not the last level
        //{
        //    // load next level
        //    MenuScript.Instance.LoadNextLevel();
        //}
        //else
        //{
        //    // Otherwise it must be the last level
        //    // Return to the main menu resetting number of players to 0
        //    MenuScript.Instance.LoadLevel("MainMenu");
        //    MenuScript.Instance.SetNumberofPlayers(-MenuScript.Instance.GetNumberofPlayers());
        //    MenuScript.Instance.GameReturnDelayMusic();
        //    MenuScript.Instance.ResetGameValues();
        //}
    }
}
