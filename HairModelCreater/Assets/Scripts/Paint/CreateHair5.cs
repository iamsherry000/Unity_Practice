//別忘記PosGenerate.cs要改 Point Pos
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHair5 : MonoBehaviour
{
    int TriggerDown = 0;  //沒被按下
    int HairCounter = 0; //Hair片數
    int HairWidth = 1; //Hair寬度

    float length = 0.5f; //點距離

    Vector3 NewPos, OldPos; //抓新舊點

    public static List<Vector3> PointPos = new List<Vector3>(); //Pos座標存取
    public List<GameObject> HairModel = new List<GameObject>(); //髮片Gameobj存取

    public MeshGenerate MeshCreater; //呼叫 MeshGenerate.cs 中的東西給 MeshCreater 用
    public PosGenerate PosCreater; //呼叫 PosGenerate.cs 中的東西給 PosCreater 用

    public List<GameObject> ListExistHair = new List<GameObject>(); //給Undo用
    Stack<GameObject> StackExistHair = new Stack<GameObject>(); //給Redo用
    GameObject PushObj, PopObj;
    GameObject ExistHair;
    public static GameObject Contact;
    int u_Freq = 0, c_Freq = 0;
    int TempListExistHair = 0;

    private void Start()
    {
        PosCreater = gameObject.AddComponent<PosGenerate>(); //加入PosGenerate
    }

    void Update()
    {
        Draww();
        Undo();
        Redo();
        Clear();
    }
    //= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = 
    void Draww()
    {
        if (TriggerDown == 0) //沒被按下
        {
            if (Input.GetMouseButtonDown(0)) //偵測被按下的瞬間
            {
                GameObject Model = new GameObject(); //創建model gameobj
                HairModel.Add(Model); //加入list
                HairModel[HairCounter].name = "HairModel" + HairCounter; //設定名字
                ResetPos();
                TriggerDown = 1;
            }
        }
        if (TriggerDown == 1) //被按下
        {
            NewPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            float dist = Vector3.Distance(OldPos, NewPos); //計算舊點到新點，位置的距離

            if (dist > length) //距離大於設定的長度
            {
                PosCreater = gameObject.GetComponent<PosGenerate>(); //加入PosGenerate
                PosCreater.GetPosition(OldPos, NewPos, HairWidth);
                ResetPos();
            }

            if (PointPos.Count >= (3 + (HairWidth - 1) * 2) * 2)
            {
                if (HairModel[HairCounter].GetComponent<MeshGenerate>() == null)
                    MeshCreater = HairModel[HairCounter].AddComponent<MeshGenerate>();
                else MeshCreater = HairModel[HairCounter].GetComponent<MeshGenerate>();
                MeshCreater.GenerateMesh(PointPos, HairWidth);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (PointPos.Count >= (3 + (HairWidth - 1) * 2) * 2)
                {
                    HairCounter++;
                    ExistHair = GameObject.Find("HairModel" + (HairCounter - 1)); //找到相應的hairmodel名稱丟給 ExistHair GameObj
                    ListExistHair.Add(ExistHair);
                    c_Freq = 0;
                }

                else //清除不夠長所以沒加到程式碼的的髮片gameobj
                {
                    int least = HairModel.Count - 1;
                    Destroy(HairModel[least]);
                    HairModel.RemoveAt(least);
                }
                PointPos.Clear();
                TriggerDown = 0;
            }
        }
    }

    void Undo()
    {
        if (Input.GetKeyDown("u") && c_Freq == 0) //clear had not be excuted, undo use PushStaff.
        {
            u_Freq += 1;
            PushStuff();
            //Debug.Log("uF:" + u_Freq + "cF:" + c_Freq);
        }
        if (Input.GetKeyDown("u") && c_Freq == 1) //clear had been excuted, undo use PopStaff.
        {
            u_Freq = 1; // after clear function excuted, undo can be excuted once.
            for (int i = 0; i < TempListExistHair; i++)
            {
                PopStuff();
            }
            //Debug.Log("uF:" + u_Freq + "cF:" + c_Freq);
        }
    }

    void Redo()
    {
        //redo need to be excuted after undo, but not after clear function.
        if (Input.GetKeyDown("r") && u_Freq != 0 && c_Freq == 0)
        {
            PopStuff();
            u_Freq -= 1;
            //Debug.Log("uF:" + u_Freq + "cF:" + c_Freq);
        }
        if (Input.GetKeyDown("r") && u_Freq != 0 && c_Freq == 1)
        {
            for (int i = 0; i < TempListExistHair; i++)
            {
                PushStuff();
            }
            u_Freq = 0;
            //Debug.Log("uF:" + u_Freq + "cF:" + c_Freq);
        }
    }

    void Clear()
    {
        //if clear excuted, rerecord the undo count. (till next clear)
        if (Input.GetKeyDown("c"))
        {
            u_Freq = 0; // Undo count return to zero.
            StackExistHair.Clear();
            TempListExistHair = ListExistHair.Count;
            for (int i = 0; i < TempListExistHair; i++)  //All in.
            {
                PushStuff();
            }
            c_Freq = 1; //clear functions had been excuted. (for undo)
            //Debug.Log("uF:" + u_Freq + "cF:" + c_Freq);
        }
    }

    void Eraser()
    {
        PushObj = Instantiate(Contact);
        StackExistHair.Push(PushObj);
        Contact.SetActive(false);
        Destroy(Contact);
    }

    void OnCollisionEnter(Collision collision) //Eraser
    {
        Contact = GameObject.Find(collision.gameObject.name);
    }
    

    void ResetPos()
    {
        OldPos = NewPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    void PushStuff() //push stuff into 
    {
        PushObj = Instantiate(ListExistHair[ListExistHair.Count - 1]); //生成ListExitstHair中count-1的物件
        StackExistHair.Push(PushObj); //生成的物件(pushobj)push進stack存，之後要redo要用
        PushObj.SetActive(false); //場景上不再看得見
        Destroy(ListExistHair[ListExistHair.Count - 1]); //刪除ListExitstHair中count-1的物件
        ListExistHair.RemoveAt(ListExistHair.Count - 1); //從ListExistHair中移除count-1的物件
        //Debug.Log("Push");
    }

    void PopStuff()
    {
        PopObj = StackExistHair.Pop(); //從stack中pop東西出來
        ListExistHair.Add(PopObj); //加回ListExitstsHair中
        PopObj.SetActive(true); //場景上要看得見
        //Debug.Log("Pop");
    }
}
