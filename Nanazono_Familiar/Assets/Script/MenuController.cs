using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{  
    //　タイトルキー
    [SerializeField]
    private GameObject TitleKey;
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject MenuUI;

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            MenuUI.SetActive(!MenuUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (MenuUI.activeSelf)
            {
                Time.timeScale = 0f;
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    public void StopGame()
    {
        Time.timeScale = 0f;
        TitleKey.SetActive(true);
    }
}