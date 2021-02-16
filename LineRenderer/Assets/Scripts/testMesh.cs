using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMesh : MonoBehaviour
{
    Vector3[] newVertices = new Vector3[100];
    Vector2[] newUV=new Vector2[100];
    int[] newTriangles=new int [3*100];
    //public 
    void Start()
    {
        for (int i = 0; i < 100; i++) newVertices[i] = new Vector3(i/10.0f-5.0f,0,0);
        for (int i = 0; i < 100; i++) newUV[i] = new Vector2(0, 0);
        for (int i = 0; i < 100; i++) 
        {
            newTriangles[i * 3 + 0] = 0;
            newTriangles[i * 3 + 1] = 1;
            newTriangles[i * 3 + 2] = i;
        }
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.uv = newUV;
        mesh.triangles = newTriangles;
        //MeshFilter filter = GetComponent<MeshFilter>();
        //MeshRenderer renderer = GetComponent<>
    }
    

    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        //Vector3[] normals = mesh.normals;
        Vector3 normal = new Vector3(0, 1, 0);
        print(vertices.Length);
        for (var i = 0; i < vertices.Length; i++)
        {
            //vertices[i] += normals[i] * Mathf.Sin(Time.time);
            vertices[i] += normal * Mathf.Sin(Time.time);
        }

        mesh.vertices = vertices;
    }
}

