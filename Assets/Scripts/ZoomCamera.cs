using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {

    float minFov = 15.0f;
    float maxFov = 90f;
    float sensitivity = 10f;
    Camera mainCamera;
    GameObject LevelBuilderManager;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        LevelBuilderManager = GameObject.Find("LevelBuilderManager");
    }

	// Update is called once per frame
	void Update ()
    {
        if(LevelBuilderManager.GetComponent<LevelBuilder>().GetState()==EditorState.None)
        {
            float fov = Camera.main.fieldOfView;
            fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            mainCamera.fieldOfView = fov;
        }
    }
}
