using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSelect : MonoBehaviour {

    public void setSelect()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/MenuSelectUI/Select");
    }
    public void setUnSelect()
    {
        this.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/MenuSelectUI/Select_inactive");
    }
}
