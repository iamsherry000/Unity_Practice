using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Point
{
    public List<Vector3> list; 
}
[System.Serializable]
public class PointList
{
    public List<Point> list;
}

public class test : MonoBehaviour
{
    //< <A:a1-a3> <B:b1-b3> >  
    // <list<list<vector3>>>
    public Point A = new Point();
    public Point B = new Point();
    public Point C = new Point();

    public List<Vector3> D = new List<Vector3>();
    public PointList ListOfPointLists = new PointList();

    private void Start()
    {
        Vector3 a1 = new Vector3(1, 1, 1);
        Vector3 a2 = new Vector3(2, 1, 1);
        Vector3 a3 = new Vector3(3, 1, 1);

        Vector3 b1 = new Vector3(1, 1, 1);
        Vector3 b2 = new Vector3(1, 2, 1);
        Vector3 b3 = new Vector3(1, 3, 1);

        Vector3 d0 = new Vector3(0, 1, 1);
        D.Add(d0);

        ListOfPointLists.list[0].list.Add(a1);
        ListOfPointLists.list[0].list.Add(a2);
        ListOfPointLists.list[0].list.Add(a3);
    }


}