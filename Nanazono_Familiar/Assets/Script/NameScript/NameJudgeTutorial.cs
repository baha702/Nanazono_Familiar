using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class NameJudgeTutorial : MonoBehaviour
{

    public int strLength;
    [SerializeField] TextMeshProUGUI[] enemyTMP;
    [SerializeField] string[] HiraganaName;
    [SerializeField] string[] KatakanaName;

    private Animator animator;
    private int strFlag;
    public bool[] flag;
    public Material blueMaterial, redMaterial;

    AudioSource audio;
    public AudioClip DMGClip;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        for (int i = 0; i < strLength; i++)
        {

            NameSet(KatakanaName[i], enemyTMP[i]);
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
        animator.SetTrigger("Dead");
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
        for (int i = 0; i < strLength; i++)
        {

            if (GameObject.Find("FlyingText") != null)
            {
                if (GameObject.Find(HiraganaName[i]) != null || GameObject.Find(KatakanaName[i]) != null)
                {
                    enemyTMP[i].text = string.Format(KatakanaName[i]);
                    enemyTMP[i].fontSharedMaterial = blueMaterial;
                    audio.PlayOneShot(DMGClip, 1.0f);
                    if (flag[i] == false)
                    {
                        animator.SetTrigger("Damage");
                        strFlag++;
                        flag[i] = true;
                        Debug.Log(strFlag);
                    }
                }

            }

        }
    }
    
}