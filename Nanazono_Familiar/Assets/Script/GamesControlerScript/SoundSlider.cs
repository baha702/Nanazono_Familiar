using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Sliderを使用するために必要

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{

    Slider m_Slider;//音量調整用スライダー
    public Slider atomSlider;
    public const string BGMCategoryName = "BGM";
   
    [SerializeField]
    float m_ScroolSpeed = 1;//キー入力で調整バーを動かすスピード
    void Awake()
    {
        atomSlider = GetComponent<Slider>();
        //m_Slider.value = AudioListener.volume;
        atomSlider.onValueChanged.AddListener((value) => { CriAtom.SetCategoryVolume(BGMCategoryName, value); });
    }

    private void OnEnable()
    {
        //m_Slider.value = AudioListener.volume;
        //スライダーの値が変更されたら音量も変更する
        //m_Slider.onValueChanged.AddListener((sliderValue) => AudioListener.volume = sliderValue);
        atomSlider.value = CriAtom.GetCategoryVolume(BGMCategoryName);
    }

    private void OnDisable()
    {
        //m_Slider.onValueChanged.RemoveAllListeners();
    }
}