﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerStringToImage 
{   
    public Sprite ConvertStringToImage(string stringToConvertToImage_)
    {
        string path = "UI/ControllerButtons/" + stringToConvertToImage_;
        Debug.Log(path);
        Sprite controllerInputImage = Resources.Load<Sprite>(path);
        Debug.Log(controllerInputImage);
        return controllerInputImage;
    }
}
