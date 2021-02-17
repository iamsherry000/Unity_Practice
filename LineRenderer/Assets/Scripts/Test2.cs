using UnityEngine;
using System.Collections;

public class Test2 : MonoBehaviour
{
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Sprites/Default"));

        // Set some positions
        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(-0.8f, 0.3f, -0.6f);
        positions[1] = new Vector3(0.0f, 0.8f, 0.1f);
        positions[2] = new Vector3(0.8f, 0.3f, -0.6f);
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
    }
}
