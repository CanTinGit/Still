using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateThrow : MonoBehaviour {

    public float velocity;
    public float angle;
    public int resolution; //Decide how accuracy of the line

    float gravity;  //Force of gravity on y axis
    float radianAngle;
    float startY;

    public List<Vector3> movementArray = new List<Vector3>();
    int i;
    float timer;
    void Awake()
    {
        gravity = Mathf.Abs(Physics.gravity.y);
    }
    // Use this for initialization
    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        movementArray = CalculateArcArray();
        i = 0;
        InvokeRepeating("SimulateMove", 0.0f, 0.01666f);
    }
	

    void SimulateMove()
    {
        if (i < resolution + 1)
        {
            this.transform.position = movementArray[i];
            i++;
        }
        else
        {
            //turn kinematic off so gravity effects the object again
            float x = (movementArray[i-1].x - movementArray[i-2].x) / 0.01666f;
            radianAngle = Mathf.Deg2Rad * angle;
            float y = (movementArray[i - 1].x - movementArray[i - 2].x) / 0.01666f;
            float z = (movementArray[i-1].z - movementArray[i-2].z) / 0.01666f;
            //Debug.Log(new Vector3(x, -y, z));
            if (y >= 0)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x, -y, z);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x, y, z);
            }
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            //CancelInvoke();
            Destroy(this);
        }
    }

    // Create an array of Vector3 positions for arc
    List<Vector3> CalculateArcArray()
    {
        List<Vector3> arcArray = new List<Vector3>();
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;
        for (int i = 0; i < resolution + 1; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray.Add(CalculateArcPoint(t, maxDistance));
        }
        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float distance = t * maxDistance;
        float x = distance * Mathf.Cos(Mathf.PI / 180f * gameObject.transform.rotation.eulerAngles.y);
        float y = distance * Mathf.Tan(radianAngle) - ((gravity * distance * distance) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))) + startY;
        float z = distance * Mathf.Sin(Mathf.PI / 180f * gameObject.transform.rotation.eulerAngles.y);
        return new Vector3(transform.position.x+z, y, transform.position.z+x);
    }

    public void SetValue(float velocity_, float angle_, int resolution_, float startY_)
    {
        velocity = velocity_;
        angle = angle_;
        resolution = resolution_;
        startY = startY_;
    }

    void OnCollisionEnter(Collision collision)
    {
        float x = (movementArray[i - 1].x - movementArray[i - 2].x) / 0.01666f;
        radianAngle = Mathf.Deg2Rad * angle;
        float y = (movementArray[i - 1].x - movementArray[i - 2].x) / 0.01666f;
        float z = (movementArray[i - 1].z - movementArray[i - 2].z) / 0.01666f;
        //Debug.Log(new Vector3(x, -y, z));
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(x, -y, z);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        CancelInvoke();
        Destroy(this);
    }

}
