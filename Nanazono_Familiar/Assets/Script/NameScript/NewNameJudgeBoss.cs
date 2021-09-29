using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class NewNameJudgeBoss : MonoBehaviour
{
    public int stagenum;
    public int strLength;
    public int MobstrLength;
    public int listnum;
    public int randomunum;
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

    Entity_Katakana Kata = null;
    Entity_Hiragana Hira = null;

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
      
        randomunum = Random.Range(0, 5);
        Debug.Log(randomunum);
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
        
        switch (strLength)
        {
            case 2:
                NameRepeat(collision);
                break;
            case 3:
                NameRepeat03(collision);
                break;
            case 4:
                NameRepeat04(collision);
                break;
        }
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

        for (int i = 0; i < strLength; i++)
        {
            enemyMoyaTMP[i].GetComponent<TextMeshProUGUI>().enabled = false;
        }


        atombool = false;

        yield return new WaitForSeconds(0.5f);
        switch (stagenum)
        {
            case 1:
                SceneManager.LoadScene("Stage02");
                break;
            case 2:
                SceneManager.LoadScene("Stage03");
                break;
            case 3:
                SceneManager.LoadScene("Stage04");
                break;
            case 4:
                SceneManager.LoadScene("GameClear");
                break;
        }
        //SceneManager.LoadScene("GameClear");
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
                    enemyMoyaTMP[i].GetComponent<TextMeshProUGUI>().enabled = false;
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
    public void NameRepeat03(Collision collision)
    {
        string hitObjectName = collision.gameObject.transform.root.name;
        Debug.Log(hitObjectName);
        var ar = strKatakana.Split(',');
        var ar2 = strHiragana.Split(',');
        if (GameObject.FindWithTag("flyingText"))
        {
            if (hitObjectName == ar[0] + ar[1]+ar[2] || hitObjectName == ar2[0] + ar2[1]+ar2[2])
            {
                for (int i = 0; i < strLength; i++)
                {

                    enemyTMP[i].text = string.Format(ar[i]);
                    enemyMoyaTMP[i].GetComponent<TextMeshProUGUI>().enabled = false;
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

    public void NameRepeat04(Collision collision)
    {
        string hitObjectName = collision.gameObject.transform.root.name;
        Debug.Log(hitObjectName);
        var ar = strKatakana.Split(',');
        var ar2 = strHiragana.Split(',');
        if (GameObject.FindWithTag("flyingText"))
        {
            if (hitObjectName == ar[0] + ar[1] + ar[2]+ar[3] || hitObjectName == ar2[0] + ar2[1] + ar2[2]+ar2[3])
            {
                for (int i = 0; i < strLength; i++)
                {

                    enemyTMP[i].text = string.Format(ar[i]);
                    enemyMoyaTMP[i].GetComponent<TextMeshProUGUI>().enabled = false;
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
                    Color color = new Color(67.0f, 255.0f, 234.0f, 255.0f);
                    //青くする
                    enemyMoyaTMP[i].color = color;
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
        Kata = Resources.Load("NameListKatakana") as Entity_Katakana;
        Hira = Resources.Load("NameListHiragana") as Entity_Hiragana;


        switch (number)
        {
            case 1:
                int num = randomunum;
                inputKatakana = Kata.sheets[0].list[num].kake2;
                inputHiragana = Hira.sheets[0].list[num].Hira_kake2;
                Debug.Log("inputKatakana"+inputKatakana);

                break;
            case 2:
                int num2 = randomunum;
     
                inputKatakana = Kata.sheets[0].list[num2].kake4;
                inputHiragana = Hira.sheets[0].list[num2].Hira_kake4;
                break;
            case 3:
                int num3 = randomunum;
             
                inputKatakana = Kata.sheets[0].list[num3].kake6;
                inputHiragana = Hira.sheets[0].list[num3].Hira_kake6;
                break;
            case 4:
                int num4 = randomunum;
             
                inputKatakana = Kata.sheets[0].list[num4].yominikui4;
                inputHiragana = Hira.sheets[0].list[num4].Hira_yominikui4;
                break;
          


        }
    }
}
