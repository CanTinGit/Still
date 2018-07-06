using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalRuleCode : MonoBehaviour
{
    int NumPlayers = 0;
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
            if(NumPlayers == MenuScript.Instance.GetNumberofPlayers())
            {
                // Fade to next level if possible else go to main menu
                MenuScript.Instance.FadeToNextLevel();
            }
        }
    }

}
