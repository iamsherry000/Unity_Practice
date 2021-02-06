using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab = default;
    [SerializeField, Range(10,100)]
    int resolution = 10;
    /*
    [SerializeField, Range(0, 2)]
    int function = 0;
    */
    [SerializeField]
    FunctionLibrary.FunctionName function = default;

    Transform[] points;

    void Awake()
    {
        float step = 2f / resolution; //*step = /5f
        //var position = Vector3.zero;
        var scale = Vector3.one * step;
        points = new Transform[resolution*resolution];
        for (int i=0;i< points.Length; i++)
        {
            //if (x == resolution) { x = 0; z += 1; }
            Transform point = Instantiate(pointPrefab);
            //point.localPosition = Vector3.right*( (i+0.5f) / 5f-1f );
            //++i; //i+=1;
            //position.x = (x + 0.5f) * step - 1f;
            //position.z = (z + 0.5f) * step - 1f;
            // position.y = position.x * position.x * position.x;
            //point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);
        float time = Time.time;
        float step = 2f / resolution;
        float v = 0.5f * step - 1f;
        for (int i = 0,x=0,z=0 ; i < points.Length; i++,x++) {
           // Transform point = points[i];
            //Vector3 position = point.localPosition;
            //position.y = Mathf.Sin(Mathf.PI*(position.x+time));
            /*
            if(function == 0)
                position.y = FunctionLibrary.Wave(position.x, time);
            else if (function == 1 ) position.y = FunctionLibrary.MultiWave(position.x, time);
            else position.y = FunctionLibrary.Ripple(position.x, time);
            */
            if(x == resolution)
            {
                x = 0;
                z += 1;
                v= (z + 0.5f) * step - 1f;
            }
            float u = (x + 0.5f) * step - 1f;
            points[i].localPosition = f(u, v, time);
            //position.y = f(position.x,position.z, time);
            //point.localPosition = position;
        }
    }
}
