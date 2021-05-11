using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameJudge : MonoBehaviour
{
    [SerializeField] int strLength;
    [SerializeField] string[] enemyStr;
    [SerializeField] TextMeshProUGUI[] enemyTMP;

    private int strFlag;
    public Material blueMaterial,redMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (strFlag >= strLength)
        {
            StartCoroutine("Coroutine");
        }
    }


    private IEnumerator Coroutine()
    {
        //１秒待機
        yield return new WaitForSeconds(2.0f);

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
   
    private void NameJudges(string str,TextMeshProUGUI TMPstr)
    {
        
        if (GameObject.Find("FlyingText") != null)
        {
            GameObject JudgeText = GameObject.Find("FlyingText");
            if (GameObject.Find(str) != null)
            {
                TMPstr.text = string.Format(str);
                TMPstr.fontSharedMaterial = blueMaterial;
                strFlag++;

            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i<strLength; i++)
        {
            NameJudges(enemyStr[i],enemyTMP[i]);
        }

        if (GameObject.Find("Target"))
        {
            StartCoroutine("Coroutine");
        }
    }
}
