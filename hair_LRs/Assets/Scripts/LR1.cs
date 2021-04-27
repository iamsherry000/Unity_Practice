using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class LR1 : MonoBehaviour
{
    public LineRenderer lr1;
    Vector3 startPoint, endPoint;
    //Camera cam;
    Vector2 force;//calculating our two vector


    private void Start()
    {
        //cam = Camera.main;
        //tl = GetComponent<TrajectoryLine>();
    }

    private void Awake()
    {
        lr1 = GetComponent<LineRenderer>();
    }
    public void RenderLine(Vector3 startPoint, Vector3 endPoint)
    {
        lr1.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startPoint;
        points[1] = endPoint;

        lr1.SetPositions(points);
    }

    void OnGUI()
    {
        Event m_Event = Event.current;
        if (m_Event.type == EventType.MouseDown)
        {
            Debug.Log("Mouse Down.");
        }
        if (m_Event.type == EventType.MouseDrag)
        {
            Debug.Log("Mouse Dragged.");
        }
        if (m_Event.type == EventType.MouseUp)
        {
            Debug.Log("Mouse Up.");
        }
    }

    public void Update()
    {
        Vector3 mousePos1 = Input.mousePosition;
        float newx = (mousePos1.x - Screen.width / 2) / (Screen.width / 2);//減一半、除一半
        float newy = (mousePos1.y - Screen.height / 2) / (Screen.height / 2);
        float y = 10 * Mathf.Tan(Mathf.Deg2Rad * 30) * newy;
        float x = 10 * Mathf.Tan(Mathf.Deg2Rad * 30) * newx * Screen.width / Screen.height;
        mousePos1.x *= 0.05f;
        mousePos1.x -= 25;
        mousePos1.y *= 0.001f;
        mousePos1.z = -2;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = mousePos1;
            //startPoint = Camera.main.WorldToScreenPoint(mousePos1);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 curPoint = mousePos1;
            //curPoint.z = 15f;
            //startPoint = curPoint;
            RenderLine(startPoint, curPoint);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = mousePos1;
            //endPoint.z = 15f;

            //force = new Vector2(Mathf.Clamp(StartPoint.x - EndPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.x, maxPower.x));
            //rb.AddForce(force * power, ForceMode2D.Impulse);
            //lr.EndLine();
        }
    }
}