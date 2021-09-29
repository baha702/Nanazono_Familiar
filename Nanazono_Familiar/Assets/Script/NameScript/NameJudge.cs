using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class NameJudge : MonoBehaviour
{

    public int strLength;
    //public int listnum; 
    [SerializeField] TextMeshProUGUI[] enemyTMP;
    string inputKatakana;
    string inputHiragana;
    string strKatakana;
    string strHiragana;
    
    Entity_NameList es = null;
    Entity_Sheet1 ex = null;

    Entity_Katakana Kata = null;
    Entity_Hiragana Hira = null;

    private Animator animator;
    private int strFlag;
    private bool iscalledOnce;
    public bool[] flag;
    public Material blueMaterial,redMaterial;
    float enemyMoveAI;
    public float enemyspeed = 0;

    AudioSource audio;
    public AudioClip DMGClip;

    private bool atombool;
    GameObject EnemyBoss;
    NewNameJudgeBoss newNameJudgeBoss;

    // Start is called before the first frame update
    void Start()
    {
        
        EnemyBoss = GameObject.FindGameObjectWithTag("EnemyBoss");
        newNameJudgeBoss = EnemyBoss.GetComponent<NewNameJudgeBoss>();
        NameList(newNameJudgeBoss.listnum);
        newNameJudgeBoss.MobStrKatakana = inputKatakana;
        newNameJudgeBoss.MobStrHiragana = inputHiragana;
        newNameJudgeBoss.MobstrLength = strLength;
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        strKatakana = inputKatakana;
        var ar = strKatakana.Split(',');
        strHiragana = inputHiragana;
        var ar2 = strHiragana.Split(',');
        for (int i = 0; i < strLength; i++)
        {

            NameSet(ar[i], enemyTMP[i]);
        }
    }
   
     // Update is called once per frame
    void Update()
    {
        
        if (strFlag>=strLength)
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

            if (atombool == false)
            {
                atomSrc.Play(14);
                atombool = true;
            }


        }

        animator.SetTrigger("Dead");
        //１秒待機
        yield return new WaitForSeconds(0.5f);

        this.gameObject.SetActive(false);
        for (int i = 0; i < strLength; i++)
        {
            enemyTMP[i].fontSharedMaterial = redMaterial;
        }
        strFlag = 0;

        atombool = false;

        newNameJudgeBoss.MobDestroybool = true;

        Destroy(this.gameObject);

        //コルーチンを終了
        yield break;
    }
    private void NameSet(string str, TextMeshProUGUI TMPstr)
    {
        TMPstr.text = string.Format(str);
    }
   

    public void NameRepeat(Collision collision)
    {
        string hitObjectName = collision.gameObject.name;
        var ar = strKatakana.Split(',');
        var ar2 = strHiragana.Split(',');
        Debug.Log("strKatakana" + strKatakana);
        Debug.Log("strHiragana"+strHiragana);
        enemyMoveAI = this.gameObject.GetComponent<EnemyMoveAI>().speed;
        for (int i = 0; i < strLength; i++)
        {

            if (GameObject.FindWithTag("flyingText"))
            {
                if (GameObject.Find(ar[i]) != null || GameObject.Find(ar2[i]) != null)
                {
                    enemyTMP[i].text = string.Format(ar[i]);
                    enemyTMP[i].fontSharedMaterial = blueMaterial;

                    CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
                    if (atomSrc != null)
                    {
                        atomSrc.Play();

                    }

                    audio.PlayOneShot(DMGClip, 1.0f);
                    if (flag[i] == false)
                    {
                        animator.SetTrigger("Damage");
                        this.gameObject.GetComponent<EnemyMoveAI>().speed = enemyspeed;
                        strFlag++;
                        flag[i] = true;
                            
                    }
                }
               
                /*if (GameObject.Find(ar[i]) != null || GameObject.Find(ar2[i]) != null)
                {
                    enemyTMP[i].text = string.Format(ar[i]);
                    enemyTMP[i].fontSharedMaterial = blueMaterial;

                    CriAtomSource atomSrc = gameObject.GetComponent<CriAtomSource>();
                    if (atomSrc != null)
                    {
                        atomSrc.Play();

                    }

                    audio.PlayOneShot(DMGClip, 1.0f);
                    if (flag[i] == false)
                    {
                        animator.SetTrigger("Damage");
                        this.gameObject.GetComponent<EnemyMoveAI>().speed = enemyspeed;
                        strFlag++;
                        flag[i] = true;

                    }
                }*/
            }
            
           
        }
    }
    public void NameList(int number)
    {
        
        Kata = Resources.Load("NameListKatakana") as Entity_Katakana;
        Hira = Resources.Load("NameListHiragana") as Entity_Hiragana;

        switch (number)
        {
            case 1:
                switch (newNameJudgeBoss.randomunum)
                {
                    case 0:
                        int num01 = 0;
                        if (strLength == 2)
                        {
                            num01 = Random.Range(0, 2);
                        }
                        if (strLength == 3)
                        {
                            num01 = Random.Range(2, 6);
                        }
                        
                        inputKatakana = Kata.sheets[0].list[num01].kake3;
                        inputHiragana = Hira.sheets[0].list[num01].Hira_kake3;
                        break;
                    case 1:
                        int num02 = 0;
                        if (strLength == 2)
                        {
                            num02 = Random.Range(6, 8);
                        }
                        if (strLength == 3)
                        {
                            num02 = Random.Range(8, 12);
                        }
                        inputKatakana = Kata.sheets[0].list[num02].kake3;
                        inputHiragana = Hira.sheets[0].list[num02].Hira_kake3;
                      
                        break;
                    case 2:
                        int num03 = 0;
                        if (strLength == 2)
                        {
                            num03 = Random.Range(12, 14);
                        }
                        if (strLength == 3)
                        {
                            num03 = Random.Range(14, 18);
                        }
                        inputKatakana = Kata.sheets[0].list[num03].kake3;
                        inputHiragana = Hira.sheets[0].list[num03].Hira_kake3;
                      
                        break;
                    case 3:
                        int num04 = 0;
                        if (strLength == 2)
                        {
                            num04 = Random.Range(18, 21);
                        }
                        if (strLength == 3)
                        {
                            num04 = Random.Range(21, 24);
                        }
                        inputKatakana = Kata.sheets[0].list[num04].kake3;
                        inputHiragana = Hira.sheets[0].list[num04].Hira_kake3;
                    
                        break;
                    case 4:
                        int num05 = 0;
                        if (strLength == 2)
                        {
                            num05 = Random.Range(24, 27);
                        }
                        if (strLength == 3)
                        {
                            num05 = Random.Range(27, 30);
                        }
                        inputKatakana = Kata.sheets[0].list[num05].kake3;
                        inputHiragana = Hira.sheets[0].list[num05].Hira_kake3;
                    
                        break;
                }

                break;

            case 2:

                switch (newNameJudgeBoss.randomunum)
                {
                    case 0:
                        int num01 = 0;
                        if (strLength == 2)
                        {
                            num01 = Random.Range(0, 3);
                        }
                        if (strLength == 3)
                        {
                            num01 = Random.Range(3, 6);
                        }
                        if (strLength == 4)
                        {
                            num01 = Random.Range(6, 8);
                        }
                        inputKatakana = Kata.sheets[0].list[num01].kake5;
                        inputHiragana = Hira.sheets[0].list[num01].Hira_kake5;
                     
                        break;
                    case 1:
                        int num02 = 0;
                        if (strLength == 2)
                        {
                            num02 = Random.Range(8, 11);
                        }
                        if (strLength == 3)
                        {
                            num02 = Random.Range(11, 14);
                        }
                        if (strLength == 4)
                        {
                            num02 = Random.Range(14, 16);
                        }
                        inputKatakana = Kata.sheets[0].list[num02].kake5;
                        inputHiragana = Hira.sheets[0].list[num02].Hira_kake5;
                        break;
                    case 2:
                        int num03 = 0;
                        if (strLength == 2)
                        {
                            num03 = 16;
                        }
                        if (strLength == 3)
                        {
                            num03 = Random.Range(17, 23);
                        }
                        if (strLength == 4)
                        {
                            num03 = 23;
                        }
                        inputKatakana = Kata.sheets[0].list[num03].kake5;
                        inputHiragana = Hira.sheets[0].list[num03].Hira_kake5;
                        break;
                    case 3:
                        int num04 = 0;
                        if (strLength == 2)
                        {
                            num04 = Random.Range(24, 26);
                        }
                        if (strLength == 3)
                        {
                            num04 = Random.Range(26, 31);
                        }
                        if (strLength == 4)
                        {
                            num04 = 31;
                        }
                        inputKatakana = Kata.sheets[0].list[num04].kake5;
                        inputHiragana = Hira.sheets[0].list[num04].Hira_kake5;
                        break;
                    case 4:
                        int num05 = 0;
                        if (strLength == 2)
                        {
                            num05 = 32;
                        }
                        if (strLength == 3)
                        {
                            num05 = Random.Range(33, 38);
                        }
                        if (strLength == 4)
                        {
                            num05 = Random.Range(38,40);
                        }
                        inputKatakana = Kata.sheets[0].list[num05].kake5;
                        inputHiragana = Hira.sheets[0].list[num05].Hira_kake5;
                        break;
                }
                break;
            case 3:
                switch (newNameJudgeBoss.randomunum)
                {
                    case 0:
                        int num01 = 0;
                        if (strLength == 2)
                        {
                            num01 = Random.Range(0, 2);
                        }
                        if (strLength == 3)
                        {
                            num01 = Random.Range(2, 9);
                        }
                        inputKatakana = Kata.sheets[0].list[num01].yominikui3;
                        inputHiragana = Hira.sheets[0].list[num01].Hira_yominikui3;
                      
                        break;
                    case 1:
                        int num02 = 0;
                        if (strLength == 2)
                        {
                            num02 = Random.Range(9, 13);
                        }
                        if (strLength == 3)
                        {
                            num02 = Random.Range(13, 18);
                        }

                        inputKatakana = Kata.sheets[0].list[num02].yominikui3;
                        inputHiragana = Hira.sheets[0].list[num02].Hira_yominikui3;
                        break;
                    case 2:
                        int num03 = 0;
                        if (strLength == 2)
                        {
                            num03 = Random.Range(18, 21);
                        }
                        if (strLength == 3)
                        {
                            num03 = Random.Range(21, 27);
                        }
                        inputKatakana = Kata.sheets[0].list[num03].yominikui3;
                        inputHiragana = Hira.sheets[0].list[num03].Hira_yominikui3;
                       
                        break;
                    case 3:
                        int num04 = 0;
                        if (strLength == 2)
                        {
                            num04 = 27;
                        }
                        if (strLength == 3)
                        {
                            num04 = Random.Range(28, 36);
                        }

                        inputKatakana = Kata.sheets[0].list[num04].yominikui3;
                        inputHiragana = Hira.sheets[0].list[num04].Hira_yominikui3;
                        break;
                    case 4:
                        int num05 = 0;
                        if (strLength == 2)
                        {
                            num05 = Random.Range(36, 39);
                        }
                        if (strLength == 3)
                        {
                            num05 = Random.Range(39, 45);
                        }

                        inputKatakana = Kata.sheets[0].list[num05].yominikui3;
                        inputHiragana = Hira.sheets[0].list[num05].Hira_yominikui3;
                        break;
                }
                
                break;
            case 4:
                switch (newNameJudgeBoss.randomunum)
                {
                    case 0:
                        int num01 = 0;
                        if (strLength == 2)
                        {
                            num01 = 0;
                        }
                        if (strLength == 3)
                        {
                            num01 = Random.Range(1,12 );
                        }
                        inputKatakana = Kata.sheets[0].list[num01].yominikui5;
                        inputHiragana = Hira.sheets[0].list[num01].Hira_yominikui5;
                   
                        break;
                    case 1:
                        int num02 = 0;
                        if (strLength == 2)
                        {
                            num02 = 12;
                        }
                        if (strLength == 3)
                        {
                            num02 = Random.Range(13, 24);
                        }

                        inputKatakana = Kata.sheets[0].list[num02].yominikui5;
                        inputHiragana = Hira.sheets[0].list[num02].Hira_yominikui5;
                        break;
                    case 2:
                        int num03 = 0;
                        if (strLength == 2)
                        {
                            num03 = Random.Range(24, 27);
                        }
                        if (strLength == 3)
                        {
                            num03 = Random.Range(27, 36);
                        }

                        inputKatakana = Kata.sheets[0].list[num03].yominikui5;
                        inputHiragana = Hira.sheets[0].list[num03].Hira_yominikui5;
                        break;
                    case 3:
                        int num04 = 0;
                        if (strLength == 2)
                        {
                            num04 = Random.Range(36, 38);
                        }
                        if (strLength == 3)
                        {
                            num04 = Random.Range(38, 48);
                        }

                        inputKatakana = Kata.sheets[0].list[num04].yominikui5;
                        inputHiragana = Hira.sheets[0].list[num04].Hira_yominikui5;
                        break;
                    case 4:
                        int num05 = 0;
                        if (strLength == 2)
                        {
                            num05 = Random.Range(48, 50);
                        }
                        if (strLength == 3)
                        {
                            num05 = Random.Range(50, 60);
                        }

                        inputKatakana = Kata.sheets[0].list[num05].yominikui5;
                        inputHiragana = Hira.sheets[0].list[num05].Hira_yominikui5;
                        break;
                }
               
                break;
           
        }
    }
}
