using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coundown : MonoBehaviour
{
    private bool atombool;
    public Text timerText;

    public float totalTime;//時間（実数）Insepectorから入力
    int seconds;//時間（整数）

    // Use this for initialization
    void Start()
    {

        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play();



        }

    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;//時間をマイナスしていく
        seconds = (int)totalTime;//小数点以下を切り捨てる
        timerText.text = seconds.ToString();//文字列に変換
        if (totalTime < 1f)//カウントが1より小さくなった場合
        {
            timerText.GetComponent<Text>().enabled = false;//表示を消す

            CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
            if (atomSrc != null)
            {

                if (atombool == false)
                {
                    atomSrc.Play(0);
                    atombool = true;
                }
            }

        }
    }
}