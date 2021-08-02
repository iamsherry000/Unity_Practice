using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject monster,origin;
    Vector3 mousePos;
    Vector3 distance;
    //public Vector3 monsterPos, originPos;
    void Start()
    {
        //monsterPos = monster.transform.position; //green cube
        //originPos = origin.transform.position; // red sphere
        //monster.transform.position = new Vector3 (1f, 1f, 1f);
    }
    void countdist()
    {
        distance.x = monster.transform.position.x > origin.transform.position.x ? monster.transform.position.x - origin.transform.position.x : origin.transform.position.x - monster.transform.position.x;
        distance.y = monster.transform.position.y > origin.transform.position.y ? monster.transform.position.y - origin.transform.position.y : origin.transform.position.y - monster.transform.position.y;
        
    }
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        countdist();
        if (Input.GetMouseButtonDown(0)) //滑鼠按下 //到時候不用(因為怪物自己會走)
        {            
            if (distance.x > 3f || distance.y > 3f)
            {
                monster.transform.position = origin.transform.position;
            }
            else
            {
                monster.transform.position = mousePos; 
            }
        }    
    }
}
