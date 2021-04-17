using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragObj : MonoBehaviour
{
    private Vector3 mOffset;
    private float mc;
    
    void Start()
    {

    }

    private void OnMouseDown()
    {
        mc = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mc;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

}
