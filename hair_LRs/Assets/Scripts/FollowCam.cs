﻿//https://www.youtube.com/watch?v=fpve8fT2aB8&ab_channel=OnlineCodeCoaching
using UnityEngine;

public class FollowCam : MonoBehaviour
{


    void Update()
    {
        Vector3 temp = Input.mousePosition;
        temp.z = 10f;
        this.transform.position = Camera.main.ScreenToWorldPoint(temp);
    }
}
