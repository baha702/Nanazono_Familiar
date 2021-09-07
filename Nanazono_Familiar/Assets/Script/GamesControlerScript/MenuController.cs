using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{  
    //　タイトルキー
    //[SerializeField]
    //private GameObject TitleKey;
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject MenuUI;
    private AudioSource audio;
    public AudioClip menuClip;
    public GameObject ReticleUI;

    public bool menuBool=false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (menuBool == true)
        {
            //カーソルを表示
            Cursor.visible = true;
            //カーソルの固定を解除
            Cursor.lockState = CursorLockMode.None;
        }
        if (menuBool == false)
        {
            if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
            {
                
                //　ポーズUIのアクティブ、非アクティブを切り替え
                MenuUI.SetActive(!MenuUI.activeSelf);
                //　ポーズUIが表示されてる時は停止
                
            }
            if (MenuUI.activeSelf)
            {
                //ReticleUI.SetActive(false);
                //カーソルを表示
                Cursor.visible = true;
                //カーソルの固定を解除
                Cursor.lockState = CursorLockMode.None;
                //　ポーズUIが表示されてなければ通常通り進行
                Time.timeScale = 0f;
            }
            else
            {
                //ReticleUI.SetActive(true);
                //カーソルを非表示
                Cursor.visible = false;
                //カーソルを中央に固定
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
        }
    }
    public void StopGame()
    {
        //audio.PlayOneShot(menuClip, 1.0f);
        //　ポーズUIのアクティブ、非アクティブを切り替え
        MenuUI.SetActive(!MenuUI.activeSelf);

        //カーソルを非表示
        Cursor.visible = true;
        //カーソルを中央に固定
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Start");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}