using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class functions : MonoBehaviour
{
    public List<GameObject> ListCubes = new List<GameObject>();
    Stack<GameObject> StackCubes = new Stack<GameObject>();
    //GameObject haha = new GameObject();
    GameObject re = new GameObject();
    int ur = 0;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject go = new GameObject(); 
            ListCubes.Add(go);
            ListCubes[ListCubes.Count - 1].name = "go" + (ListCubes.Count - 1);
            ur = 0;
        }

        if (Input.GetKeyDown("u"))
        {
            ur = 1;
            re = Instantiate(ListCubes[ListCubes.Count - 1]);
            StackCubes.Push(re);
            re.SetActive(false);
            Destroy(ListCubes[ListCubes.Count - 1]);
            ListCubes.RemoveAt(ListCubes.Count - 1);
        }

        if (Input.GetKeyDown("r") && ur == 1)
        {
            GameObject haha;
            haha = StackCubes.Pop();
            ListCubes.Add(haha);
            haha.SetActive(true);
            if (StackCubes.Count == 0) ur = 0;
        }
    }
}
//ExistHair = GameObject.Find("HairModel" + (HairCounter - 1)); //找到相應的hairmodel名稱丟給 ExistHair GameObj
//ListExistHair.Add(ExistHair);
//u_Freq = 0;

/*if (Input.GetKeyDown("u"))
{
    u_Freq = 1;
    UndoObj = Instantiate(ListExistHair[ListExistHair.Count - 1]);
    StackExistHair.Push(UndoObj);
    UndoObj.SetActive(false);
    Destroy(ListExistHair[ListExistHair.Count - 1]);
    ListExistHair.RemoveAt(ListExistHair.Count - 1);
}

if(Input.GetKeyDown("r") && u_Freq == 1)
{
    GameObject RedoObj;
    RedoObj = StackExistHair.Pop();
    ListExistHair.Add(RedoObj);
    RedoObj.SetActive(true);
    if (StackExistHair.Count == 0) u_Freq = 0;
} */
