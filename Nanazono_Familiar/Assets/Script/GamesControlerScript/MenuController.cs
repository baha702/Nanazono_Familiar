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
    private AudioSource audio;
    public AudioClip menuClip;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            audio.PlayOneShot(menuClip,1.0f);
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