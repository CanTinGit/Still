using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//STRUCTURE OF audio states e.g. light sound to very heavy sound
struct AudioForceStruct
{
    //the min and max range of that sound (e.g. force of 0 to 3 is very light sound)
    float minRange, maxRange;
    string material;
    //sound state e.g. very light
    string pszState;
    //sets the min and max range values
    public void MinAndMaxRange(float min_,float max_)
    {
        minRange = min_;
        maxRange = max_;

    }
    public void SetMaterial(string material_)
    {
        material = material_;
    }
    //set the state
    public void SetPszState(string pszState_)
    {
        pszState = pszState_;
    }
    //getters of mini, max and state
    public string GetPszState()
    {
        return pszState;
    }
    public float GetMinRange()
    {
        return minRange;
    }
    public float GetMaxRange()
    {
        return maxRange;
    }
}
//structure of one state group e.g. impacting sound group of a metal object
struct AudioSingleStructure
{
    //material name and the name of the sound group
    string materialName,pszStateGroup;
    //list of all the sounds in this group
    List<AudioForceStruct> audioRange;
    //intialises the structure
    public void Intialise(string materialName_,string pszStateGroup_)
    {
        SetMaterialName(materialName_);
        SetPszStateGroup(pszStateGroup_);
        audioRange = new List<AudioForceStruct>();
    }
    //setter for material name and state group
    void SetMaterialName(string materialName_)
    {
        materialName = materialName_;
    }
    void SetPszStateGroup(string pszStateGroup_)
    {
        pszStateGroup = pszStateGroup_;
    }
    //add the psz state with the min and max values range it should trigger at
    public void AddPszState(float min_,float max_,string pszState_)
    {
        AudioForceStruct singlElement = new AudioForceStruct();
        singlElement.MinAndMaxRange(min_, max_);
        singlElement.SetPszState(pszState_);
        audioRange.Add(singlElement);
    }
    //getters for material name and the state group
    public string GetMaterialName()
    {
        return materialName;
    }
    //getter for state
    public string GetStateGroup()
    {
        return pszStateGroup;
    }
    //getters for min and max
    public float GetMin(string pszState_)
    {
        float dummy = 4000;
        for(int counter =0; counter < audioRange.Count;counter++)
        {
            if(audioRange[counter].GetPszState()== pszState_)
            return audioRange[counter].GetMinRange();
        }
        return dummy;
    }
    public float GetMax( string pszState_)
    {
        float dummy = 4000;
        for (int counter = 0; counter < audioRange.Count; counter++)
        {
            if (audioRange[counter].GetPszState() == pszState_)
                return audioRange[counter].GetMaxRange();
        }
        return dummy;
    }
    //returns the audio range list
    public List<AudioForceStruct> GetAudioRangeList()
    {
        return audioRange;
    }
}
//structure of the whole audio data base
struct AudioDatabaseStructure
{
    //making a list of audio groups with states within
    List<AudioSingleStructure> audioGroup;
    //intialise the list
    public void Intialise()
    {
        audioGroup = new List<AudioSingleStructure>();
    }
    public AudioSingleStructure GetAudioList(string material_)
    {
        AudioSingleStructure audioList = new AudioSingleStructure();
        foreach (AudioSingleStructure element in audioGroup)
        {
            if(element.GetMaterialName() == material_)
            {
                audioList = element;
                break;
            }
        }
        return audioList;
    }
    //getter for min,max, state group and material name
    public float GetMax(string pszState_,int index_)
    {
        return audioGroup[index_].GetMax(pszState_);
    }
    public float GetMin(string pszState_, int index_)
    {
        return audioGroup[index_].GetMin(pszState_);
    }
    public string GetStateGroup(int index_)
    {
        return audioGroup[index_].GetStateGroup();
    }
    public string GetMaterialName(int index_)
    {
        return audioGroup[index_].GetMaterialName();
    }
    //add to the database itself
    public void AddToDatabase(AudioSingleStructure element_)
    {
        audioGroup.Add(element_);
    }
    //return the database length
    public int GetDatabaseLength()
    {
        return audioGroup.Count;
    }
    //get the number of audio states in group
    public List<AudioForceStruct> GetAudioRangeList(int index_)
    {
        return audioGroup[index_].GetAudioRangeList();
    }
}
//the audio that creates the audio database and allows for playing of the sounds
public class AudioClass:MonoBehaviour
{
    //variable for the database of audio
    AudioDatabaseStructure audioDatabase;
    //used for holding the list of the different ranges of audio states e.g. very light to very heavy
    List<AudioForceStruct> audioRange;
    //hold the nationality of eachPlayer
    string[] playerNationality;


    ////creates the lists and intialises them
    void Awake()
    {
        playerNationality = new string[4];
        audioRange = new List<AudioForceStruct>();
        audioDatabase = new AudioDatabaseStructure();
        audioDatabase.Intialise();
        SetDefaultAudio();
        AllMaterials();
    }

