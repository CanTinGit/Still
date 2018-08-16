using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSaveStructure
{

        private string name;
        private string position;
        private string rotation;
        private string scale;
        //setters
        public void SetName(string name_)
        {
            name = name_;
        }
        public void SetPosition(string position_)
        {
            position = position_;
        }
        public void SetRotation(string rotation_)
        {
            rotation = rotation_;
        }
        public void SetScale(string scale_)
        {
            scale = scale_;
        }
        //getters 
        public string GetName()
        {
            return name;
        }
        public string GetPositon()
        {
            return position;
        }
        public string GetRotation()
        {
            return rotation;
        }
        public string GetScale()
        {
        return scale;
        }
    
}
