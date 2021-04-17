using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public Vector2 minPower,maxPower;

    TrajectoryLine tl;

    Camera cam;
    Vector2 force;//calculating our two vector
    Vector3 startPoint, endPoint;

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse Button Down");
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15f;
            //Debug.Log(startPoint);
        }
        if (Input.GetMouseButton(0)) 
        {
            Vector3 curPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            curPoint.z = 15f;
            tl.RenderLine(startPoint, curPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15f;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.x, maxPower.x));
            rb.AddForce(force * power, ForceMode2D.Impulse);
            tl.EndLine();
        }
    }
}