    //creates the lists and intialises them
    public void InitialiseAudioClass()
    {
        playerNationality = new string[4];
        audioRange = new List<AudioForceStruct>();
        audioDatabase = new AudioDatabaseStructure();
        audioDatabase.Intialise();
        SetDefaultAudio();
        AllMaterials();
    }
    public void SetDefaultAudio()
    {
        playerNationality[0] = "Generic";
        playerNationality[1] = "American";
        playerNationality[2] = "Indian";
        playerNationality[3] = "Chinese";
    }
    //sets audio for material
    public void SetAudioForMaterial(string material_)
    {
        //go through the database and find the correct material and then set the audioRange to the list of psz states
        for (int counter = 0; counter < audioDatabase.GetDatabaseLength(); counter++)
        {
            if (audioDatabase.GetMaterialName(counter) == material_)
            {
                audioRange = audioDatabase.GetAudioRangeList(counter);
                break;
            }
        }
    }
    /// <summary>
    /// IAIN MESSAGE HERE
    /// YOU PUT ALL YOUR MATERIAL FUNCTIONS HERE
    /// </summary>
    private void AllMaterials()
    {
        MetalMaterial();
        WoodMaterial();

    }
    /// <summary>
    /// IAIN MESSAGE HERE
    /// A TEMPLATE OF A METAL SOUND BEING ADDED TO THE DATABASE
    /// </summary>
    private void MetalMaterial()
    {
        AudioSingleStructure singleAudioGroup = new AudioSingleStructure();
        singleAudioGroup.Intialise("metal_object","Impact_Force");
        singleAudioGroup.AddPszState(0, 5, "Light");
        singleAudioGroup.AddPszState(5, 10, "Medium");
        singleAudioGroup.AddPszState(10, 100, "Heavy");//not required to always between the ranges you can just use the max value in the if statement
        audioDatabase.AddToDatabase(singleAudioGroup);
    }

    private void WoodMaterial()
    {
        AudioSingleStructure singleAudioGroup = new AudioSingleStructure();
        singleAudioGroup.Intialise("wood_object", "Impact_Force");
        singleAudioGroup.AddPszState(0, 5, "Light");
        singleAudioGroup.AddPszState(5, 10, "Medium");
        singleAudioGroup.AddPszState(10, 100, "Heavy");//not required to always between the ranges you can just use the max value in the if statement
        audioDatabase.AddToDatabase(singleAudioGroup);
    }
    /// <summary>
    /// IAIN MESSAGE HERE
    /// FUNCTION YOU CALL WHEN YOU WANT TO MAKE A CHECK ON WHETHER FORCE WILL BE USED TO DETERMINE WHAT AUDIO STATE PLAYS
    /// BASICALLY THE OLD IF STATEMENTS
    /// </summary>
    public void PlayAudio(string material_,float force,string pszGroup)
    {
        //audioDatabase
        List<AudioForceStruct> List = audioDatabase.GetAudioList(material_).GetAudioRangeList();
        foreach (AudioForceStruct element in List)
        {
            //DEBUG MESSAGE FOR TESTING WHAT IS MINI MAX AND THE FORCE PASSING IN
            //Debug.Log(force.ToString() + " " + element.GetMinRange().ToString() + " " + force.ToString() + " " + element.GetMaxRange().ToString());

            //if statement that will be used for all the different states
            if ((force >= element.GetMinRange()) && (force <= element.GetMaxRange()))
            {
                //Debug.Log("the material is " + material_);
                //Debug.Log("the force is " + force);
                //Debug.Log("the psz group is " + pszGroup);
                //Debug.Log("the psz state is " + element.GetPszState());
                AkSoundEngine.SetState("Material",material_);
                AkSoundEngine.SetState(pszGroup, element.GetPszState());
                break;
            }
        }
    }
    //gets the min value for that material state
    public float GetMinMaterialState(string material_,string pszState_)
    {
        for(int counter = 0; counter < audioDatabase.GetDatabaseLength(); counter++)
        {
            if (audioDatabase.GetMaterialName(counter) == material_)
            {
                return audioDatabase.GetMin(pszState_, counter);
            }
        }
        return -0.5f;
    }
    //gets the max value for that material state
    public float GetMaxMaterialState(string material_, string pszState_)
    {
        for (int counter = 0; counter < audioDatabase.GetDatabaseLength(); counter++)
        {
            if (audioDatabase.GetMaterialName(counter) == material_)
            {
                return audioDatabase.GetMax(pszState_, counter);
            }
        }
        return -0.5f;
    }


    public void SetNationality(int playerNum_, string nationality_)
    {
        playerNationality[playerNum_-1] = nationality_;
    }
    public string GetNationality(int playerNum_)
    {
        return playerNationality[playerNum_-1];
    }
}
