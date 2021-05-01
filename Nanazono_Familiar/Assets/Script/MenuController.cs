using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //　ゲーム再開ボタン
    [SerializeField]
    private GameObject ReStartButton;
    //　タイトルボタン
    [SerializeField]
    private GameObject TitleBitton;
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
        ReStartButton.SetActive(true);
        TitleBitton.SetActive(true);
    }

    public void ReStartGame()
    {
        if (Input.GetKeyDown("r"))
        {
            TitleBitton.SetActive(false);
            ReStartButton.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void TitleButton()
    {
        if (Input.GetKeyDown("t"))
        {
            {
                SceneManager.LoadScene("Start");
            }

        }
    }
}