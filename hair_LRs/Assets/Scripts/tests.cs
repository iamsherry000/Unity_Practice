using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class tests : MonoBehaviour
{
    public Transform a, b;
    public List<GameObject> lrpmatrix = new List<GameObject>();
    public List<GameObject> hairmatrix = new List<GameObject>();


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
        for (int i = 0; i < 3; i++)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            hairmatrix.Add(capsule);
            Rigidbody RG;
            RG = hairmatrix[i].AddComponent<Rigidbody>();
            RG.isKinematic = true;
            hairmatrix[i] = new GameObject("hair" + i.ToString());
            
        }
        for (int i = 0; i < hairmatrix.Count; i++) 
        {
            if (i > 0 && i < hairmatrix.Count)
            {
                hairmatrix[i].transform.parent = hairmatrix[i-1].transform;
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
        for (int i = 0; i < 3; i++)
        {
            lrpmatrix[i].transform.parent = hairmatrix[i].transform;
        }
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