using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerate : MonoBehaviour
{
    private Mesh mesh;
    Material GetHairColor;
    MeshCollider HairCollider;

    int[] triangle;

    Vector2[] uvs;
    Vector3[] vertices;
    Vector4[] tangents;

    public void GenerateMesh(List<Vector3>GetPointPos, int GetHairWidth)
    {
        GetComponent<MeshFilter>().mesh = mesh = new Mesh(); // meshfilter中的mesh指給程式宣告的mesh
        GetHairColor = GetComponent<Renderer>().material;
        GetHairColor.color = Color.red;
        GetComponent<MeshRenderer>().material = GetHairColor;
        mesh.name = "HairMesh";
        if (gameObject.GetComponent<MeshCollider>() == null) HairCollider = gameObject.AddComponent<MeshCollider>();
        else HairCollider = gameObject.GetComponent<MeshCollider>();
        HairCollider.sharedMesh = mesh;

        //設定index大小符合 GetPointPos 的Count
        uvs = new Vector2[GetPointPos.Count];
        vertices = new Vector3[GetPointPos.Count];
        tangents = new Vector4[GetPointPos.Count];
        //丟值
        for(int i = 0; i < GetPointPos.Count; i++)
        {
            vertices[i] = GetPointPos[i];
            uvs[i].x = GetPointPos[i].x;
            uvs[i].y = GetPointPos[i].y;
            tangents[i] = new Vector4(1f, 0f, 0f, -1f);
        }
        //指給mesh使用
        
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.tangents = tangents;

        int point = ((GetPointPos.Count / (3 + (GetHairWidth - 1) * 2) - 1)) * 2 * GetHairWidth;
        triangle = new int[point * 6];
        int t = 0; // triangle 的 index，負責指標位置值

        for (int vi = 0, k = 0, x = 1; x <= point; x++, vi += k)
        {
            t = SetQuad(triangle, t, vi, vi + 1, vi + 3 + (2 * (GetHairWidth - 1)), vi + 4 + (2 * (GetHairWidth - 1)));
            if (x % (GetHairWidth * 2) != point % (GetHairWidth * 2)) k = 1;  //在同一行
            else k = 2;  //對vi的累加  (需換行時)
        }

        mesh.triangles = triangle;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();

    }

    private static int SetQuad(int[] triangles, int i, int v0, int v1, int v2, int v3)
    {
        triangles[i] = v0;
        triangles[i + 1] = v1;
        triangles[i + 2] = v2;
        triangles[i + 3] = v2;
        triangles[i + 4] = v1;
        triangles[i + 5] = v3;
        return i + 6;
    }
}
