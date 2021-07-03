using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class NameJudgeTutorial : MonoBehaviour
{

    public int strLength;
    public int listnum;
    [SerializeField] TextMeshProUGUI[] enemyTMP;
    string inputKatakana;
    string inputHiragana;
    string strKatakana;
    string strHiragana;

    Entity_NameList es = null;
    Entity_Sheet1 ex = null;

    private int strFlag;
    private bool iscalledOnce;
    public bool[] flag;
    public Material blueMaterial, redMaterial;
    float enemyMoveAI;
    public float enemyspeed = 0;

    AudioSource audio;
    public AudioClip DMGClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        NameList(listnum);
        strKatakana = inputKatakana;
        var ar = strKatakana.Split(',');
        strHiragana = inputHiragana;
        for (int i = 0; i < strLength; i++)
        {

            NameSet(ar[i], enemyTMP[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (strFlag >= strLength)
        {
            StartCoroutine("Coroutine");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        NameRepeat();
    }


    private IEnumerator Coroutine()
    {
        //１秒待機
        yield return new WaitForSeconds(0.5f);

        this.gameObject.SetActive(false);
        for (int i = 0; i < strLength; i++)
        {
            enemyTMP[i].fontSharedMaterial = redMaterial;
        }
        strFlag = 0;
        Destroy(this.gameObject);

        //コルーチンを終了
        yield break;
    }
    private void NameSet(string str, TextMeshProUGUI TMPstr)
    {
        TMPstr.text = string.Format(str);
    }


    public void NameRepeat()
    {

        var ar = strKatakana.Split(',');
        var ar2 = strHiragana.Split(',');
        enemyMoveAI = this.gameObject.GetComponent<EnemyMoveAI>().speed;
        for (int i = 0; i < strLength; i++)
        {

            if (GameObject.Find("FlyingText") != null)
            {
                if (GameObject.Find(ar[i]) != null || GameObject.Find(ar2[i]) != null)
                {
                    enemyTMP[i].text = string.Format(ar[i]);
                    enemyTMP[i].fontSharedMaterial = blueMaterial;
                    audio.PlayOneShot(DMGClip, 1.0f);
                    if (flag[i] == false)
                    {
                        this.gameObject.GetComponent<EnemyMoveAI>().speed = enemyspeed;
                        strFlag++;
                        flag[i] = true;
                        Debug.Log(strFlag);
                    }
                }

            }

        }
    }
    public void NameList(int number)
    {
        es = Resources.Load("NameList") as Entity_NameList;
        ex = Resources.Load("NameList_Hiragana") as Entity_Sheet1;

        switch (number)
        {
            case 1:
                int num = Random.Range(0, 10);
                inputKatakana = es.sheets[0].list[num].kake2;
                inputHiragana = ex.sheets[0].list[num].Hira_kake2;
                break;
            case 2:
                int num2 = Random.Range(0, 62);
                inputKatakana = es.sheets[0].list[num2].kake3;
                inputHiragana = ex.sheets[0].list[num2].Hira_kake3;
                break;
            case 3:
                int num3 = Random.Range(0, 82);
                inputKatakana = es.sheets[0].list[num3].kake4;
                inputHiragana = ex.sheets[0].list[num3].Hira_kake4;
                break;
            case 4:
                int num4 = Random.Range(0, 41);
                inputKatakana = es.sheets[0].list[num4].kake5;
                inputHiragana = ex.sheets[0].list[num4].Hira_kake5;
                break;
            case 5:
                int num5 = Random.Range(0, 6);
                inputKatakana = es.sheets[0].list[num5].kake6;
                inputHiragana = ex.sheets[0].list[num5].Hira_kake6;
                break;
            case 6:
                int num6 = Random.Range(0, 20);
                inputKatakana = es.sheets[0].list[num6].yominikui3;
                inputHiragana = ex.sheets[0].list[num6].Hira_yominikui3;
                break;
            case 7:
                int num7 = Random.Range(0, 19);
                inputKatakana = es.sheets[0].list[num7].yominikui4;
                inputHiragana = ex.sheets[0].list[num7].Hira_yominikui4;
                break;
            case 8:
                int num8 = Random.Range(0, 6);
                inputKatakana = es.sheets[0].list[num8].yominikui5;
                inputHiragana = ex.sheets[0].list[num8].Hira_yominikui5;
                break;
            case 9:
                int num9 = Random.Range(0, 9);
                inputKatakana = es.sheets[0].list[num9].boss11;
                inputHiragana = ex.sheets[0].list[num9].Hira_boss11;
                break;
            case 10:
                int num10 = Random.Range(0, 4);
                inputKatakana = es.sheets[0].list[num10].boss12;
                inputHiragana = ex.sheets[0].list[num10].Hira_boss12;
                break;
            case 11:
                int num11 = Random.Range(0, 2);
                inputKatakana = es.sheets[0].list[num11].boss13;
                inputHiragana = ex.sheets[0].list[num11].Hira_boss13;
                break;
        }
    }
}