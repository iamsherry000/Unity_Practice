using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHair : MonoBehaviour
{
    int TriggerDown = 0;  //沒被按下
    int HairCounter = 0; //Hair片數
    int HairWidth = 1; //Hair寬度

    float length=0.5f; //點距離

    Vector3 NewPos, OldPos; //抓新舊點

    public static List<Vector3> PointPos = new List<Vector3>(); //Pos座標存取
    public List<GameObject> HairModel = new List<GameObject>(); //髮片Gameobj存取

    public MeshGenerate MeshCreater; //呼叫 MeshGenerate.cs 中的東西給 MeshCreater 用
    public PosGenerate PosCreater; //呼叫 PosGenerate.cs 中的東西給 PosCreater 用

    private void Start()
    {
        PosCreater = gameObject.AddComponent<PosGenerate>(); //加入PosGenerate
    }

    void ResetPos()
    {
        OldPos = NewPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
    }

    void Update()
    {
        if(TriggerDown == 0) //沒被按下
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
                MeshCreater.GenerateMesh(PointPos,HairWidth);
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (PointPos.Count >= (3 + (HairWidth - 1) * 2) * 2) HairCounter++;
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
    }
}
