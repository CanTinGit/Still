using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRuleCode : MonoBehaviour
{
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

}
