﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBarCtrl : MonoBehaviour
{
    Slider _slider;
    public GameObject EnemyObject;
    public bool Damageflag;
    public float EikyouPower;
    public float Ruizido;
    public float AllDamage;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("HPBar").GetComponent<Slider>();
        Damageflag = false;
        EikyouPower = 0.5f;
        Ruizido = 2.0f;
    }

    // HP上昇
    float _hp = 100;
    void Update()
    {
        
        Debug.Log(_hp);
      if (_hp < _slider.minValue)
      {
        // 最大を超えたら0に戻す
        _hp = _slider.maxValue;
        Destroy(this.gameObject);
      }

       // HPゲージに値を設定
        _slider.value = _hp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flyingText"))
        {
            Debug.Log("ダメージ");
            AllDamage = EikyouPower * Ruizido;
            _hp -= AllDamage;
            //Damageflag = true;
        }
    }

}
