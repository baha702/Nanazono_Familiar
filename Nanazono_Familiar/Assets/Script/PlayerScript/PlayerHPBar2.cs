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

    // Use this for initialization
    void Start()
    {
        maxhp = 5;
        _slider = slider.GetComponent<Slider>();//sliderを取得する
        hp = maxhp;
        Debug.Log("HP"+hp);
    }
    
    // Update is called once per frame
    void Update()
    {
        _slider.value = hp;//スライダーとHPの紐づけ
        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")//衝突した相手のタグがEnemyなら
        {
            hp -= 1;//hpを-1ずつ変える
            Debug.Log(hp);
        }

        if (collision.gameObject.tag == "EnemyText")
        {
            hp -= 4;//hpを-1ずつ変える
            Debug.Log(hp);
        }

        if (hp == 0)//もしhpが0以下なら
        {            
                SceneManager.LoadScene("GameOver");           
        }
    }
    // イベントハンドラー（イベント発生時に動かしたい処理）
    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        hp = 5;
        Debug.Log("ロードシーン");

    }
}