using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MouseSensitivity : MonoBehaviour
{
    public GameObject maincamera;
    Slider SensitivitySlider;//マウス調節用スライダー
    [SerializeField]
    float ScroolSpeed = 1;//キー入力で調整バーを動かすスピード
    public PlayerController playerConotroller;
    
    void Start()
    {
        playerConotroller = maincamera.GetComponent<PlayerController>();
        SensitivitySlider = GetComponent<Slider>();
        SensitivitySlider.value = playerConotroller.AngeleRotation;
        SensitivitySlider.maxValue = 450f;
    }

    public void OnEnable()
    {
        
        playerConotroller.AngeleRotation = SensitivitySlider.value;
    }

    private void OnDisable()
    {
       
    }
}
