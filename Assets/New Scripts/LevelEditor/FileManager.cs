using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
//controls loading and saving
public class FileManager : MonoBehaviour
{
    //the panel which will hold all the levels
    GameObject LevelListPanel;
    //intialises the variables and set up the scene
    public void Intialise()
    {
        //get the panel and flip the level list off
        LevelListPanel = GameObject.Find("LoadFilesPanel");
        FlipLevelListPanel();
    }
    //when the save button is pressed on the level editor
    public void SaveButtonPressed()
    {
        if (GameObject.FindGameObjectWithTag("SaveFileMessage") == null)
        {
            GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
            GameObject saveFileMessage = Instantiate(Resources.Load<GameObject>("LevelBuilder/SaveFileMessage"), canvas.transform, false);
            saveFileMessage.name = "SaveFileMessage";
            saveFileMessage.transform.SetParent(canvas.transform);
            Button[] buttons = saveFileMessage.GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(() => FileNameValid(saveFileMessage.GetComponentInChildren<InputField>().text, saveFileMessage));
            buttons[1].onClick.AddListener(() => DestroyMessageBoxs(saveFileMessage));
        }
    }
    void FileNameValid(string fileName, GameObject saveFileMessage_)
    {
        if (GameObject.FindGameObjectWithTag("ErrorMessage") == null)
        {
            if (fileName != "")
            {
                SaveConfirmed(fileName);
                DestroyMessageBoxs(saveFileMessage_);
            }
            else
            {
                CreateErrorMessage("please enter a file name");
            }
        }
    }

