// step 1 : do the same thing that DrawManager do.
// reference : https://www.youtube.com/watch?v=fpve8fT2aB8&ab_channel=OnlineCodeCoaching

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR2 : MonoBehaviour
{
    //GameObject Cp = new ;
    private List<Vector3> mousePos = new List<Vector3>(); //get all mousePosition into list 

    void Update()
    {
        Vector3 mp = Input.mousePosition;
        mp.z = 3f;
        this.transform.position = Camera.main.ScreenToWorldPoint(mp);
        
        if (Input.GetMouseButtonDown(0))
        {
            mousePos.Add(mp);//Debug.Log(mp);
            //Instantiate(Capsule, mousePos(mp.x, mp.y, mp.z), Quaternion.identity);
        }
    }
}

