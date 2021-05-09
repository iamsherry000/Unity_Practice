using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class tests : MonoBehaviour
{
    public GameObject hair, hair1, hair2, hair3; //the object that I create
    public Transform a, b;
    public List<GameObject> lrpmatrix = new List<GameObject>();
    public List<GameObject> hairmatrix = new List<GameObject>();
    public List<Rigidbody> rgmatrix = new List<Rigidbody>();


    void AB()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject lrp = new GameObject("LRP");
            lrp.transform.localScale = new Vector3(2f, 1f, 2f);

            GameObject a = new GameObject("a");
            a.transform.parent = lrp.transform;
            a.transform.position = new Vector3(0f, 1f, 0f);

            GameObject b = new GameObject("b");
            b.transform.parent = lrp.transform;

            lrpmatrix.Add(lrp);
        }
    }


    void Hairscript()
    {
        for(int i = 0; i < 5; i++)
        {
            hairmatrix[i] = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            hairmatrix[i].AddComponent<Rigidbody>();
            hairmatrix[i].AddComponent<CapsuleCollider>();
            rgmatrix[i] = hairmatrix[i].AddComponent<Rigidbody>();
            rgmatrix[i].isKinematic = true;
            hairmatrix[i] = new GameObject("hair" + i.ToString());
            
            if (i > 0)
            {
                hairmatrix[i + 1].transform.parent = hairmatrix[i].transform;
                hairmatrix[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        hairmatrix[0].transform.position = new Vector3(0f, 0f, 0f);
        hairmatrix[0].transform.localScale = new Vector3(0.5f, 1f, 0.5f);
        hairmatrix[1].transform.position = new Vector3(0f, -2f, 0f);
        hairmatrix[2].transform.position = new Vector3(0f, -2f, 0f);
    }

    void matrix()
    {
        AB();
        lrpmatrix[0].transform.parent = hair.transform;
        lrpmatrix[1].transform.parent = hair1.transform;
        lrpmatrix[2].transform.parent = hair2.transform;
    }


    void Start()
    {
        Hairscript();
        matrix();
        //GameObject hair = GameObject.Find("hair");
        
    }
    void Update()
    {
        if (GetComponent<LineRenderer>())
        {
            if (a && b)
            {
                GetComponent<LineRenderer>().SetPosition(0, a.position);
                GetComponent<LineRenderer>().SetPosition(1, b.position);
            }
        }
    }
}