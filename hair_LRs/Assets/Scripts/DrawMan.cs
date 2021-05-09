using System.Collections;
//https://www.youtube.com/watch?v=fpve8fT2aB8&ab_channel=OnlineCodeCoaching

//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMan : MonoBehaviour
{
    public GameObject drawPrefab;
    GameObject theTrail;
    Plane planeObj;
    Vector3 startPos;

    void Start()
    {
        planeObj = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }


    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            theTrail = (GameObject)Instantiate(drawPrefab, this.transform.position, Quaternion.identity);
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dis;
            if (planeObj.Raycast(mouseRay, out dis))
            {
                startPos = mouseRay.GetPoint(dis);
            }
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetMouseButton(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float dis;
            if (planeObj.Raycast(mouseRay, out dis))
            {
                theTrail.transform.position = mouseRay.GetPoint(dis);
            }
        }
    }
}
