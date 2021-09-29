using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NameData : MonoBehaviour
{
    public string inputKatakanaBoss;
    public string inputHiraganaBoss;
    public string inputKatakana;
    public string inputHiragana;
    public int strLength;
    Entity_NameList es;
    // Start is called before the first frame update
    

    public void nameLists(int number)
    {
        //Stage01
        switch (number)
        {
            case 1:
                inputHiraganaBoss = "ロ,イ";
                inputHiraganaBoss = "ろ,い";
                if (strLength==2)
                {
                    int zakonum = Random.Range(0,2);
                    switch (zakonum)
                    {
                        case 0:
                            inputKatakana = "オ,ヨ";
                            inputHiragana = "お,よ";
                            break;
                        case 1:
                            inputKatakana = "ヤ,イ";
                            inputHiragana = "や,い";
                            break;
                    }
                }
                if (strLength == 3)
                {
                    int zakonum = Random.Range(0, 5);
                    switch (zakonum)
                    {
                        case 0:
                            inputKatakana = "ル,ー,ド";
                            inputHiragana = "る,ー,ど";
                            break;
                        case 1:
                            inputKatakana = "キ,ッ,カ";
                            inputHiragana = "き,っ,か";
                            break;
                        case 2:
                            inputKatakana = "ヤ,コ,ブ";
                            inputHiragana = "や,こ,ぶ";
                            break;
                        case 3:
                            inputKatakana = "カ,ル,ロ";
                            inputHiragana = "か,る,ろ";
                            break;
                       
                    }
                }

                break;
            case 2:
                inputHiraganaBoss = "イ,ブ";
                inputHiraganaBoss = "い,ぶ";
                if (strLength == 2)
                {
                    int zakonum = Random.Range(0, 2);
                    switch (zakonum)
                    {
                        case 0:
                            inputKatakana = "ル,イ";
                            inputHiragana = "る,い";
                            break;
                        case 1:
                            inputKatakana = "ナ,コ";
                            inputHiragana = "な,こ";
                            break;
                    }
                }
                if (strLength == 3)
                {
                    int zakonum = Random.Range(0, 5);
                    switch (zakonum)
                    {
                        case 0:
                            inputKatakana = "ル,ー,ド";
                            inputHiragana = "る,ー,ど";
                            break;
                        case 1:
                            inputKatakana = "ク,レ,ヤ";
                            inputHiragana = "く,れ,や";
                            break;
                        case 2:
                            inputKatakana = "ヤ,コ,ブ";
                            inputHiragana = "や,こ,ぶ";
                            break;
                        case 3:
                            inputKatakana = "ラ,ル,ク";
                            inputHiragana = "ら,る,く";
                            break;

                    }
                }
                break;
            case 3:
                inputHiraganaBoss = "ニ,コ";
                inputHiraganaBoss = "に,こ";
                break;
            case 4:
                inputHiraganaBoss = "レ,オ";
                inputHiraganaBoss = "れ,お";
                break;
            case 5:
                inputHiraganaBoss = "ベ,ラ";
                inputHiraganaBoss = "べ,ら";
                break;

        }
    }
}
