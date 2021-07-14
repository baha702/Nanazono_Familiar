using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    public void OnClick()
    {
        // フルスクリーンモード
        Screen.SetResolution(Screen.width, Screen.height, true);
    }
}
