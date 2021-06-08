using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using Valve.VR;

public class objCreater : MonoBehaviour
{
    public SteamVR_Input_Sources LeftInputSource = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources RightInputSource = SteamVR_Input_Sources.RightHand;
    private SteamVR_Input_Sources inputSource;
    public SteamVR_Action_Boolean TriggerClick;//板機鍵按鈕
    private SteamVR_Behaviour_Pose m_Pose = null;

    public GameObject mycube;

    public Vector3 older; public Vector3 now;

    void Awake()
    {
        //m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
    }

    void Start()
    {
        
    }

    private void OnEnable()
    {
        TriggerClick.AddOnStateDownListener(Press, inputSource);
    }

    private void OnDisable()
    {
        TriggerClick.RemoveOnStateDownListener(Press, inputSource);
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        mycube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        mycube.transform.position = new Vector3(1, 1, 1);
        Debug.Log("success");
    }

    void Update()
    {
        //now = m_Pose.transform.position;
        Debug.Log("Left Trigger value:" + SteamVR_Actions._default.Squeeze.GetAxis(LeftInputSource).ToString());
        Debug.Log("Right Trigger value:" + SteamVR_Actions._default.Squeeze.GetAxis(RightInputSource).ToString());

    }
}
