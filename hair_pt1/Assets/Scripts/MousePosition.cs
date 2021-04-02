using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    GameObject dot, point;
    void Start()
    {
        GameObject dot = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        dot.transform.localScale= new Vector3(0.1f, 0.1f, 0.1f);
        //GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //point.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        print(mousePos);
        float newx = (mousePos.x - Screen.width / 2) / (Screen.width / 2);//減一半、除一半
        float newy = (mousePos.y - Screen.height / 2) / (Screen.height / 2);
        float y = 10 * Mathf.Tan(Mathf.Deg2Rad * 30) * newy;
        float x = 10 * Mathf.Tan(Mathf.Deg2Rad * 30) * newx * Screen.width / Screen.height;
        dot.transform.position = new Vector3(x, y, 0);

    }
}
