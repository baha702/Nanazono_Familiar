using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenSize : MonoBehaviour
{
public void OnClick()
    {
        // ウィンドウモード
        Screen.SetResolution(Screen.width, Screen.height, false);     
    }
}
