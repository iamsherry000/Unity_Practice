using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag2 : MonoBehaviour
{
    GameObject Dot;
    private Vector3 screenPoint;
    private Vector3 offset;
    void Start()
    {
        
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

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }


    void Update()
    {

    }
}
