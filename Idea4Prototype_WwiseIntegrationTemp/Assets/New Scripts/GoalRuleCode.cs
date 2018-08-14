using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoalRuleCode : MonoBehaviour
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
    //Hit the goal and go to next level
   void OnCollisionEnter(Collision col)
   {
        if(this.name == "Fuel")
        {
            if(col.transform.name=="Bucket")
            {
                Debug.Log("next levle triggered");
                //next level set
                MenuScript.Instance.FadeToNextLevel();
                Destroy(this.gameObject);                
            }
        }

   }


// If the goal in the level is a goal area it uses the below code

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Minus the number of players in goal area.
            NumPlayers--;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            
            // Add to the number of players in goal area.
            NumPlayers++;
            if (NumPlayers == MenuScript.Instance.GetNumberofPlayers())
            {
                //// Fade to next level if possible else go to main menu
                ScoreSystem scoreSystem = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScoreSystem>();
                scoreSystem.AddCheckpointTime();
                scoreSystem.CalculateFinalScore();
                //gameWonPanel.gameObject.SetActive(true);
                //eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("NextLevel"));
                //gameWonPanel.gameObject.transform.GetChild(0).transform.Find("CheesesImage").gameObject.GetComponent<Image>().sprite = m_camera.GetComponent<ScoreSystem>().ReturnStars();
                //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                //foreach(GameObject player in players)
                //{
                //    player.GetComponent<Animator>().SetBool("isMoving", false);
                //    player.GetComponent<MovementUpdated>().enabled = false;
                //    player.GetComponent<Rigidbody>().isKinematic = true;
                //}
                MenuScript.Instance.FadeToNextLevel();
            }
        }
    }

}
