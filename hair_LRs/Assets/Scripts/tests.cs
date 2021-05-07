using UnityEngine;

public class tests: MonoBehaviour
{
    public GameObject hair; //the object that i create
    public Transform a,b;
    void Awake()
    {
        hair = new GameObject("hair");
        hair.transform.position = new Vector3(0f, 0f, 0f);
        //hair.transform.rotation = new Vector3(0f, 0f, 0f);
        hair.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
        //Random.InitState(System.Environment.TickCount);

        for (int i = 0; i < 1 ; i++)
        {
            GameObject hair2 = new GameObject("hair2" + i.ToString());
            hair2.transform.parent = hair.transform;

            // add between 1 to 8 "bottom" children that report to the above "middle"
            
            
            GameObject a = new GameObject("a");
            a.transform.parent = hair2.transform;
            GameObject b = new GameObject("b");
            b.transform.parent = hair2.transform;

        }
    }

    void Start()
    {
        // how many children does top have?
        GameObject hair = GameObject.Find("hair");
        Debug.Log(hair.name + " has " + hair.transform.childCount + " children");

        // pick a random middle group and pick a member of its children
        hair = GameObject.Find("hair2" + Random.Range(0, hair.transform.childCount));
        Debug.Log(hair.name + " has " + hair.transform.childCount + " children");
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