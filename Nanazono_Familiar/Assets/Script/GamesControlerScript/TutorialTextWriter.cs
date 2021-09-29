using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialTextWriter : MonoBehaviour
{
    public DialogueText uitext;
    public GameObject NameText;
    public GameObject TalkText;
    public GameObject Exptext;
    public GameObject Player;
    public GameObject Camera;
    public GameObject HpBarUI;
    public GameObject ReticleUI;
    public GameObject MenuUIObject;
    public GameObject FadePanel;
    public GameObject Apple;
    KotodamariScript kotodama;
    PlayerController Playercamera;
    MenuController menuController;
    PlayerHPBar2 hpbar;
    FadeController fadeController;

    public GameObject ImgObject,ImgObject2;
    public GameObject nextbutton,nextbutton2;
    public GameObject EnemyObject,EnemyObject2;
    public Text exptext;
    bool isCalledOnece,isCalledOnce2,isCalledOnce3,applecalledOnce;
    // Start is called before the first frame update
    void Start()
    {
        kotodama = Player.GetComponent<KotodamariScript>();
        Player.GetComponent<KotodamariScript>().enabled = false;
        Playercamera = Camera.GetComponent<PlayerController>();
        Playercamera.Camera.GetComponent<PlayerController>().enabled = false;
        menuController = GetComponent<MenuController>();
        MenuUIObject.GetComponent<MenuController>().enabled = false;
        hpbar = Player.GetComponent<PlayerHPBar2>();
        fadeController = FadePanel.GetComponent<FadeController>();
        hpbar.hp = 4;
        HpBarUI.SetActive(false);
        ReticleUI.SetActive(false);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine("Cotest");
        EnemyObject2.SetActive(false);
    }

    private void Update()
    {
        if (EnemyObject == null)
        {
            if (!isCalledOnece)
            {


                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                ImgObject2.SetActive(true);
                nextbutton2.SetActive(true);
                Player.GetComponent<KotodamariScript>().enabled = false;
                Playercamera.Camera.GetComponent<PlayerController>().enabled = false;
                MenuUIObject.GetComponent<MenuController>().enabled = false;
                HpBarUI.SetActive(false);
                ReticleUI.SetActive(false);
                NameText.SetActive(false);
                TalkText.SetActive(false);
                Exptext.SetActive(false);
                isCalledOnece = true;
            }
        }
        if (hpbar.hp > 4)
        {
            if (Apple == null && !isCalledOnce2)
            {
                EnemyObject2.SetActive(true);
                exptext.fontSize = 40;
                exptext.text = ("おばけが襲ってきた！\n\n倒そう！");
                isCalledOnce2 = true;
            }
        }
        if (isCalledOnce2)
        {
            if (EnemyObject2 == null)
            {
                if (!isCalledOnce3)
                {
                   
                    StartCoroutine("TutorialEnd");
                    isCalledOnce3 = true;
                }
            }
        }
    }

    // クリック待ちのコルーチン
    IEnumerator Skip()
    {
        
        while (uitext.playing) yield return 0;
        while (!uitext.IsClicked()) yield return 0;
    }

    // 文章を表示させるコルーチン
    IEnumerator Cotest()
    {
        uitext.DrawText("ここは……怪物の出る墓地だ。");
        yield return StartCoroutine("Skip");

        uitext.DrawText("……でも、落とし穴から出られない。");
        yield return StartCoroutine("Skip");

        uitext.DrawText("うわっ、おばけだ！");
        yield return StartCoroutine("Skip");



        ImgObject.SetActive(true);
        nextbutton.SetActive(true);
        NameText.SetActive(false);
        TalkText.SetActive(false);

    }

    IEnumerator TutorialEnd()
    {
        if (hpbar.hp==5)
        {


            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Player.GetComponent<KotodamariScript>().enabled = false;
            Playercamera.Camera.GetComponent<PlayerController>().enabled = false;
            MenuUIObject.GetComponent<MenuController>().enabled = false;
            HpBarUI.SetActive(false);
            ReticleUI.SetActive(false);
            NameText.SetActive(false);
            TalkText.SetActive(true);
            Exptext.SetActive(false);

         

            uitext.DrawText("おばけはどこかに行ったか。");
            yield return StartCoroutine("Skip");

            uitext.DrawText("……助けを待つしかないみたい。");
            yield return StartCoroutine("Skip");


        }
        
        fadeController.isFadeOut = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("StageChoice");
    }
    public void NextButton()
    {
        Debug.Log(" botann");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (ImgObject.activeSelf)
        {
            ImgObject.SetActive(false);
        }
        else if (ImgObject2.activeSelf)
        {
            ImgObject2.SetActive(false);
            exptext.text = ("回復：「リンゴ」\n\n\nりんごに向かって「リンゴ」のコトダマを飛ばそう。");
            exptext.fontSize = 40;
        }
        nextbutton.SetActive(false);
        Player.GetComponent<KotodamariScript>().enabled = true;
        Playercamera.Camera.GetComponent<PlayerController>().enabled = true;
        MenuUIObject.GetComponent<MenuController>().enabled = true;
        HpBarUI.SetActive(true);
        ReticleUI.SetActive(true);
        Exptext.SetActive(true);
      
    }

    public void NextButton2()
    {
        Debug.Log(" botann");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (ImgObject.activeSelf)
        {
            ImgObject.SetActive(false);
        }
        else if (ImgObject2.activeSelf)
        {
            ImgObject2.SetActive(false);
            exptext.text = ("回復：「リンゴ」\n\n\nりんごに向かって「リンゴ」のコトダマを飛ばそう。");
            exptext.fontSize = 40;
        }
        nextbutton2.SetActive(false);
        Player.GetComponent<KotodamariScript>().enabled = true;
        Playercamera.Camera.GetComponent<PlayerController>().enabled = true;
        MenuUIObject.GetComponent<MenuController>().enabled = true;
        HpBarUI.SetActive(true);
        ReticleUI.SetActive(true);
        Exptext.SetActive(true);
        applecalledOnce = true;
    }

}

