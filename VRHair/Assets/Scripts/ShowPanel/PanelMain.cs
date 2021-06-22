using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
    public void PaintClick() {
        GameObject.Find("RightHand").GetComponent<drawer>().enabled = true;
        UIManager.Instance.ShowPanel("RPanel_Paint");
    }
}
