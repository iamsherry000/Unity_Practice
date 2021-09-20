//別忘記要改 Point Pos

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHair3 : MonoBehaviour
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
    //Stack<int> StackforFunctions = new Stack<int>(); // 存取做了甚麼功能
    GameObject PushObj, PopObj;
    GameObject ExistHair;
    int u_Freq = 0, c_Freq = 0;
    int TempListExistHair = 0;

    private void Start()
    {
        PosCreater = gameObject.AddComponent<PosGenerate>(); //加入PosGenerate
    }

    void ResetPos()
    {
        OldPos = NewPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    void PushStaff() //push staff into 
    {
        PushObj = Instantiate(ListExistHair[ListExistHair.Count - 1]); //生成ListExitstHair中count-1的物件
        StackExistHair.Push(PushObj); //生成的物件(pushobj)push進stack存，之後要redo要用
        PushObj.SetActive(false); //場景上不再看得見
        Destroy(ListExistHair[ListExistHair.Count - 1]); //刪除ListExitstHair中count-1的物件
        ListExistHair.RemoveAt(ListExistHair.Count - 1); //從ListExistHair中移除count-1的物件
    }

    void PopStaff() 
    {
        PopObj = StackExistHair.Pop(); //從stack中pop東西出來
        ListExistHair.Add(PopObj); //加回ListExitstsHair中
        PopObj.SetActive(true); //場景上要看得見
    }


    void Update()
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
                    u_Freq = 0;
                }

                else
                {
                    //清除不夠長所以沒加到程式碼的的髮片gameobj
                    int least = HairModel.Count - 1;
                    Destroy(HairModel[least]);
                    HairModel.RemoveAt(least);
                }
                PointPos.Clear();
                TriggerDown = 0;
            }
        }
        if (Input.GetKeyDown("u") && c_Freq ==0)
        {
            u_Freq += 1;
            PushStaff();
        }

        if(Input.GetKeyDown("u") && c_Freq != 0)
        {
            u_Freq += 1;
            for (int i = 0; i < TempListExistHair; i++)
            {
                PopStaff();
            }
            c_Freq = 0;
        }
        //不能有東西,redo 跟著 Undo
        if (Input.GetKeyDown("r") && u_Freq != 0 && u_Freq - c_Freq!=1)
        {
            PopStaff();
            if (StackExistHair.Count == 0) u_Freq = 0; //break
        }
        if (Input.GetKeyDown("r") && u_Freq != 0 && u_Freq - c_Freq == 1)
        {
            c_Freq = 1;
            TempListExistHair = ListExistHair.Count;
            for (int i = 0; i < TempListExistHair; i++)
            {
                PushStaff(); //List中的丟到Stack中存著 (Stack目前沒有最大值)
            }
        }

        if (Input.GetKeyDown("c") && ListExistHair.Count != 0) 
        {
            c_Freq = 1;
            TempListExistHair = ListExistHair.Count;
            for (int i = 0; i < TempListExistHair; i++) 
            {
                PushStaff(); //List中的丟到Stack中存著 (Stack目前沒有最大值)
            }
        }
    }
}
