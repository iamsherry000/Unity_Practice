using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Valve.VR;

public class drawer2 : MonoBehaviour
{
    GameObject Hairmodel;
    public Rigidbody attachPoint;//rigidbody
    
    private Vector3[] thickness1;//計算寬度增加座標
    private Vector3[] thickness2;
    private Vector3 NewPos, OldPos;//零時座標變數 New & Old
    public static List<Vector3> PointPos = new List<Vector3>(); //儲存路徑座標

    int down = 0;//滑鼠判定
    public int width = 1;//調整寬度
    public int count = 0;
    public MeshGenerate CreatHair;

    public SteamVR_Action_Boolean TriggerClick;//板機鍵按鈕
    public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;
    private SteamVR_Input_Sources inputSource;

    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");

    void Start()
    {
        Hairmodel = new GameObject();
        Hairmodel.name = "HairModel";
        Debug.Log("按Space 設定寬度");
    }

    private void OnEnable()//listener是自動監聽，可以不用放入update中，否則影響效能。
    {
        TriggerClick.AddOnStateDownListener(Draw, inputSource);
    }
    private void OnDisable()
    {
        //TriggerClick.RemoveOnStateDownListener(Draw, inputSource);
        count++;
        PointPos.Clear();
        down = 0;
    }
    /*private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        GameObject go = GameObject.Instantiate(prefab);
        go.transform.position = attachPoint.transform.position;
        Debug.Log(attachPoint.transform.position);
    }*/

    private void Draw(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (down == 0)
        {
            OldPos = NewPos = attachPoint.transform.position;
            down = 1;
        }
        if (down == 1)
        {
            NewPos = attachPoint.transform.position;
            Debug.Log("OldPos:" + OldPos);
            Debug.Log("NewPos:" + NewPos);
            float dist = Vector3.Distance(OldPos, NewPos);
            if (dist > 0.1f)
            {
                PosGenerate(NewPos, OldPos);
                OldPos = NewPos = attachPoint.transform.position;
            }
            if (PointPos.Count >= (width * 2 + 1) * 2)
            {
                if (Hairmodel.GetComponent<MeshGenerate>() == null) CreatHair = Hairmodel.AddComponent<MeshGenerate>();//判斷是否已經存在組件(MeshGenerate.cs)
                else CreatHair = Hairmodel.GetComponent<MeshGenerate>();

                CreatHair.meshGenerate(count, width, PointPos);//呼叫MeshGenerate.cs中的meshGenerate函式
            }
        }
    }
        
    void PosGenerate(Vector3 pos1, Vector3 pos2)//計算點座標 (1)主線段點(2)右左兩個延伸點座標計算
    {
        //右左兩個延伸點座標矩陣
        thickness1 = new Vector3[width];
        thickness2 = new Vector3[width];

        //算兩點向量差
        Vector3 Vec0 = pos1 - pos2;//兩點移動方向向量

        for (int i = 0, j = thickness1.Length; i < thickness1.Length; i++, j--)//widthAdd1
        {
            Vector3 Vec1 = new Vector3((Vec0.y) * j, (-Vec0.x) * j, Vec0.z * j);
            thickness1[i] = new Vector3(pos1.x + Vec1.x, pos1.y + Vec1.y, pos1.z + Vec1.z);
            PointPos.Add(thickness1[i]);
        }

        PointPos.Add(NewPos);

        for (int i = 0, j = 1; i < thickness2.Length; i++, j++)//widthAdd
        {
            Vector3 Vec2 = new Vector3((-Vec0.y) * j, (Vec0.x) * j, (-Vec0.z) * j);
            thickness2[i] = new Vector3(pos1.x + Vec2.x, pos1.y + Vec2.y, pos1.z + Vec2.z);
            PointPos.Add(thickness2[i]);
        }

    }

    /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = 0; i < PointPos.Count; i++)
        {
            Gizmos.DrawSphere(PointPos[i], 0.1f);
        }
    }

    public void controlWidth()
    {
        if (Input.GetKeyDown("down") && width > 1 && down == 0)//設定mesh寬度
        {
            width--;
            Debug.Log("Range" + width);
        }
        if (Input.GetKeyDown("up") && down == 0)
        {
            width++;
            Debug.Log("Range" + width);
        }

    }*/

    void Update()
    {
        
    }
}
