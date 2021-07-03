using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    //仮まくりのアニメーション再生確認用

    Animator animVoiceInput;
    Animator animReticle;

    void Start()
    {
        animVoiceInput = GameObject.Find("VoiceInput").gameObject.GetComponent<Animator>();
        animReticle = GameObject.Find("Reticle").gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animVoiceInput.SetBool("MouseHold", true);
            animReticle.SetBool("VoiceInput", true);

        }
        else
        {
            animVoiceInput.SetBool("MouseHold", false);
            animReticle.SetBool("VoiceInput", false);
        }
    }
}