    void CreateErrorMessage(string message_)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject errorMessage = Instantiate(Resources.Load<GameObject>("LevelBuilder/ErrorMessage"), canvas.transform, false);
        errorMessage.name = "ErrorMessage";
        errorMessage.transform.SetParent(canvas.transform);
        errorMessage.GetComponentInChildren<Text>().text = message_;
        errorMessage.GetComponentInChildren<Text>().alignment = TextAnchor.MiddleCenter;
        Button[] buttons = errorMessage.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(() => DestroyMessageBoxs(errorMessage));
    }
    void SaveConfirmed(string fileName_)
    {

        List<GameObject> objectsToSave = new List<GameObject>();
        objectsToSave.AddRange(GameObject.FindGameObjectsWithTag("LevelBuilderObject"));
        if (objectsToSave.Count != 0)
        {
            SavingObjectsToText(objectsToSave, fileName_);
        }
        else
        {
            CreateErrorMessage("There is no objects in the level to save");
        }
    }
    void SavingObjectsToText(List<GameObject> objects, string filename_)
    {
        string fileName = filename_;
        string path = Application.dataPath + "/StreamingAssets/LevelBuilder/Saves/" + fileName + ".txt";
        if (File.Exists(path) != true)
        {
            CreateNewFile(path, objects);
        }
        else
        {
            FileAlreadyExists(objects, path);

        }
    }
    void CreateNewFile(string path, List<GameObject> objects_)
    {
        StreamWriter writer = new StreamWriter(path, true);
        foreach (GameObject element in objects_)
        {
            writer.WriteLine(element.name.ToString());
            writer.WriteLine(element.transform.position.ToString());
            writer.WriteLine(element.transform.rotation.ToString());
            writer.WriteLine(element.transform.localScale.ToString());
        }
        writer.WriteLine("END");
        writer.Close();
    }
    void OverwriteFile(string path, List<GameObject> objects_, GameObject overwriteMsg_)
    {
        Destroy(overwriteMsg_.gameObject);
        FileInfo file = new FileInfo(path);
        List<string> objects = new List<string>();
        foreach (GameObject element in objects_)
        {
            objects.Add(element.name.ToString());
            objects.Add(element.transform.position.ToString());
            objects.Add(element.transform.rotation.ToString());
            objects.Add(element.transform.lossyScale.ToString());
        }
        objects.Add("END");
        string[] content = objects.ToArray();
        File.WriteAllLines(path, content);
    }
    void FileAlreadyExists(List<GameObject> objects_, string path_)
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject overwriteMsg = Instantiate(Resources.Load<GameObject>("LevelBuilder/OverwriteMessage"), canvas.transform, false);
        overwriteMsg.name = "OverwriteMessage";
        overwriteMsg.transform.SetParent(canvas.transform);
        Button[] buttons = overwriteMsg.GetComponentsInChildren<Button>();
        buttons[0].onClick.AddListener(() => OverwriteFile(path_, objects_, overwriteMsg));
        buttons[1].onClick.AddListener(() => DestroyMessageBoxs(overwriteMsg));
    }

    void DestroyMessageBoxs(GameObject messageBox_)
    {
        Destroy(messageBox_);
    }
    void CreateLevelList(List<string> fileNames_)
    {
        GameObject FileContentHolder = LevelListPanel.GetComponentInChildren<VerticalLayoutGroup>().gameObject;
        foreach (string filename in fileNames_)
        {
            Button level = Instantiate(Resources.Load<Button>("LevelBuilder/ObjectButton"));
            level.name = filename;
            level.transform.SetParent(FileContentHolder.transform);
            level.GetComponentInChildren<Text>().text = filename.Remove(filename.IndexOf('.'));
            level.onClick.AddListener(() => SetUpLoadButton(filename.Remove(filename.IndexOf('.'))));
        }

    }
    void FlipLevelListPanel()
    {
        LevelListPanel.SetActive(!LevelListPanel.activeSelf);
    }
    void DestroyLevelList()
    {
        GameObject FileContentHolder = LevelListPanel.GetComponentInChildren<VerticalLayoutGroup>().gameObject;
        Button[] buttons = FileContentHolder.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }

    }
    public void LoadButtonPressed()
    {
        DestroyLevelList();
        List<string> fileNames = new List<string>();
        string path = Application.dataPath + "/StreamingAssets/LevelBuilder/Saves/";
        DirectoryInfo directory = new DirectoryInfo(path);
        FileInfo[] files = directory.GetFiles();
        foreach (FileInfo file in files)
        {

            if (!file.Name.Contains(".txt.meta"))
            {
                fileNames.Add(file.Name);
            }
        }
        CreateLevelList(fileNames);
        FlipLevelListPanel();
    }
    void SetUpLoadButton(string fileName_)
    {
        string path = Application.dataPath + "/StreamingAssets/LevelBuilder/Saves/" + fileName_ + ".txt";
        CleanObjectsInScene(); //maybe move
        LoadingFile(path);
        DestroyLevelList();
        FlipLevelListPanel();
    }
    void CleanObjectsInScene()
    {
        GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("LevelBuilderObject");
        foreach (GameObject gameobject in gameobjects)
        {
            Destroy(gameobject);
        }
    }
    void LoadingFile(string path_)
    {
        LevelSaveStructure saveFormat = new LevelSaveStructure();
        string path = path_;
        StreamReader reader = new StreamReader(path, true);
        string text = "";
        int counter = 0;
        while (text != "END")
        {
            text = reader.ReadLine();
            switch (counter)
            {
                case 0:
                    saveFormat.SetName(text);
                    break;
                case 1:
                    saveFormat.SetPosition(text);
                    break;
                case 2:
                    saveFormat.SetRotation(text);
                    break;
                case 3:
                    saveFormat.SetScale(text);
                    break;
            }
            counter++;
            if (text != "END")
            {
                if (counter > 3)
                {
                    LoadSetObject(saveFormat);
                    counter = 0;
                }
            }
        }
        reader.Close();
    }
    void LoadSetObject(LevelSaveStructure saveFormat_)
    {
        //string array for each element in vector
        string[] vectorStringArray;
        //loaded the right object
        string pathToObject = "LevelBuilder/Objects/" + saveFormat_.GetName();
        GameObject prefab = Resources.Load<GameObject>(pathToObject);
        GameObject loadedObject = Instantiate(prefab);
        loadedObject.name = saveFormat_.GetName();
        //make string to represent what vector will be converted
        vectorStringArray = StringToVector(saveFormat_.GetPositon());
        loadedObject.transform.position = new Vector3(float.Parse(vectorStringArray[0]), float.Parse(vectorStringArray[1]), float.Parse(vectorStringArray[2]));
        vectorStringArray = StringToVector(saveFormat_.GetRotation());
        loadedObject.transform.eulerAngles = new Vector3(float.Parse(vectorStringArray[0]), float.Parse(vectorStringArray[1]), float.Parse(vectorStringArray[2]));
        vectorStringArray = StringToVector(saveFormat_.GetScale());
        loadedObject.transform.localScale = new Vector3(float.Parse(vectorStringArray[0]), float.Parse(vectorStringArray[1]), float.Parse(vectorStringArray[2]));
    }

    string[] StringToVector(string stringToConvert_)
    {
        string PharseVector = stringToConvert_;
        PharseVector = PharseVector.Substring(1, PharseVector.Length - 2);
        // split the items
        string[] sArray = PharseVector.Split(',');
        return sArray;

    }

}
