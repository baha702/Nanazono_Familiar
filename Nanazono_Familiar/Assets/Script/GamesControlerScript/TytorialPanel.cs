using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TytorialPanel : MonoBehaviour
{
    //　タイトルキー
    [SerializeField]
    private GameObject TutorialKey;
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject TutorialCanvas;   
    public AudioClip menuClip;

    void Start()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {           
            //　ポーズUIのアクティブ、非アクティブを切り替え
            TutorialCanvas.SetActive(!TutorialCanvas.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (TutorialCanvas.activeSelf)
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
        TutorialKey.SetActive(true);
    }
}