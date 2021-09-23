using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTextWriter : MonoBehaviour
{
    public DialogueText uitext;
    public GameObject TalkText;
    public GameObject Player;
    public GameObject Camera;
    public GameObject BossObject;
    public GameObject HpBarUI;
    public GameObject ReticleUI;
    public GameObject MenuUIObject;
    public GameObject FadePanel;
    public GameObject Apple;
    public GameObject EnemyBornObject01, EnemyBornObject02, EnemyBornObject03, EnemyBornObject04;
    public GameObject CountDown;

    bool Objectflag;
    KotodamariScript kotodama;
    PlayerController Playercamera;
    MenuController menuController;
    PlayerHPBar2 hpbar;
    FadeController fadeController;
    BossAtack bossAtack;
    HealItemScript heal;

    

    // Start is called before the first frame update
    void Start()
    {
        kotodama = Player.GetComponent<KotodamariScript>();
        Playercamera = Camera.GetComponent<PlayerController>();
        menuController = GetComponent<MenuController>();
        hpbar = Player.GetComponent<PlayerHPBar2>();
        fadeController = FadePanel.GetComponent<FadeController>();
        bossAtack = BossObject.GetComponent<BossAtack>();
        heal = Apple.GetComponent<HealItemScript>();

        hpbar.hp = 4;
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine("Cotest");
        
    }

    private void Update()
    {
        
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
        uitext.DrawText("……。");
        yield return StartCoroutine("Skip");

        uitext.DrawText("?");
        yield return StartCoroutine("Skip");

       
        
        TalkText.SetActive(false);

    }

    void ObjectsSetactive(bool objectbool)
    {
        Player.GetComponent<KotodamariScript>().enabled = objectbool;
        Playercamera.Camera.GetComponent<PlayerController>().enabled = objectbool;
        MenuUIObject.GetComponent<MenuController>().enabled = objectbool;
        bossAtack.GetComponent<BossAtack>().enabled = objectbool;
        heal.GetComponent<HealItemScript>().enabled = objectbool;
        HpBarUI.SetActive(objectbool);
        ReticleUI.SetActive(objectbool);
        CountDown.SetActive(objectbool);
        EnemyBornObject01.SetActive(objectbool);
        EnemyBornObject02.SetActive(objectbool);
        EnemyBornObject03.SetActive(objectbool);
        EnemyBornObject04.SetActive(objectbool);
    }

    /*IEnumerator TutorialEnd()
    {
        if (hpbar.hp == 5)
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

            uitext.DrawText("名前を呼んだらなんか倒しちゃった。");
            yield return StartCoroutine("Skip");

            uitext.DrawText("……。");
            yield return StartCoroutine("Skip");

            uitext.DrawText("自分一人じゃこの穴から出られないし、助けを待つしかないか……。");
            yield return StartCoroutine("Skip");


        }

        fadeController.isFadeOut = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("StageChoice");
    }*/
    

    
}
