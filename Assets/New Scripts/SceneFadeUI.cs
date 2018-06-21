using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeUI : MonoBehaviour
{
    public void OnCompleteLoad()
    {
        MenuScript.Instance.LoadNextLevel(); 
    }

}
