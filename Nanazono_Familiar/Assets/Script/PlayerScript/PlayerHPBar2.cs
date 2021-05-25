using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHPBar2 : MonoBehaviour
{
    public float hp ;//hpを5にする。SliderのMaxValueとValueはここの値に合わせます
    public float maxhp = 5;
    private Slider _slider;//Sliderの値を代入する_sliderを宣言
    public GameObject slider;//体力ゲージに指定するSlider

    // Use this for initialization
    void Start()
    {
        _slider = slider.GetComponent<Slider>();//sliderを取得する
        hp = maxhp;
        Debug.Log("HP満タン");
    }
    
    // Update is called once per frame
    void Update()
    {
        _slider.value = hp;//スライダーとHPの紐づけ
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")//衝突した相手のタグがEnemyなら
        {
            hp -= 1;//hpを-1ずつ変える
            Debug.Log(hp);
        }

        if (hp == 0)//もしhpが0以下なら
        {            
                SceneManager.LoadScene("GameOver");           
        }
    }
}