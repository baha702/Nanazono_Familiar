using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPBar2 : MonoBehaviour
{
    public float hp ;//hpを5にする。SliderのMaxValueとValueはここの値に合わせます
    public float maxhp;
    private Slider _slider;//Sliderの値を代入する_sliderを宣言
    public GameObject slider;//体力ゲージに指定するSlider
    public GameObject FadePanel;
    FadeController fade;

    // Use this for initialization
    void Start()
    {
        fade = FadePanel.GetComponent<FadeController>();
        maxhp = 5;
        _slider = slider.GetComponent<Slider>();//sliderを取得する
        hp = maxhp;
        Debug.Log("HP"+hp);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (hp>5)
        {
            hp = 5;
        }
        _slider.value = hp;//スライダーとHPの紐づけ
        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Enemy")//衝突した相手のタグがEnemyなら
        {

            CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
            if (atomSrc != null)
            {
                atomSrc.Play(12);



            }

            hp -= 0.2f;//hpを-0.2ずつ変える
            Debug.Log(hp);
        }

        if (collision.gameObject.tag == "EnemyText")
        {
            CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
            if (atomSrc != null)
            {
                atomSrc.Play(12);
                Debug.Log("BossATK当たってる");


            }
            hp -= 1;
        }

        if (collision.gameObject.tag == "EnemyN")//衝突した相手のタグがEnemyNなら
        {

            CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
            if (atomSrc != null)
            {
                atomSrc.Play(12);



            }

            hp -= 1;//hpを-1ずつ変える
            Debug.Log(hp);
        }

        if (collision.gameObject.tag == "EnemyT")//衝突した相手のタグがEnemyNなら
        {

            CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
            if (atomSrc != null)
            {
                atomSrc.Play(12);



            }

            hp -= 2;//hpを-2ずつ変える
            Debug.Log(hp);
        }

        if (hp <= 0)//もしhpが0以下なら
        {

            StartCoroutine("SceneWait");
        }
    }

    IEnumerator SceneWait()
    {
        fade.isFadeOut = true;
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("GameOver");
        yield break;
    }
    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        hp = 5;
        Debug.Log("ロードシーン");

    }
}