using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameData : MonoBehaviour
{
    public string inputKatakana;
    public string inputHiragana;
    Entity_NameList es;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nameLists(int number)
    {
        es = Resources.Load("NameList") as Entity_NameList;
        switch (number)
        {
            case 1:
                int num = Random.Range(0, 10);
                inputKatakana = es.sheets[0].list[num].kake2;
                inputHiragana = es.sheets[1].list[num].kake2;
                break; 
            case 2:
                int num2 = Random.Range(0, 62);
                inputKatakana = es.sheets[0].list[num2].kake3;
                inputHiragana = es.sheets[1].list[num2].kake3;
                break;
            case 3:
                int num3 = Random.Range(0, 82);
                inputKatakana = es.sheets[0].list[num3].kake4;
                inputHiragana = es.sheets[1].list[num3].kake4;
                break;
            case 4:
                int num4 = Random.Range(0, 41);
                inputKatakana = es.sheets[0].list[num4].kake5;
                inputHiragana = es.sheets[1].list[num4].kake5;
                break;
            case 5:
                int num5 = Random.Range(0, 6);
                inputKatakana = es.sheets[0].list[num5].kake6;
                inputHiragana = es.sheets[1].list[num5].kake6;
                break;
            case 6:
                int num6 = Random.Range(0, 20);
                inputKatakana = es.sheets[0].list[num6].yominikui3;
                inputHiragana = es.sheets[1].list[num6].yominikui3;
                break;
            case 7:
                int num7 = Random.Range(0, 19);
                inputKatakana = es.sheets[0].list[num7].yominikui4;
                inputHiragana = es.sheets[1].list[num7].yominikui4;
                break;
            case 8:
                int num8 = Random.Range(0, 6);
                inputKatakana = es.sheets[0].list[num8].yominikui5;
                inputHiragana = es.sheets[1].list[num8].yominikui5;
                break;
            case 9:
                int num9 = Random.Range(0, 9);
                inputKatakana = es.sheets[0].list[num9].boss11;
                inputHiragana = es.sheets[1].list[num9].boss11;
                break;
            case 10:
                int num10 = Random.Range(0, 4);
                inputKatakana = es.sheets[0].list[num10].boss12;
                inputHiragana = es.sheets[1].list[num10].boss12;
                break;
            case 11:
                int num11 = Random.Range(0, 2);
                inputKatakana = es.sheets[0].list[num11].boss13;
                inputHiragana = es.sheets[1].list[num11].boss13;
                break;
        }
    }
}
