// square
// step 1: give the vertices
// step 2: build mesh
// step 3: normals

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class try2 : MonoBehaviour
{
    Vector3[] vrs = new Vector3[6];
    int[] trs = new int[6];
    Vector2[] uvs;
    Mesh mesh;
    int sp = 0;

    void Start()
    {
        step1();
        step2();
        step3();
    }

    void step1() 
    {
        vrs[0] = new Vector3(sp, 0, 0);
        vrs[1] = new Vector3(sp, 1, 0);
        vrs[2] = new Vector3(sp+1, 0, 0);
        vrs[3] = new Vector3(sp+1, 0, 0);
        vrs[4] = new Vector3(sp, 1, 0);
        vrs[5] = new Vector3(sp+1, 1, 0);
    }
    void step2()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        mesh.name = "mmmm";
        mesh.vertices = vrs;
        trs[0] = 0; trs[1] = 1; trs[2] = 2;
        trs[3] = 3; trs[4] = 4; trs[5] = 5;
        mesh.triangles = trs;
    }
    void step3()
    {
        Vector3[] nrs = mesh.normals;
    }
    private void OnDrawGizmos() //專門顯示點的程式
    {
        Gizmos.color = Color.black;
        for (int i = 0; i < vrs.Length; i++)
        {
            Gizmos.DrawSphere(vrs[i], 0.1f);
            
        }
    }

    void Update()
    {
        
    }
}
