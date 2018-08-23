using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public enum EditorState {Move,Rotate,Scale,None }
//loads up and sets buttons and also does the moving of objects
public class LevelBuilder : MonoBehaviour
{

    EditorState editorState;
    GameObject ObjectListPanel,interactedObject,LevelListPanel,ItemsConfigPanel;
    bool objectListOpen,interactingWithObject;
    public LayerMask clickLayer, placeObjectLayer;
    float UpDownPlacement,UpDownScaleValue;
    FileManager filemanager;
    Vector3 intialMouseClick;
    bool firstClick = false;
    Vector3 startingValues; //used to store the starting values of rotation/scale
    // Use this for initialization
    void Awake ()
    {
        filemanager = new FileManager();
        filemanager.Intialise();
        SetUpButton();
        editorState = EditorState.None;
        ObjectListPanel = GameObject.Find("ObjectPanel");
        ItemsConfigPanel = GameObject.Find("ItemConfigsPanel");
        LevelListPanel = GameObject.Find("LoadFilesPanel");
        FlipObjectListPanel();
        FlipItemConfigPanel();       
        objectListOpen = false;
        interactingWithObject = false;
        InvokeRepeating("InteractWithObject", 0.0f, 0.01f);
        UpDownPlacement = 0.0f;
        UpDownScaleValue = 0.0f;
    }
    public EditorState GetState()
    {
        return editorState;
    }
	void InteractWithObject()
    {
        
        if((objectListOpen != true) && (interactingWithObject==false))
        {
            //check for interaction
            
            if(Input.GetMouseButtonDown(0))
            {
                RaycastToFindObject(Input.mousePosition);
            }
            //raycast to ground 
            //get point 
            //if object tag then go to interact code
            //interact code then lets me move it
            //make a half transparent copy
            //follows mouse
            //where you click do raycast
            //if tat point is object then get point
            //move object to that points
        }
        else
        {
            //this list is open or there is a interaction
        }
    }
    public void InputFieldOnValueChange(GameObject valueChanged)
    {
        InputField[] inputFields = valueChanged.GetComponentsInChildren<InputField>();
        float result ;
        foreach(InputField inputfield in inputFields)
        {
             if(float.TryParse(inputfield.text,out result) == false)
            {

                WhatInputFieldToReset(inputfield, valueChanged.name.Remove(valueChanged.name.IndexOf('D')));
            }
        }
        if(valueChanged.name.Contains("Position"))
        {
            interactedObject.transform.position = new Vector3(float.Parse(inputFields[0].text), float.Parse(inputFields[1].text), float.Parse(inputFields[2].text));
        }
        else if(valueChanged.name.Contains("Rotation"))
        {
            interactedObject.transform.eulerAngles = new Vector3(float.Parse(inputFields[0].text), float.Parse(inputFields[1].text), float.Parse(inputFields[2].text));
        }
        else if (valueChanged.name.Contains("Scale"))
        {
            interactedObject.transform.localScale = new Vector3(float.Parse(inputFields[0].text), float.Parse(inputFields[1].text), float.Parse(inputFields[2].text));
        }
    }
    void WhatInputFieldToReset(InputField inputField_,string valueType)
    {
        if(valueType=="Position")
        {
            ResetInput(inputField_, interactedObject.transform.position);
        }
        else if(valueType=="Rotation")
        {
            ResetInput(inputField_, interactedObject.transform.eulerAngles);
        }
        else if (valueType == "Scale")
        {
            ResetInput(inputField_, interactedObject.transform.lossyScale);
        }
    }
    void ResetInput(InputField inputField_,Vector3 valueToChangeBackTo)
    {
        switch(inputField_.name)
        {
            case "XIF":
                inputField_.text = valueToChangeBackTo.x.ToString();
                break;         
            case "YIF":
                inputField_.text = valueToChangeBackTo.y.ToString();
                break;
            case "ZIF":
                inputField_.text = valueToChangeBackTo.z.ToString();
                break;
        }
    }
    void StartUpDetails()
    {
        GameObject[] details = GameObject.FindGameObjectsWithTag("ObjectDetails");
        foreach(GameObject detail in details)
        {
            SetStartValues(detail);
        }
        
    }
    void SetStartValues(GameObject details_)
    {
        switch (details_.name)
        {
            case "Name":
                details_.GetComponentInChildren<Text>().text = "Name: " + interactedObject.name;
                break;
            case "Position":
                InputFieldDetailsSet(details_.GetComponentsInChildren<InputField>(),interactedObject.transform.position);
                break;
            case "Rotate":
                InputFieldDetailsSet(details_.GetComponentsInChildren<InputField>(),interactedObject.transform.eulerAngles);
                break;
            case "Scale":
                InputFieldDetailsSet(details_.GetComponentsInChildren<InputField>(),interactedObject.transform.localScale);
                break;
        }
    }
    void InputFieldDetailsSet(InputField[] inputFields_,Vector3 inputFieldVector3)
    {
        foreach(InputField inputfield in inputFields_)
        {
            if(inputfield.name=="XIF")
            {
                inputfield.text = inputFieldVector3.x.ToString();
            }
            else if (inputfield.name == "YIF")
            {
                inputfield.text = inputFieldVector3.y.ToString();
            }
            else if (inputfield.name == "ZIF")
            {
                inputfield.text = inputFieldVector3.z.ToString();
            }
        }
    }
    //checks to see if object has been clicked
    void RaycastToFindObject(Vector3 mousePosition_)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition_);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,1000.0f, clickLayer))
        {
            interactingWithObject = true;
            interactedObject = hit.transform.gameObject;
            CancelInvoke("InteractWithObject");
            FlipItemConfigPanel();
            StartUpDetails();
            InvokeRepeating("PutOnAxisArrows", 0.0f, 0.01667f) ;
            InvokeRepeating("InteractingControls",0.0f,0.01666f);
            FixAndUnfixObject();
        }
    }
    void PutOnAxisArrows()
    {
        GameObject arrow;
        if (GameObject.FindGameObjectWithTag("LevelBuilderAxis")==null)
        {
            for(int i = 0; i<3;i++)
            {
                arrow = Instantiate(Resources.Load<GameObject>("LevelBuilder/AxisArrows"));
                ArrowResize classScript = arrow.AddComponent<ArrowResize>();
                if(i==0)
                {
                    classScript.SetAxis("X");
                }
                else if(i == 1)
                {
                    classScript.SetAxis("Y");
                }
                else if(i == 2)
                {
                    classScript.SetAxis("Z");
                }
                classScript.SetObject(interactedObject);
            }

        }
        else
        {
            //gm = GameObject.FindGameObjectWithTag("LevelBuilderAxis");
        }
        //gm.transform.position =  new Vector3(0.0f,(interactedObject.transform.position.y + gm.GetComponent<MeshCollider>().bounds.extents.y),0.0f);
    }
    public void ConfigPressed(GameObject button_)
    {
        string buttonName_ = button_.name;
        switch (buttonName_)
        {
            case "MoveButton":
                ChangeState(EditorState.Move, button_);
                break;
            case "RotateButton":
                ChangeState(EditorState.Rotate, button_);
                break;
            case "ScaleButton":
                ChangeState(EditorState.Scale, button_);
                break;
        }
    }
    void ChangeState(EditorState stateChange_,GameObject buttonPressed_)
    {
        ResetConfigButtonColor();
        if (editorState != stateChange_)
        {
            editorState = stateChange_;
            buttonPressed_.GetComponent<Image>().color = Color.green;
        }
        else
        {
            editorState = EditorState.None;
        }
    }
    void ResetConfigButtonColor()
    {
        Image[] configButtonsColor = ItemsConfigPanel.GetComponentsInChildren<Image>();
        foreach(Image configButton in configButtonsColor)
        {
            configButton.color = Color.white;
        }
    }
    void InteractingControls()
    {
        InteractKeyControls();
        MoveMouseControls();
        //when the player is not changing the attributes of the object then right click to uninteract with objects
        if(editorState == EditorState.None)
        {
            if (Input.GetMouseButtonDown(1))
            {
                FlipItemConfigPanel();
                FixAndUnfixObject();
                interactedObject = null;
                interactingWithObject = false;
                editorState = EditorState.None;
                ResetConfigButtonColor();
                CancelInvoke("InteractingControls");
                CancelInvoke("PutOnAxisArrows");
                RemoveArrowAxis();
                InvokeRepeating("InteractWithObject", 0.0f, 0.01667f);
            }
        }
    }
    void RemoveArrowAxis()
    {
        GameObject[] arrows = GameObject.FindGameObjectsWithTag("LevelBuilderAxis");
        foreach(GameObject arrow in arrows)
        {
            Destroy(arrow);
        }
    }
    void InteractKeyControls()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ChangeState(EditorState.Move, GameObject.Find("MoveButton"));
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeState(EditorState.Rotate, GameObject.Find("RotateButton"));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeState(EditorState.Scale, GameObject.Find("ScaleButton"));
        }
    }
    void MoveMouseControls()
    {
        if (editorState == EditorState.Move)
        {
            StateMouseWheel(ref UpDownPlacement);
            StateMove();  
                   
        }
        //rotation of x and y axis ( up and down and left and right)
        else if (editorState == EditorState.Rotate)
        {
            StateRotate();
        }
        else if (editorState == EditorState.Scale)
        {
            //StateMouseWheel(ref UpDownScaleValue);
            StateScale();
        }
        else if (editorState == EditorState.None)
        {
            StateNone();
        }
    }
    void StateNone()
    {
        Vector3 intialMouseClick= Vector3.zero;
        startingValues = Vector3.zero;
    }
    void StateMouseWheel(ref float  mouseWheelvalue_)
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            mouseWheelvalue_ += 1.0f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {

            if(mouseWheelvalue_>1 )
            {
                mouseWheelvalue_ -= 1.0f;
            }
        }
    }
    void StateRotate()
    {
        //get the intial click location
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            intialMouseClick = Input.mousePosition;
            startingValues = interactedObject.transform.eulerAngles;
        }


        //we now get the updated click location
        if ((Input.GetKey(KeyCode.Mouse0)))
        {
            //the sensitivity of the movement for x and y axis
            float sensitivityX = 0.5f;
            float sensitivityY = 0.5f;
            //the rotation value ( how much to rotate the object)
            float rotateX = 0;
            float rotateY = 0;
            Vector3 Held = Input.mousePosition;
            float DistanceX = Mathf.Abs(Held.x - intialMouseClick.x); //absolute values  for both
            float DistanceY = Mathf.Abs(Held.y - intialMouseClick.y);
            //may not need threshold after testing with artist they disliked old control scheme of accelaration
            float ThresholdXDistance = 70; 
            float ThresholdYDistance = 30;
            //if (DistanceX > ThresholdXDistance) //old threshold might be removed  limits for x
            {
                rotateY = (Held.x - intialMouseClick.x) * sensitivityY; // the rotation of the y axis by moving left and right on ouse

            }
            //if (DistanceY > ThresholdYDistance) //old threshold might be removed limits for y
            {
                rotateX = (Held.y - intialMouseClick.y) * sensitivityX;
            }
            Vector3 newAngle = new Vector3(startingValues.x + rotateX, startingValues.y + -rotateY, startingValues.z);
            interactedObject.transform.eulerAngles = newAngle;
            SetStartValues(GameObject.Find("Rotate"));
        }
        else if ((Input.GetKeyUp(KeyCode.Mouse0)))
        {
            startingValues = Vector3.zero;
        }
    }
    void StateScale()
    {
        bool change = false;
        //get the intial click location
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            intialMouseClick = Input.mousePosition;
            startingValues = interactedObject.transform.localScale;
        }
        //we now get the updated click location
        if ((Input.GetKey(KeyCode.Mouse0)))
        {          
            //the sensitivity of the movement for x and y axis
            float sensitivityX = 0.1f;
            float sensitivityY = 0.1f;
            float sensitivityZ = 0.005f;
            //the rotation value ( how much to rotate the object)
            float scaleX = 0;
            float scaleY = 0;
            float scaleZ = 0;
            Vector3 Held = Input.mousePosition;
            float DistanceX = Mathf.Abs(Held.x - intialMouseClick.x);
            float DistanceY = Mathf.Abs(Held.y - intialMouseClick.y);
            float ThresholdXDistance = 70;
            float ThresholdYDistance = 70;
            //if (DistanceX > ThresholdXDistance)
            {
                scaleX = (Held.x - intialMouseClick.x) * sensitivityY; // the rotation of the y axis by moving left and right on ouse

            }
            //if (DistanceY > ThresholdYDistance)
            {
                scaleZ = (Held.y - intialMouseClick.y) * sensitivityX;
            }
            Vector3 newScale = new Vector3(startingValues.x + scaleX, startingValues.y +UpDownScaleValue, startingValues.z+ scaleZ);
            if(newScale.x<0)
            {
                newScale.x = 0.0f;
            }
            if (newScale.y < 0)
            {
                newScale.y = 0.0f;
            }
            if (newScale.z < 0)
            {
                newScale.z = 0.0f;
            }
            interactedObject.transform.localScale = newScale;
            SetStartValues(GameObject.Find("Scale"));
        }
    }

    void FixAndUnfixObject()
    {
        UpDownPlacement = 0.0f;
        UpDownScaleValue = 0.0f;
        Rigidbody rgbody = interactedObject.GetComponent<Rigidbody>();
        rgbody.freezeRotation = !rgbody.freezeRotation;
        rgbody.isKinematic = !rgbody.isKinematic;
        //rgbody.rotation = Quaternion.identity;
    }
    void StateMove()
    {
        //Debug.Log("enter raycast controls");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //change to not use layers so we can place ontop of objects
        if (Physics.Raycast(ray, out hit, 1000.0f,placeObjectLayer))
        {
            interactedObject.transform.position =  hit.point + (transform.up * UpDownPlacement);
            //interactedObject.transform.position += transform.up * UpDownPlacement;
            //interactedObject.transform.Translate(0.0f, interactedObject.GetComponent<MeshRenderer>().bounds.extents.y + (transform.up.magnitude*UpDownPlacement), 0.0f);
            SetStartValues(GameObject.Find("Position"));
        }
    }
    void FlipObjectListPanel()
    {
        ObjectListPanel.SetActive(!ObjectListPanel.activeSelf);
    }
    void FlipItemConfigPanel()
    {
        ItemsConfigPanel.SetActive(!ItemsConfigPanel.activeSelf);
    }
    void ControlObjectListPressed(Button buttonPressed_)
    {
        FlipObjectListPanel();
        //get  rid of old list
        DestroyItemList(buttonPressed_.name);
        if (buttonPressed_.name=="OpenList")
        {
            objectListOpen = true;
            buttonPressed_.name = "CloseList";
            buttonPressed_.GetComponentInChildren<Text>().text = "Close object list";
            buttonPressed_.GetComponent<RectTransform>().anchorMin = new Vector2(0, 0);
            buttonPressed_.GetComponent<RectTransform>().anchorMax = new Vector2(0, 0);
            buttonPressed_.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
            buttonPressed_.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
            LoadItemList();
        }
        else
        {
            objectListOpen = false;
            buttonPressed_.name = "OpenList";
            buttonPressed_.GetComponentInChildren<Text>().text = "Open object list";
            buttonPressed_.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            buttonPressed_.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
            buttonPressed_.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            buttonPressed_.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1);
        }
    }
    void LoadItemList()
    {
        Sprite[] items = Resources.LoadAll<Sprite>("LevelBuilder/ItemListImages");
        foreach(Sprite item in items)
        {
            CreateButton(item);
        }
    }
    void DestroyItemList(string pressedButtonName)
    {
        if (pressedButtonName == "OpenList")
        {
            Button[] buttons = GameObject.FindGameObjectWithTag("ContentHolder").GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                Destroy(button.gameObject);
            }
        }
    }
    void SavePressed()
    {
        filemanager.SaveButtonPressed();
    }
    void LoadPressed()
    {
        filemanager.LoadButtonPressed();
    }
    void CreateButton(Sprite objectImage_)
    {
        Button prefab = Resources.Load<Button>("LevelBuilder/ObjectButton");
        GameObject ContentHolder = GameObject.FindGameObjectWithTag("ContentHolder");       
        Button ListObject =Instantiate(prefab, ContentHolder.transform,false);
        ListObject.transform.SetParent(ContentHolder.transform);
        ListObject.name = objectImage_.name+"Object";
        ListObject.image.sprite = objectImage_;
        ListObject.GetComponentInChildren<Text>().text = objectImage_.name;
        ListObject.onClick.AddListener(() => LoadObject(objectImage_.name)); 
    }
    void LoadObject(string objectName_)
    {
        ControlObjectListPressed(GameObject.Find("CloseList").GetComponent<Button>());
        string pathToObject = "LevelBuilder/Objects/" + objectName_;
        GameObject prefab = Resources.Load<GameObject>(pathToObject);
        GameObject ListObject = Instantiate(prefab);
        ListObject.name = objectName_;
    }   
    void SetUpButton()
    {
        GameObject[] buttonsInScene;
        buttonsInScene = GameObject.FindGameObjectsWithTag("Buttons");
        foreach (GameObject button in buttonsInScene)
        {
            if(button.GetComponent<Button>()==true)
            {
                AddListenerToButtons(button.GetComponent<Button>());
            }
            else
            {
                AddListenerToInputField(button.GetComponent<InputField>());
            }
        }
    }
    void CleanObjectsInScene()
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("LevelBuilderObject");
        foreach(GameObject gameobject in gameobjects)
        {
            Destroy(gameobject);
        }
    }
    void AddListenerToButtons(Button button_)
    {
        switch(button_.name)
        {
            case "OpenList":
                button_.onClick.AddListener(() => ControlObjectListPressed(button_));
                break;
            case "SaveButton":
                button_.onClick.AddListener(() => SavePressed());
                break;
            case "LoadButton":
                button_.onClick.AddListener(() => LoadPressed());
                break;
            case "MoveButton":
                button_.onClick.AddListener(() => ConfigPressed(button_.gameObject));
                break;
            case "RotateButton":
                button_.onClick.AddListener(() => ConfigPressed(button_.gameObject));
                break;
            case "ScaleButton":
                button_.onClick.AddListener(() => ConfigPressed(button_.gameObject));
                break;
        }
    }
    void AddListenerToInputField(InputField inputField_)
    {
        inputField_.onEndEdit.AddListener((value) => InputFieldOnValueChange(inputField_.transform.parent.parent.gameObject));
    }
}
