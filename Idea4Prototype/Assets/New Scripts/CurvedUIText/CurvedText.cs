using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CurvedText : MonoBehaviour {

    public float radius = 0.5f;
    public float wrapAngle = 360.0f;
    public float scaleFactor = 100.0f;

    private float circumference
    {
        get
        {
            if(_radius != radius || _scaleFactor != scaleFactor)
            {
                _circumference = 2.0f * Mathf.PI * radius * scaleFactor;
                _radius = radius;
                _scaleFactor = scaleFactor;
            }
            return _circumference;
        }
    }

    private float _radius = -1;
    private float _scaleFactor = -1;
    private float _circumference = -1;

    //protected override void OnValidate()
    //{
    //    base.OnValidate();
    //    if(radius <= 0.0f)
    //    {
    //        radius = 0.001f;
    //    }
    //    if(scaleFactor <= 0.0f)
    //    {
    //        scaleFactor = 0.001f;
    //    }
    //}

    //protected override void OnFillVBO(List<UIVertex> vbo)
    //{
    //    base.OnFillVBO(vbo);
    //    for (int i = 0; i < vbo.Count; i++)
    //    {
    //        UIVertex v = vbo[i];

    //        Vector3 p = v.position;

    //        float percentCircumference = v.position.x / circumference;
    //        Vector3 offset = Quaternion.Euler(0.0f, 0.0f, -percentCircumference * 360.0f) * Vector3.up;
    //        p = offset * radius * scaleFactor + offset * v.position.y;
    //        p += Vector3.down * radius * scaleFactor;

    //        v.position = p;

    //        vbo[i] = v;
    //    }
    //}
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
