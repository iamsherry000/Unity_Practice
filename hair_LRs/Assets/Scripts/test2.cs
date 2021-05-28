using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class test2 : MonoBehaviour
{
    public GameObject hair, hair1, hair2, hair3; //the object that I create
    public Transform a, b;
    public LineRenderer lr2;
    public List<GameObject> lrpmatrix = new List<GameObject>();
    Rigidbody RG;
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
        hair = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        hair.AddComponent<CapsuleCollider>();
        RG = hair.AddComponent<Rigidbody>();
        RG.isKinematic = true;
        hair = new GameObject("hair");
        hair.transform.position = new Vector3(0f, 0f, 0f);
        hair.transform.localScale = new Vector3(0.5f, 1f, 0.5f);

        //solution1
        //Instantiate(hair, hair.transform.position, hair.transform.rotation);

        //solution2
        hair1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        hair1.AddComponent<CapsuleCollider>();
        RG = hair1.AddComponent<Rigidbody>();
        RG.isKinematic = true;
        hair1 = new GameObject("hair1");
        hair1.transform.parent = hair.transform;
        hair1.transform.position = new Vector3(0f, -2f, 0f);

        hair2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        hair2.AddComponent<CapsuleCollider>();
        RG = hair.AddComponent<Rigidbody>();
        RG.isKinematic = true;
        hair2 = new GameObject("hair2");
        hair2.transform.parent = hair1.transform;
        hair2.transform.position = new Vector3(0f, -2f, 0f);

        AB();
        lrpmatrix[0].transform.parent = hair.transform;
        lrpmatrix[1].transform.parent = hair1.transform;
        lrpmatrix[2].transform.parent = hair2.transform;
    }

    void Start()
    {
        Hairscript();
        GameObject hair = GameObject.Find("hair");
        //Instantiate(hair, hair.transform.position,hair.transform.rotation);

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