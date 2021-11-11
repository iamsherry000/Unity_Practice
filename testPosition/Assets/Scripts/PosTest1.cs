using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosTest1 : MonoBehaviour
{
    GameObject Cube, Sphere;   
    GameObject LU, RU, RD, LD,now;   
    float x=0;
    float xc = 0;
    float a = 1f, b = 1f, c = -6f;
    private void Start()
    {
        Cube = GameObject.Find("Cube");
        Sphere = GameObject.Find("Sphere");

        LU = GameObject.Find("Cube/spot/LU");
        RU = GameObject.Find("Cube/spot/RU");
        RD = GameObject.Find("Cube/spot/RD"); 
        LD = GameObject.Find("Cube/spot/LD");        
    }
    void judge()
    {
        xc = 0;
        a = now.GetComponent<Transform>().position.x;
        b = now.GetComponent<Transform>().position.y;
        c = now.GetComponent<Transform>().position.z;
    }

    public void button_lu()
    {
        now = LU;
        judge();
    }
    public void button_ru()
    {
        now = RU;
        judge();
    }
    public void button_rd()
    {
        now = RD;
        judge();
    }
    public void button_ld()
    {
        now = LD;
        judge();
    }


    void Update()
    {
        x += 0.001f;
        xc += 0.001f;
        Cube.GetComponent<Transform>().position = new Vector3(x, 1f, -6f);
        Sphere.GetComponent<Transform>().position = new Vector3(a + xc, b, c);       
        if (x > 3f)
        {
            x = 0f;

            if (a + xc > 3.5f) { a = 0.5f; xc = 0; }
            else { a = -0.5f; xc = 0; }
            }
    }
}
