using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerStringToImage : MonoBehaviour
{
    public Image test;
    Image ConvertStringToImage(string stringToConvertToImage_)
    {
        string path = "UI/ControllerButtons/" + stringToConvertToImage_;
        Image controllerInputImage = Resources.Load<Image>(path);
        test.sprite = controllerInputImage.sprite;
        return controllerInputImage;
    }
}
