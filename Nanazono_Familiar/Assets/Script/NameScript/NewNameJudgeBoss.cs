using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class NewNameJudgeBoss : MonoBehaviour
{
    public int strLength;
    public int MobstrLength;
    public int listnum;
    private int Namenum = 0;
    private float waitnum = 1.0f;
    [SerializeField] TextMeshProUGUI[] enemyMoyaTMP;
    [SerializeField] TextMeshProUGUI[] enemyTMP;
    string inputKatakana;
    string inputHiragana;
    string strKatakana;
    string strHiragana;
    public string MobStrKatakana;
    public string MobStrHiragana;
    public GameObject[] MobEnemyObject;

    Entity_NameList es = null;
    Entity_Sheet1 ex = null;

     int strFlag;
    private bool iscalledOnce;
    public bool MobDestroybool;
    public bool[] flag;
    public Material blueMaterial, redMaterial;

    private Animator animator;
    private bool atombool;

    public GameObject FadePanel;
    FadeController fadeController;
    NameJudge nameJudge;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        fadeController = FadePanel.GetComponent<FadeController>();
        NameList(listnum);
        strKatakana = inputKatakana;
        var ar = strKatakana.Split(',');
        strHiragana = inputHiragana;
        for (int i = 0; i < strLength; i++)
        {

            NameSet(ar[i], enemyTMP[i]);
        }
        Debug.Log(strKatakana);
    }

    // Update is called once per frame
    void Update()
    {

        if (MobDestroybool)
        {
            StartCoroutine("NameColorChange");
        }

        if (strFlag >= strLength)
        {
            StartCoroutine("Coroutine");
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        NameRepeat(collision);
    }


    private IEnumerator Coroutine()
    {

        CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
        if (atomSrc != null)
        {
            atomSrc.Play(22);

        }

        animator.SetTrigger("Dead");
        //１秒待機
        yield return new WaitForSeconds(1.5f);
        fadeController.isFadeOut = true;

        /*for (int i = 0; i < strLength; i++)
        {
            enemyTMP[i].fontSharedMaterial = redMaterial;
        }*/


        atombool = false;

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameClear");
        Destroy(this.gameObject);
        this.gameObject.SetActive(false);      
        strFlag = 0;
        //コルーチンを終了
        yield break;
    }



    private void NameSet(string str, TextMeshProUGUI TMPstr)
    {
        TMPstr.text = string.Format(str);
    }


    public void NameRepeat(Collision collision)
    {
        string hitObjectName = collision.gameObject.transform.root.name;
        Debug.Log(hitObjectName);
        var ar = strKatakana.Split(',');
        var ar2 = strHiragana.Split(',');
        if (GameObject.FindWithTag("flyingText"))
        {
            if (hitObjectName == ar[0] + ar[1] || hitObjectName == ar2[0] + ar2[1])
            {
                for (int i = 0; i < strLength; i++)
                {

                    enemyTMP[i].text = string.Format(ar[i]);
                    enemyTMP[i].fontSharedMaterial = blueMaterial;

                    CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
                    if (atomSrc != null)
                    {

                        if (atombool == false)
                        {
                            atomSrc.Play(22);

                        }
                    }

                    if (flag[i] == false)
                    {
                        strFlag++;
                        flag[i] = true;
                        Debug.Log(strFlag);
                    }
                }
            }
            //NameJudges(ar[i], ar2[i], enemyTMP[i],i);

        }
    }

    

    private IEnumerator NameColorChange()
    {
        MobDestroybool = false;
        Debug.Log("NameColorChange");
        var ar = strKatakana.Split(',');
        var ar2 = strHiragana.Split(',');
        
        for (int i = 0; i < strLength; i++)
        {
            if (MobStrKatakana.Contains(ar[i]) || MobStrHiragana.Contains(ar2[i]))//Mob敵の名前とボスの名前の合否を判断
            {
                
                if (Namenum < 6)
                {
                    
                    //青くする
                    enemyMoyaTMP[i].color = Color.blue;
                    yield return new WaitForSeconds(waitnum);
                    enemyMoyaTMP[i].color = Color.white;
                    
                }
                if (Namenum >= 6)
                {
                   
                    //非表示
                    enemyMoyaTMP[i].GetComponent<TextMeshProUGUI>().enabled = false;
                    yield return new WaitForSeconds(waitnum);
                    enemyMoyaTMP[i].GetComponent<TextMeshProUGUI>().enabled = true;
                    waitnum = waitnum + 0.5f;
                    Debug.Log("Waitnum" + waitnum);
                    
                }
                Namenum++;
                Debug.Log("Namenum"+Namenum);

            }
        }

       

        yield break;
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
            case 12:
                int num12 = 0;
                inputKatakana = es.sheets[0].list[num12].boss10;
                inputHiragana = ex.sheets[0].list[num12].Hira_boss10;
                break;
        }
    }
}
