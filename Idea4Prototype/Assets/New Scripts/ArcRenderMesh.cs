using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ArcRenderMesh : MonoBehaviour {

    Mesh mesh;
    public float meshWidth;

    public float velocity;
    public float angle;
    public int resolution; //Decide how accuracy of the line

    float gravity;  //Force of gravity on y axis
    float radianAngle;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        gravity = Mathf.Abs(Physics2D.gravity.y);
    }

    void FixedUpdate()
    {
        //Check that mesh it not null and that the game is playing
        if (mesh!=null && Application.isPlaying)
        {
            MakeArcMesh(CalculateArcArray());
        }
    }

	// Use this for initialization
	void Start () {
        MakeArcMesh(CalculateArcArray());
	}

    void MakeArcMesh(Vector3[] arcVerts)
    {
        mesh.Clear();
        Vector3[] vertices = new Vector3[(resolution+1) * 2] ;
        int[] triangles = new int[resolution*12];

        for(int i = 0; i< resolution + 1; i++)
        {
            //set vertices
            vertices[i * 2] = new Vector3(meshWidth * 0.5f, arcVerts[i].y, arcVerts[i].x);
            vertices[i*2 +1] = new Vector3(meshWidth * -0.5f, arcVerts[i].y, arcVerts[i].x);
            if (i % 2 == 0) continue;
            if (i != resolution)
            {
                triangles[i * 12] = i * 2;
                triangles[i * 12 + 1] = triangles[i * 12 + 4] = i * 2 + 1;
                triangles[i * 12 + 2] = triangles[i * 12 + 3] = (i + 1) * 2;
                triangles[i * 12 + 5] = (i + 1) * 2 + 1;

                triangles[i * 12 +6] = i * 2;
                triangles[i * 12 + 7] = triangles[i * 12 + 10] = (i + 1) * 2;
                triangles[i * 12 + 8] = triangles[i * 12 + 9] = i * 2 + 1;
                triangles[i * 12 + 11] = (i + 1) * 2 + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }

    // Create an array of Vector3 positions for arc
    Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / gravity;
        for (int i = 0; i < resolution+1; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t,maxDistance);
        }
        return arcArray;
    }

    Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = x * Mathf.Tan(radianAngle) - ((gravity * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle))); //transform.parent.FindChild("Hand").GetComponent<PickUpUpdated>().picked.transform.position.y;
        return new Vector3(x, y);
    }

    public void SetValue(float velocity_, float angle_, int resolution_)
    {
        velocity = velocity_;
        angle = angle_;
        resolution = resolution_;
    }
}
